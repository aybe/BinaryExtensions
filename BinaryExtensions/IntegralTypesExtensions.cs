using System.IO;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    ///     Extension methods for integral types.
    /// </summary>
    [PublicAPI]
    public static class IntegralTypesExtensions
    {
        /// <summary>
        ///     Gets a 16-bit signed integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is not a valid position.
        /// </exception>
        public static short GetInt16(this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0 || sizeof(short) > bytes.Length - startIndex)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var value1 = BitConverter.ToInt16(bytes, startIndex);
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        /// <summary>
        ///     Gets a 32-bit signed integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is not a valid position.
        /// </exception>
        public static int GetInt32(this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0 || sizeof(int) > bytes.Length - startIndex)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var value1 = BitConverter.ToInt32(bytes, startIndex);
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        /// <summary>
        ///     Gets a 64-bit signed integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is not a valid position.
        /// </exception>
        public static long GetInt64(this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0 || sizeof(long) > bytes.Length - startIndex)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var value1 = BitConverter.ToInt64(bytes, startIndex);
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        /// <summary>
        ///     Gets a 16-bit unsigned integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is not a valid position.
        /// </exception>
        public static ushort GetUInt16(this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0 || sizeof(ushort) > bytes.Length - startIndex)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var value1 = BitConverter.ToUInt16(bytes, startIndex);
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        /// <summary>
        ///     Gets a 32-bit unsigned integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is not a valid position.
        /// </exception>
        public static uint GetUInt32(this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0 || sizeof(uint) > bytes.Length - startIndex)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var value1 = BitConverter.ToUInt32(bytes, startIndex);
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        /// <summary>
        ///     Gets a 64-bit unsigned integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is not a valid position.
        /// </exception>
        public static ulong GetUInt64(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0 || sizeof(ulong) > bytes.Length - startIndex)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var value1 = BitConverter.ToUInt64(bytes, startIndex);
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        /// <summary>
        ///     Tries to get a 16-bit signed integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read or <c>null</c> if not enough bytes at specified position.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is less than zero.
        /// </exception>
        public static short? TryGetInt16(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (sizeof(short) > bytes.Length - startIndex)
                return null;

            var value = bytes.GetInt16(startIndex, endianness);

            return value;
        }

        /// <summary>
        ///     Tries to get a 32-bit signed integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read or <c>null</c> if not enough bytes at specified position.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is less than zero.
        /// </exception>
        public static int? TryGetInt32(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (sizeof(int) > bytes.Length - startIndex)
                return null;

            var value = bytes.GetInt32(startIndex, endianness);

            return value;
        }

        /// <summary>
        ///     Tries to get a 64-bit signed integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read or <c>null</c> if not enough bytes at specified position.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is less than zero.
        /// </exception>
        public static long? TryGetInt64(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (sizeof(long) > bytes.Length - startIndex)
                return null;

            var value = bytes.GetInt64(startIndex, endianness);

            return value;
        }

        /// <summary>
        ///     Tries to get a 16-bit unsigned integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read or <c>null</c> if not enough bytes at specified position.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is less than zero.
        /// </exception>
        public static ushort? TryGetUInt16(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (sizeof(ushort) > bytes.Length - startIndex)
                return null;

            var value = bytes.GetUInt16(startIndex, endianness);

            return value;
        }

        /// <summary>
        ///     Tries to get a 32-bit unsigned integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read or <c>null</c> if not enough bytes at specified position.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is less than zero.
        /// </exception>
        public static uint? TryGetUInt32(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (sizeof(uint) > bytes.Length - startIndex)
                return null;

            var value = bytes.GetUInt32(startIndex, endianness);

            return value;
        }

        /// <summary>
        ///     Tries to get a 64-bit unsigned integer.
        /// </summary>
        /// <param name="bytes">
        ///     The source array.
        /// </param>
        /// <param name="startIndex">
        ///     The starting position within the array.
        /// </param>
        /// <param name="endianness">
        ///     The integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read or <c>null</c> if not enough bytes at specified position.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="bytes" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" /> is less than zero.
        /// </exception>
        public static ulong? TryGetUInt64(
            [NotNull] this byte[] bytes, int startIndex, Endianness endianness = Endianness.Native)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (sizeof(ulong) > bytes.Length - startIndex)
                return null;

            var value = bytes.GetUInt64(startIndex, endianness);

            return value;
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this byte value)
        {
            return $"0x{value:X2}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this sbyte value)
        {
            return $"0x{value:X2}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this ushort value)
        {
            return $"0x{value:X4}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this short value)
        {
            return $"0x{value:X4}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this uint value)
        {
            return $"0x{value:X8}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this int value)
        {
            return $"0x{value:X8}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this ulong value)
        {
            return $"0x{value:X16}";
        }

        /// <summary>
        ///     Converts this value to an hexadecimal string prefixed with '0x'.
        /// </summary>
        /// <param name="value">
        ///     The value to convert.
        /// </param>
        /// <returns>
        ///     The converted value.
        /// </returns>
        public static string ToStringHex(this long value)
        {
            return $"0x{value:X16}";
        }
    }
}