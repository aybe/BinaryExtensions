using System;
using JetBrains.Annotations;

namespace BinaryExtensions
{
    /// <summary>
    ///     Represents a region in a stream.
    /// </summary>
    [PublicAPI]
    public readonly struct LogStreamRegion : IEquatable<LogStreamRegion>
    {
        /// <summary>
        ///     Gets the position for this instance.
        /// </summary>
        public long Position { get; }

        /// <summary>
        ///     Gets the length for this instance.
        /// </summary>
        public long Length { get; }

        /// <summary>
        ///     Gets the name for this instance.
        /// </summary>
        [CanBeNull]
        public string Name { get; }

        /// <summary>
        ///     Initializes a new instance of <see cref="LogStreamRegion" />.
        /// </summary>
        /// <param name="position">
        ///     The position for the region.
        /// </param>
        /// <param name="length">
        ///     The length for the region.
        /// </param>
        /// <param name="name">
        ///     The name for the region.
        /// </param>
        public LogStreamRegion(long position, long length, [CanBeNull] string name = null)
        {
            Position = position;
            Length = length;
            Name = name;
        }

        /// <inheritdoc />
        public bool Equals(LogStreamRegion other)
        {
            return Position == other.Position && Length == other.Length && Name == other.Name;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is LogStreamRegion other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Position.GetHashCode();
                hashCode = (hashCode * 397) ^ Length.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        ///     Determines whether the specified instances are equal.
        /// </summary>
        /// <param name="left">
        ///     The first instance to compare.
        /// </param>
        /// <param name="right">
        ///     The second instance to compare.
        /// </param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> is equal to <paramref name="right" />, otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(LogStreamRegion left, LogStreamRegion right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether the specified instances are not equal.
        /// </summary>
        /// <param name="left">
        ///     The first instance to compare.
        /// </param>
        /// <param name="right">
        ///     The second instance to compare.
        /// </param>
        /// <returns>
        ///     <c>true</c> if <paramref name="left" /> is not equal to <paramref name="right" />, otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(LogStreamRegion left, LogStreamRegion right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Position)}: {Position}, {nameof(Length)}: {Length}, {nameof(Name)}: {Name}";
        }
    }
}