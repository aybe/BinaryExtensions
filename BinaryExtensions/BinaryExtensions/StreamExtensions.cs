using System;
using System.IO;
using System.Text;
using JetBrains.Annotations;

namespace BinaryExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="Stream" />.
    /// </summary>
    [PublicAPI]
    public static class StreamExtensions
    {
        /// <summary>
        ///     Gets a binary reader based on this stream.
        /// </summary>
        /// <param name="stream">
        ///     The source stream.
        /// </param>
        /// <param name="encoding">
        ///     The encoding for the binary reader, <c>null</c> for <see cref="Encoding.Default" />.
        /// </param>
        /// <param name="leaveOpen">
        ///     <c>true</c> to leave the stream open after the binary reader is disposed; otherwise, <c>false</c>.
        /// </param>
        /// <returns>
        ///     The binary reader.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream" /> is <c>null</c>.
        /// </exception>
        [NotNull]
        public static BinaryReader GetBinaryReader([NotNull] this Stream stream, [CanBeNull] Encoding encoding = null, bool leaveOpen = true)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var reader = new BinaryReader(stream, encoding ?? Encoding.Default, leaveOpen);

            return reader;
        }

        /// <summary>
        ///     Reads bytes at current position from this stream.
        /// </summary>
        /// <param name="stream">
        ///     The source stream.
        /// </param>
        /// <param name="count">
        ///     The number of bytes to read.
        /// </param>
        /// <returns>
        ///     The array of bytes read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="stream" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count" /> is less than or equal to zero.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        ///     <paramref name="count" /> bytes could not be read from <paramref name="stream" />.
        /// </exception>
        [NotNull]
        public static byte[] ReadBytes([NotNull] this Stream stream, int count)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var buffer = new byte[count];

            var read = stream.Read(buffer, 0, buffer.Length);

            if (read != count)
            {
                throw new EndOfStreamException();
            }

            return buffer;
        }
    }
}