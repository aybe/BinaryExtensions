using System;
using System.IO;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress
{
    /// <summary>
    ///     Extension methods for <see cref="BinaryWriter" />.
    /// </summary>
    public static class BinaryWriterExtensions
    {
        /// <summary>
        ///     Writes a 16-bit signed integer.
        /// </summary>
        /// <param name="writer">
        ///     The <see cref="BinaryWriter" /> to write to.
        /// </param>
        /// <param name="value">
        ///     The integer to write.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer" /> is <c>null</c>.
        /// </exception>
        [PublicAPI]
        public static void Write([NotNull] this BinaryWriter writer, short value, Endianness endianness)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.Write(value.ToEndian(endianness));
        }

        /// <summary>
        ///     Writes a 32-bit signed integer.
        /// </summary>
        /// <param name="writer">
        ///     The <see cref="BinaryWriter" /> to write to.
        /// </param>
        /// <param name="value">
        ///     The integer to write.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer" /> is <c>null</c>.
        /// </exception>
        [PublicAPI]
        public static void Write([NotNull] this BinaryWriter writer, int value, Endianness endianness)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.Write(value.ToEndian(endianness));
        }

        /// <summary>
        ///     Writes a 64-bit signed integer.
        /// </summary>
        /// <param name="writer">
        ///     The <see cref="BinaryWriter" /> to write to.
        /// </param>
        /// <param name="value">
        ///     The integer to write.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer" /> is <c>null</c>.
        /// </exception>
        [PublicAPI]
        public static void Write([NotNull] this BinaryWriter writer, long value, Endianness endianness)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.Write(value.ToEndian(endianness));
        }

        /// <summary>
        ///     Writes a 16-bit unsigned integer.
        /// </summary>
        /// <param name="writer">
        ///     The <see cref="BinaryWriter" /> to write to.
        /// </param>
        /// <param name="value">
        ///     The integer to write.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer" /> is <c>null</c>.
        /// </exception>
        [PublicAPI]
        public static void Write([NotNull] this BinaryWriter writer, ushort value, Endianness endianness)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.Write(value.ToEndian(endianness));
        }

        /// <summary>
        ///     Writes a 32-bit unsigned integer.
        /// </summary>
        /// <param name="writer">
        ///     The <see cref="BinaryWriter" /> to write to.
        /// </param>
        /// <param name="value">
        ///     The integer to write.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer" /> is <c>null</c>.
        /// </exception>
        [PublicAPI]
        public static void Write([NotNull] this BinaryWriter writer, uint value, Endianness endianness)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.Write(value.ToEndian(endianness));
        }

        /// <summary>
        ///     Writes a 64-bit unsigned integer.
        /// </summary>
        /// <param name="writer">
        ///     The <see cref="BinaryWriter" /> to write to.
        /// </param>
        /// <param name="value">
        ///     The integer to write.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer" /> is <c>null</c>.
        /// </exception>
        [PublicAPI]
        public static void Write([NotNull] this BinaryWriter writer, ulong value, Endianness endianness)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            writer.Write(value.ToEndian(endianness));
        }
    }
}