using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    internal sealed class LoggedBinaryReaderJournal : IList<LoggedBinaryReaderRegion>
    {
        internal LoggedBinaryReaderJournal([NotNull] LoggedBinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Reader = reader;
            Regions = new List<LoggedBinaryReaderRegion>();
        }

        private long Position { get; set; } = -1;

        private LoggedBinaryReader Reader { get; }

        private List<LoggedBinaryReaderRegion> Regions { get; }

        public void BeginLog()
        {
            if (Position != -1)
                throw new InvalidOperationException($"Call {nameof(EndLog)} first.");

            Position = Reader.BaseStream.Position;
        }

        public void EndLog()
        {
            if (Position == -1)
                throw new InvalidOperationException($"Call {nameof(BeginLog)} first.");

            Regions.Add(new LoggedBinaryReaderRegion(Position, Reader.BaseStream.Position - Position));

            Position = -1;
        }

        public IEnumerable<LoggedBinaryReaderRegion> GetOrderedRegions()
        {
            return Regions.OrderBy(s => s.Position);
        }

        #region IList

        public LoggedBinaryReaderRegion this[int index]
        {
            get { return Regions[index]; }
            set { Regions[index] = value; }
        }

        public int Count => Regions.Count;

        public bool IsReadOnly => ((ICollection<LoggedBinaryReaderRegion>) Regions).IsReadOnly;

        public void Add(LoggedBinaryReaderRegion item)
        {
            Regions.Add(item);
        }

        public void Clear()
        {
            Regions.Clear();
        }

        public bool Contains(LoggedBinaryReaderRegion item)
        {
            return Regions.Contains(item);
        }

        public void CopyTo(LoggedBinaryReaderRegion[] array, int arrayIndex)
        {
            Regions.CopyTo(array, arrayIndex);
        }

        public IEnumerator<LoggedBinaryReaderRegion> GetEnumerator()
        {
            return Regions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(LoggedBinaryReaderRegion item)
        {
            return Regions.IndexOf(item);
        }

        public void Insert(int index, LoggedBinaryReaderRegion item)
        {
            Regions.Insert(index, item);
        }

        public bool Remove(LoggedBinaryReaderRegion item)
        {
            return Regions.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Regions.RemoveAt(index);
        }

        #endregion
    }
}