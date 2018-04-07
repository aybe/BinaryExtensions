using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    /// <summary>
    ///     Extension methods for <see cref="System.IO.Stream" />.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        ///     Reads all the bytes in a stream (see Remarks).
        /// </summary>
        /// <param name="stream">
        ///     The source <see cref="System.IO.Stream" /> to read from.
        /// </param>
        /// <returns>
        ///     The bytes read.
        /// </returns>
        /// <remarks>
        ///     Stream position will be rewound to zero prior reading.
        /// </remarks>
        /// <exception cref="System.IO.EndOfStreamException">
        ///     Not enough bytes could be read.
        /// </exception>
        [PublicAPI]
        public static byte[] ReadAllBytes([NotNull] this Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            stream.Position = 0;

            var buffer = new byte[stream.Length];

            var read = stream.Read(buffer, 0, buffer.Length);
            if (read != buffer.Length)
                throw new EndOfStreamException();

            return buffer;
        }

        /// <summary>
        ///     Writes a stream to a file.
        /// </summary>
        /// <param name="stream">
        ///     The source <see cref="Stream" /> to read from.
        /// </param>
        /// <param name="path">
        ///     The destination path.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path" /> is <c>null</c>.
        /// </exception>
        public static void WriteToFile([NotNull] this Stream stream, [NotNull] string path)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var bytes = stream.ReadAllBytes();

            File.WriteAllBytes(path, bytes);
        }
    }
}