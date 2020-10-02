using System;
using System.IO;
using JetBrains.Annotations;

namespace BinaryExtensions
{
    /// <summary>
    ///     Extension methods for <see cref="BinaryReader" />.
    /// </summary>
    [PublicAPI]
    public static class BinaryReaderExtensions
    {
        /// <summary>
        ///     Reads an array of items using a function.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of item to read.
        /// </typeparam>
        /// <param name="reader">
        ///     The source binary reader.
        /// </param>
        /// <param name="func">
        ///     The function for reading an item.
        /// </param>
        /// <param name="count">
        ///     The number of items to read.
        /// </param>
        /// <returns>
        ///     The array of items read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> or <paramref name="func" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count" /> is less than or equal to zero.
        /// </exception>
        [NotNull]
        [ItemNotNull]
        public static T[] Read<T>([NotNull] this BinaryReader reader, [NotNull] Func<BinaryReader, T> func, int count)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var items = new T[count];

            for (var i = 0; i < count; i++)
            {
                items[i] = func(reader);
            }

            return items;
        }

        /// <summary>
        ///     Reads an enumeration.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of enumeration.
        /// </typeparam>
        /// <param name="reader">
        ///     The source binary reader.
        /// </param>
        /// <param name="endianness">
        ///     The endianness for the enumeration.
        /// </param>
        /// <returns>
        ///     The enumeration read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> is <c>null</c>.
        /// </exception>
        [NotNull]
        public static T ReadEnum<T>([NotNull] this BinaryReader reader, Endianness endianness = Endianness.Native)
            where T : Enum
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var enumType       = typeof(T);
            var underlyingType = Enum.GetUnderlyingType(enumType);
            var typeCode       = Type.GetTypeCode(underlyingType);

            // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
            object value = typeCode switch
            {
                TypeCode.Byte   => reader.ReadByte(),
                TypeCode.Int16  => reader.ReadInt16(endianness),
                TypeCode.Int32  => reader.ReadInt32(endianness),
                TypeCode.Int64  => reader.ReadInt64(endianness),
                TypeCode.SByte  => reader.ReadSByte(),
                TypeCode.UInt16 => reader.ReadUInt16(endianness),
                TypeCode.UInt32 => reader.ReadUInt32(endianness),
                TypeCode.UInt64 => reader.ReadUInt64(endianness),
                _               => throw new InvalidOperationException()
            };

            var result = (T) Enum.ToObject(enumType, value);

            return result;
        }
    }
}