using System;
using System.Collections.Generic;
using System.IO;
using BinaryExtensions.Annotations;

namespace BinaryExtensions
{
    internal readonly struct LogStreamScope : IDisposable
    {
        [NotNull]
        private Stream Stream { get; }

        [NotNull]
        private IList<LogStreamRegion> Regions { get; }

        private long Position { get; }

        public LogStreamScope([NotNull] Stream stream, [NotNull] IList<LogStreamRegion> regions)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            Regions = regions ?? throw new ArgumentNullException(nameof(regions));
            Position = stream.Position;
        }

        public void Dispose()
        {
            Regions.Add(new LogStreamRegion(Position, Stream.Position - Position));
        }
    }
}