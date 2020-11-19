using System;
using System.Runtime.CompilerServices;
using BinaryExtensions.Annotations;

namespace BinaryExtensions
{
    /// <summary>
    ///     Extension methods for endianness.
    /// </summary>
    public static partial class EndiannessExtensions
    {
        /// <summary>
        ///     Gets the endianness for this environment.
        /// </summary>
        [PublicAPI]
        public static Endianness Endianness { get; } =
            BitConverter.IsLittleEndian
                ? Endianness.LittleEndian
                : Endianness.BigEndian;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static short ReverseEndianness(short value)
        {
            return (short) ReverseEndianness((ushort) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ReverseEndianness(int value)
        {
            return (int) ReverseEndianness((uint) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long ReverseEndianness(long value)
        {
            return (long) ReverseEndianness((ulong) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort ReverseEndianness(ushort value)
        {
            return (ushort) ((value >> 8) + (value << 8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint ReverseEndianness(uint value)
        {
            var value1 = value & 0x00FF00FFu;
            var value2 = value & 0xFF00FF00u;
            var value3 = ((value1 >> 8) | (value1 << (32 - 8))) + ((value2 << 8) | (value2 >> (32 - 8)));

            return value3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong ReverseEndianness(ulong value)
        {
            var value1 = (ulong) ReverseEndianness((uint) value) << 32;
            var value2 = ReverseEndianness((uint) (value >> 32));
            var value3 = value1 + value2;

            return value3;
        }
    }
}