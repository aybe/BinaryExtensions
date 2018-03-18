using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    /// <summary>
    ///     Extension methods for converting endianness.
    /// </summary>
    public static class EndiannesExtensions
    {
        /// <summary>
        ///     Converts a 16-bit signed integer to a specific endianness.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <param name="endianness">
        ///     The endianness to convert to.
        /// </param>
        /// <returns>
        ///     The converted integer.
        /// </returns>
        [PublicAPI]
        public static short ToEndian(this short value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.BigEndian:
                    return value.ToBigEndian();
                case Endianness.LittleEndian:
                    return value.ToLittleEndian();
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }

        /// <summary>
        ///     Converts a 32-bit signed integer to a specific endianness.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <param name="endianness">
        ///     The endianness to convert to.
        /// </param>
        /// <returns>
        ///     The converted integer.
        /// </returns>
        [PublicAPI]
        public static int ToEndian(this int value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.BigEndian:
                    return value.ToBigEndian();
                case Endianness.LittleEndian:
                    return value.ToLittleEndian();
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }

        /// <summary>
        ///     Converts a 64-bit signed integer to a specific endianness.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <param name="endianness">
        ///     The endianness to convert to.
        /// </param>
        /// <returns>
        ///     The converted integer.
        /// </returns>
        [PublicAPI]
        public static long ToEndian(this long value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.BigEndian:
                    return value.ToBigEndian();
                case Endianness.LittleEndian:
                    return value.ToLittleEndian();
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }

        /// <summary>
        ///     Converts a 16-bit unsigned integer to a specific endianness.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <param name="endianness">
        ///     The endianness to convert to.
        /// </param>
        /// <returns>
        ///     The converted integer.
        /// </returns>
        [PublicAPI]
        public static ushort ToEndian(this ushort value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.BigEndian:
                    return value.ToBigEndian();
                case Endianness.LittleEndian:
                    return value.ToLittleEndian();
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }

        /// <summary>
        ///     Converts a 32-bit unsigned integer to a specific endianness.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <param name="endianness">
        ///     The endianness to convert to.
        /// </param>
        /// <returns>
        ///     The converted integer.
        /// </returns>
        [PublicAPI]
        public static uint ToEndian(this uint value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.BigEndian:
                    return value.ToBigEndian();
                case Endianness.LittleEndian:
                    return value.ToLittleEndian();
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }

        /// <summary>
        ///     Converts a 64-bit unsigned integer to a specific endianness.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <param name="endianness">
        ///     The endianness to convert to.
        /// </param>
        /// <returns>
        ///     The converted integer.
        /// </returns>
        [PublicAPI]
        public static ulong ToEndian(this ulong value, Endianness endianness)
        {
            switch (endianness)
            {
                case Endianness.BigEndian:
                    return value.ToBigEndian();
                case Endianness.LittleEndian:
                    return value.ToLittleEndian();
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }
    }
}