using System.IO;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    ///     Extension methods for converting endianness.
    /// </summary>
    public static class EndiannesExtensions
    {
        /// <summary>
        ///     Gets the current environment endianness.
        /// </summary>
        [PublicAPI] public static readonly Endianness Current =
            BitConverter.IsLittleEndian
                ? Endianness.LittleEndian
                : Endianness.BigEndian;

        /// <summary>
        ///     Gets if the environment endianness is big-endian.
        /// </summary>
        [PublicAPI] public static readonly bool IsBigEndian = Current == Endianness.BigEndian;

        /// <summary>
        ///     Gets if the environment endianness is little-endian.
        /// </summary>
        [PublicAPI] public static readonly bool IsLittleEndian = Current == Endianness.LittleEndian;

        /// <summary>
        ///     Reverses the order of bytes in a 16-bit signed integer.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        [PublicAPI]
        public static short EndianReverse(this short value)
        {
            unchecked
            {
                return (short)
                (
                    ((byte) ((value >> 00) & 0xFF) << 08) |
                    ((byte) ((value >> 08) & 0xFF) << 00)
                );
            }
        }

        /// <summary>
        ///     Reverses the order of bytes in a 32-bit signed integer.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        [PublicAPI]
        public static int EndianReverse(this int value)
        {
            unchecked
            {
                return ((byte) ((value >> 24) & 0xFF) << 00) |
                       ((byte) ((value >> 16) & 0xFF) << 08) |
                       ((byte) ((value >> 08) & 0xFF) << 16) |
                       ((byte) ((value >> 00) & 0xFF) << 24);
            }
        }

        /// <summary>
        ///     Reverses the order of bytes in a 64-bit signed integer.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        [PublicAPI]
        public static long EndianReverse(this long value)
        {
            unchecked
            {
                return ((byte) ((value >> 56) & 0xFF) << 00) |
                       ((byte) ((value >> 48) & 0xFF) << 08) |
                       ((byte) ((value >> 40) & 0xFF) << 16) |
                       ((byte) ((value >> 32) & 0xFF) << 24) |
                       ((byte) ((value >> 24) & 0xFF) << 32) |
                       ((byte) ((value >> 16) & 0xFF) << 40) |
                       ((byte) ((value >> 08) & 0xFF) << 48) |
                       ((byte) ((value >> 00) & 0xFF) << 56);
            }
        }

        /// <summary>
        ///     Reverses the order of bytes in a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        [PublicAPI]
        public static ushort EndianReverse(this ushort value)
        {
            unchecked
            {
                return (ushort)
                (
                    ((byte) ((value >> 00) & 0xFF) << 08) |
                    ((byte) ((value >> 08) & 0xFF) << 00)
                );
            }
        }

        /// <summary>
        ///     Reverses the order of bytes in a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        [PublicAPI]
        public static uint EndianReverse(this uint value)
        {
            unchecked
            {
                return (uint)
                (
                    ((byte) ((value >> 24) & 0xFF) << 00) |
                    ((byte) ((value >> 16) & 0xFF) << 08) |
                    ((byte) ((value >> 08) & 0xFF) << 16) |
                    ((byte) ((value >> 00) & 0xFF) << 24)
                );
            }
        }

        /// <summary>
        ///     Reverses the order of bytes in a 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        [PublicAPI]
        public static ulong EndianReverse(this ulong value)
        {
            unchecked
            {
                return (ulong)
                (
                    ((byte) ((value >> 56) & 0xFF) << 00) |
                    ((byte) ((value >> 48) & 0xFF) << 08) |
                    ((byte) ((value >> 40) & 0xFF) << 16) |
                    ((byte) ((value >> 32) & 0xFF) << 24) |
                    ((byte) ((value >> 24) & 0xFF) << 32) |
                    ((byte) ((value >> 16) & 0xFF) << 40) |
                    ((byte) ((value >> 08) & 0xFF) << 48) |
                    ((byte) ((value >> 00) & 0xFF) << 56)
                );
            }
        }

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
                    return IsBigEndian ? value : value.EndianReverse();
                case Endianness.LittleEndian:
                    return IsLittleEndian ? value : value.EndianReverse();
                case Endianness.Native:
                    return value;
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
                    return IsBigEndian ? value : value.EndianReverse();
                case Endianness.LittleEndian:
                    return IsLittleEndian ? value : value.EndianReverse();
                case Endianness.Native:
                    return value;
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
                    return IsBigEndian ? value : value.EndianReverse();
                case Endianness.LittleEndian:
                    return IsLittleEndian ? value : value.EndianReverse();
                case Endianness.Native:
                    return value;
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
                    return IsBigEndian ? value : value.EndianReverse();
                case Endianness.LittleEndian:
                    return IsLittleEndian ? value : value.EndianReverse();
                case Endianness.Native:
                    return value;
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
                    return IsBigEndian ? value : value.EndianReverse();
                case Endianness.LittleEndian:
                    return IsLittleEndian ? value : value.EndianReverse();
                case Endianness.Native:
                    return value;
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
                    return IsBigEndian ? value : value.EndianReverse();
                case Endianness.LittleEndian:
                    return IsLittleEndian ? value : value.EndianReverse();
                case Endianness.Native:
                    return value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(endianness), endianness, null);
            }
        }
    }
}