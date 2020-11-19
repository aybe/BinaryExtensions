using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace BinaryExtensions
{
    /// <summary>
    ///     A stream that wraps and logs read and written regions of another stream.
    /// </summary>
    [PublicAPI]
    public class LogStream : Stream
    {
        #region Static Fields and Constants

        private const int InvalidRegionIndex = -1;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="LogStream" />.
        /// </summary>
        /// <param name="stream">
        ///     The stream to wrap.
        /// </param>
        /// <param name="leaveOpen">
        ///     Whether or not to dispose <paramref name="stream" /> after disposing.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream" /> is <c>null</c>.
        /// </exception>
        public LogStream([NotNull] Stream stream, bool leaveOpen = false)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            StreamLeaveOpen = leaveOpen;
        }

        #endregion

        #region Fields

        private readonly List<LogStreamRegion> RegionsR = new List<LogStreamRegion>();

        private readonly List<LogStreamRegion> RegionsW = new List<LogStreamRegion>();

        private readonly Stream Stream;

        private readonly bool StreamLeaveOpen;

        private bool IsDisposed;

        private int RegionsRIndex = InvalidRegionIndex;

        private string RegionsRName;

        private int RegionsWIndex = InvalidRegionIndex;

        private string RegionsWName;

        #endregion

        #region Overrides

        /// <inheritdoc />
        public override bool CanRead => Stream.CanRead;

        /// <inheritdoc />
        public override bool CanSeek => Stream.CanSeek;

        /// <inheritdoc />
        public override bool CanWrite => Stream.CanWrite;

        /// <inheritdoc />
        public override long Length => Stream.Length;

        /// <inheritdoc />
        public override long Position
        {
            get => Stream.Position;
            set => Stream.Position = value;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing && !StreamLeaveOpen)
                {
                    Stream.Dispose();
                }

                IsDisposed = true;
            }

            base.Dispose(disposing);
        }

        /// <inheritdoc />
        public override void Flush()
        {
            Stream.Flush();
        }

        /// <inheritdoc />
        public override int Read(byte[] buffer, int offset, int count)
        {
            using var _ = new LogStreamScope(Stream, RegionsR);
            return Stream.Read(buffer, offset, count);
        }

        /// <inheritdoc />
        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream.Seek(offset, origin);
        }

        /// <inheritdoc />
        public override void SetLength(long value)
        {
            Stream.SetLength(value);
        }

        /// <inheritdoc />
        public override void Write(byte[] buffer, int offset, int count)
        {
            using var _ = new LogStreamScope(Stream, RegionsW);
            Stream.Write(buffer, offset, count);
        }

        #endregion

        #region Methods

        private static void BeginGroup(
            [NotNull] string callee, [NotNull] string caller,
            [NotNull] IList<LogStreamRegion> regions, ref int regionIndex, ref string regionName, string name)
        {
            if (regions is null)
                throw new ArgumentNullException(nameof(regions));

            if (callee is null)
                throw new ArgumentNullException(nameof(callee));

            if (caller is null)
                throw new ArgumentNullException(nameof(caller));

            if (regionIndex != InvalidRegionIndex)
                throw new InvalidOperationException($"A preceding call to {callee} was not followed by a call to {caller}.");

            regionIndex = regions.Count;
            regionName = name;
        }

        private static void EndGroup(
            [NotNull] string callee, [NotNull] string caller,
            [NotNull] IList<LogStreamRegion> regions, ref int regionIndex, ref string regionName)
        {
            if (callee is null)
                throw new ArgumentNullException(nameof(callee));

            if (caller is null)
                throw new ArgumentNullException(nameof(caller));

            if (regions is null)
                throw new ArgumentNullException(nameof(regions));

            if (regionIndex == InvalidRegionIndex)
                throw new InvalidOperationException($"A preceding call to {caller} was not followed by a call to {callee}.");

            var enumerable = regions.Skip(regionIndex).Take(regions.Count - regionIndex);

            using var enumerator = enumerable.GetEnumerator();

            if (enumerator.MoveNext() == false)
                throw new InvalidOperationException("Source stream state hasn't changed.");

            var current  = enumerator.Current;
            var position = current.Position;
            var length   = 0L;
            var count    = 1;

            while (enumerator.MoveNext()) // ensure they're all contiguous or overlapping
            {
                var region = enumerator.Current;

                if (region.Position > current.Position + current.Length)
                    throw new InvalidOperationException("Only successive or overlapping accesses are allowed.");

                length += region.Length;
                count += 1;
                current = region;
            }

            // concat into single one

            for (var i = 0; i < count; i++)
            {
                regions.RemoveAt(regions.Count - 1);
            }

            regions.Add(new LogStreamRegion(position, length, regionName));

            regionIndex = InvalidRegionIndex;
            regionName = null;
        }

        private IReadOnlyList<LogStreamRegion> GetRegionsIntersect([NotNull] IEnumerable<LogStreamRegion> regions)
        {
            if (regions is null)
                throw new ArgumentNullException(nameof(regions));

            var source = regions.OrderBy(s => s.Position).ThenBy(s => s.Length).ToList();

            for (var i = 0; i < source.Count - 1; i++) // concat overlapping regions
            {
                var region1 = source[i];
                var region2 = source[i + 1];

                if (region1.Position + region1.Length < region2.Position)
                    continue;

                var pos   = region1.Position;
                var max   = Math.Max(region1.Position + region1.Length, region2.Position + region2.Length);
                var len   = max - pos;
                var name1 = region1.Name?.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
                var name2 = region2.Name?.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
                var name3 = string.Join(", ", string.Concat(name1, name2));

                source[i] = new LogStreamRegion(pos, len, name3);
                source.RemoveAt(i + 1);
                i--; // do it again
            }

            var target = new List<LogStreamRegion>
            {
                new LogStreamRegion(0, Stream.Length)
            };

            foreach (var region in source) // extract non-accessed regions
            {
                var old    = target[target.Count - 1];
                var oldPos = old.Position;
                var oldLen = region.Position - oldPos;

                target[target.Count - 1] = new LogStreamRegion(oldPos, oldLen, old.Name);

                var newPos = region.Position + region.Length;
                var newLen = Stream.Length - newPos;

                target.Add(new LogStreamRegion(newPos, newLen, region.Name));
            }

            target = target.Where(s => s.Length > 0).ToList(); // simple fix

            return target.AsReadOnly();
        }

        /// <summary>
        ///     Begins a group that concatenates successive reads.
        /// </summary>
        /// <param name="name">
        ///     The name for the group.
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///     A preceding call to <see cref="BeginReadGroup" /> was not followed by a call to <see cref="EndReadGroup" />.
        /// </exception>
        [PublicAPI]
        public void BeginReadGroup(string name = null)
        {
            BeginGroup(nameof(BeginReadGroup), nameof(EndGroup), RegionsR, ref RegionsRIndex, ref RegionsRName, name);
        }

        /// <summary>
        ///     Begins a group that concatenates successive writes.
        /// </summary>
        /// <param name="name">
        ///     The name for the group.
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///     A preceding call to <see cref="BeginWriteGroup" /> was not followed by a call to <see cref="EndWriteGroup" />.
        /// </exception>
        [PublicAPI]
        public void BeginWriteGroup(string name = null)
        {
            BeginGroup(nameof(BeginWriteGroup), nameof(EndWriteGroup), RegionsW, ref RegionsWIndex, ref RegionsWName, name);
        }

        /// <summary>
        ///     Ends a group that concatenates successive reads.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     A preceding call to <see cref="EndReadGroup" /> was not followed by a call to <see cref="BeginReadGroup" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     No data was read from source stream.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Only successive or overlapping reads are allowed.
        /// </exception>
        [PublicAPI]
        public void EndReadGroup()
        {
            EndGroup(nameof(EndReadGroup), nameof(BeginReadGroup), RegionsR, ref RegionsRIndex, ref RegionsRName);
        }

        /// <summary>
        ///     Ends a group that concatenates successive writes.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     A preceding call to <see cref="EndWriteGroup" /> was not followed by a call to <see cref="BeginWriteGroup" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     No data was written to source stream.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Only successive or overlapping writes are allowed.
        /// </exception>
        [PublicAPI]
        public void EndWriteGroup()
        {
            EndGroup(nameof(EndWriteGroup), nameof(BeginWriteGroup), RegionsW, ref RegionsWIndex, ref RegionsWName);
        }

        /// <summary>
        ///     Gets the list of regions that have been read.
        /// </summary>
        /// <returns>
        ///     A list containing regions that have been read.
        /// </returns>
        [PublicAPI]
        [NotNull]
        public IReadOnlyList<LogStreamRegion> GetRegionsRead()
        {
            return RegionsR.AsReadOnly();
        }

        /// <summary>
        ///     Gets the of regions that haven't been read.
        /// </summary>
        /// <returns>
        ///     A list containing regions that haven't been read.
        /// </returns>
        [PublicAPI]
        [NotNull]
        public IReadOnlyList<LogStreamRegion> GetRegionsReadIntersect()
        {
            return GetRegionsIntersect(RegionsR);
        }

        /// <summary>
        ///     Gets the list of regions that have been written.
        /// </summary>
        /// <returns>
        ///     A list containing regions that have been written.
        /// </returns>
        [PublicAPI]
        [NotNull]
        public IReadOnlyList<LogStreamRegion> GetRegionsWritten()
        {
            return RegionsW.AsReadOnly();
        }

        /// <summary>
        ///     Gets the of regions that haven't been written.
        /// </summary>
        /// <returns>
        ///     A list containing regions that haven't been written.
        /// </returns>
        [PublicAPI]
        [NotNull]
        public IReadOnlyList<LogStreamRegion> GetRegionsWrittenIntersect()
        {
            return GetRegionsIntersect(RegionsW);
        }

        #endregion
    }
}