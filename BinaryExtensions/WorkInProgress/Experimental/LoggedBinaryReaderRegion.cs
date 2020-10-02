using System;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    public struct LoggedBinaryReaderRegion
    {
        public LoggedBinaryReaderRegion(long position, long length)
        {
            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position));

            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            Position = position;
            Length = length;
        }

        public long Position { get; }

        public long Length { get; }

        public override string ToString()
        {
            return $"{nameof(Position)}: {Position}, {nameof(Length)}: {Length}";
        }
    }
}