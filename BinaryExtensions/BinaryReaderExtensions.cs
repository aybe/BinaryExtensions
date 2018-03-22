﻿using System.Diagnostics.CodeAnalysis;
using System.Text;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    /// <summary>
    ///     Extension methods for <see cref="BinaryReader" />.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class BinaryReaderExtensions
    {
        #region Public fields

        #endregion

        #region Objects

        /// <summary>
        ///     Peeks an object at current position (see Remarks).
        /// </summary>
        /// <typeparam name="T">
        ///     Object type.
        /// </typeparam>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="func">
        ///     Function that reads the object.
        /// </param>
        /// <returns>
        ///     The object read.
        /// </returns>
        /// <remarks>
        ///     This method will save underlying stream position and restore it after reading the object.
        /// </remarks>
        [PublicAPI]
        public static T Peek<T>([NotNull] this BinaryReader reader, [NotNull] Func<BinaryReader, T> func)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            var position = reader.Position();
            var value = reader.Read(func);

            reader.Position(position);

            return value;
        }   
        
        /// <summary>
        ///     Reads an object at current position.
        /// </summary>
        /// <typeparam name="T">
        ///     Object type.
        /// </typeparam>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="func">
        ///     Function that reads the object.
        /// </param>
        /// <returns>
        ///     The object read.
        /// </returns>
        [PublicAPI]
        public static T Read<T>([NotNull] this BinaryReader reader, [NotNull] Func<BinaryReader, T> func)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            var value = func(reader);

            return value;
        }

        /// <summary>
        ///     Reads an enumeration.
        /// </summary>
        /// <typeparam name="T">
        ///     Enumeration type.
        /// </typeparam>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="endianness">
        ///     Enumeration endianness.
        /// </param>
        /// <param name="throwOnError">
        ///     Throw an exception if enumeration member is not defined.
        /// </param>
        /// <returns>
        ///     The enumeration member read.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <typeparamref name="T" /> is not an enumeration.
        /// </exception>
        /// <exception cref="InvalidDataException">
        ///     The enumeration member is not defined.
        /// </exception>
        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Global")]
        public static T ReadEnum<T>([NotNull] this BinaryReader reader, Endianness endianness, bool throwOnError)
            where T : struct, IConvertible
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var type = typeof(T);

            if (!type.IsEnum)
                throw new ArgumentOutOfRangeException(nameof(T));

            var o1 = ReadEnumInternal(reader, type, endianness);
            var o2 = (T) Enum.ToObject(type, o1);

            if (throwOnError && !Enum.IsDefined(typeof(T), o2))
                throw new InvalidDataException($"Value '{o2}' is not defined in enumeration.");

            return o2;
        }

        [SuppressMessage("ReSharper", "SwitchStatementMissingSomeCases")]
        private static object ReadEnumInternal(
            [NotNull] BinaryReader reader, [NotNull] Type type, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var underlyingType = type.GetEnumUnderlyingType();
            var typeCode = Type.GetTypeCode(underlyingType);

            switch (typeCode)
            {
                case TypeCode.SByte:
                    return reader.ReadSByte();
                case TypeCode.Byte:
                    return reader.ReadByte();
                case TypeCode.Int16:
                    return reader.ReadInt16(endianness);
                case TypeCode.UInt16:
                    return reader.ReadUInt16(endianness);
                case TypeCode.Int32:
                    return reader.ReadInt32(endianness);
                case TypeCode.UInt32:
                    return reader.ReadUInt32(endianness);
                case TypeCode.Int64:
                    return reader.ReadInt64(endianness);
                case TypeCode.UInt64:
                    return reader.ReadUInt64(endianness);
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeCode), typeCode, null);
            }
        }

        #endregion

        #region String

        /// <summary>
        ///     Peeks an ASCII string (see Remarks).
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="length">
        ///     String length.
        /// </param>
        /// <returns>
        ///     Length of the string to read.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length" /> is less than or equal to zero.
        /// </exception>
        /// <remarks>
        ///     Method calls <see cref="ReadStringAscii(System.IO.BinaryReader,int)" /> internally.
        /// </remarks>
        [PublicAPI]
        public static string PeekStringAscii([NotNull] this BinaryReader reader, int length)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var ascii = reader.ReadStringAscii(length);

            reader.Roll(length);

            return ascii;
        }

        /// <summary>
        ///     Reads an ASCII string.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="length">
        ///     Length of the string to read.
        /// </param>
        /// <returns>
        ///     The string read.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length" /> is less than or equal to zero.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        ///     Count of bytes read is less than <paramref name="length" />.
        /// </exception>
        [PublicAPI]
        public static string ReadStringAscii(this BinaryReader reader, int length)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var bytes = reader.ReadBytes(length);
            if (bytes.Length != length)
                throw new EndOfStreamException();

            var ascii = Encoding.ASCII.GetString(bytes);

            return ascii;
        }

        #endregion

        #region Length

        /// <summary>
        ///     Gets the length of the underlying stream.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The length of the underlying stream.
        /// </returns>
        [PublicAPI]
        public static long Length([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            return reader.BaseStream.Length;
        }

        /// <summary>
        ///     Sets the length of the underlying stream.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="length">
        ///     Length of the underlying stream.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="length" /> is less than zero.
        /// </exception>
        [PublicAPI]
        public static void Length([NotNull] this BinaryReader reader, long length)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            reader.BaseStream.SetLength(length);
        }

        #endregion

        #region Position

        /// <summary>
        ///     Aligns the position of the underlying stream to a multiple (see Remarks).
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="alignment">
        ///     Number of bytes to align by.
        /// </param>
        /// <remarks>
        ///     The underlying stream position is aligned forward.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="alignment" /> is less than or equal to zero.
        /// </exception>
        public static void Align(this BinaryReader reader, int alignment)
        {
            if (alignment <= 0)
                throw new ArgumentOutOfRangeException(nameof(alignment));

            var position1 = reader.Position();
            var position2 = position1 + position1 % alignment;

            reader.Position(position2);
        }

        /// <summary>
        ///     Gets the position of the underlying stream.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The position of the underlying stream.
        /// </returns>
        [PublicAPI]
        public static long Position([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            return reader.BaseStream.Position;
        }

        /// <summary>
        ///     Sets the position of the underlying stream.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="position">
        ///     Position to set the underlying stream to.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="position" /> is less than zero.
        /// </exception>
        [PublicAPI]
        public static void Position([NotNull] this BinaryReader reader, long position)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position));

            reader.BaseStream.Position = position;
        }

        /// <summary>
        ///     Move underlying stream position backward.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="count">
        ///     Number of bytes to roll.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count" /> is less than or equal to zero.
        /// </exception>
        [PublicAPI]
        public static void Roll([NotNull] this BinaryReader reader, int count)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            reader.BaseStream.Position -= count;
        }

        /// <summary>
        ///     Move underlying stream position forward.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="count">
        ///     Number of bytes to skip.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count" /> is less than or equal to zero.
        /// </exception>
        [PublicAPI]
        public static void Skip([NotNull] this BinaryReader reader, int count)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            reader.BaseStream.Position += count;
        }

        #endregion

        #region Int16


        /// <summary>
        ///     Reads a 16-bit signed integer.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static short ReadInt16(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt16();

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
        ///     Reads a 16-bit signed integer in big-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static short ReadInt16BE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt16(Endianness.BigEndian);

            return value;
        }

        /// <summary>
        ///     Reads a 16-bit signed integer in little-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static short ReadInt16LE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt16(Endianness.LittleEndian);

            return value;
        }

        #endregion

        #region Int32


        /// <summary>
        ///     Reads a 32-bit signed integer.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static int ReadInt32(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt32();

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
        ///     Reads a 32-bit signed integer in big-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static int ReadInt32BE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt32(Endianness.BigEndian);

            return value;
        }

        /// <summary>
        ///     Reads a 32-bit signed integer in little-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static int ReadInt32LE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt32(Endianness.LittleEndian);

            return value;
        }

        #endregion

        #region Int64


        /// <summary>
        ///     Reads a 64-bit signed integer.
        /// </summary>
        /// <param name="reader">The <see cref="BinaryReader" /> to read from.</param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static long ReadInt64([NotNull] this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt64();

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
        ///     Reads a 64-bit signed integer in big-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static long ReadInt64BE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt64(Endianness.BigEndian);

            return value;
        }

        /// <summary>
        ///     Reads a 64-bit signed integer in little-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static long ReadInt64LE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadInt64(Endianness.LittleEndian);

            return value;
        }

        #endregion

        #region UInt16


        /// <summary>
        ///     Reads a 16-bit unsigned integer.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="endianness">
        ///     Integer endiannness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static ushort ReadUInt16(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt16();

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
        ///     Reads a 16-bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static ushort ReadUInt16BE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt16(Endianness.BigEndian);

            return value;
        }

        /// <summary>
        ///     Reads a 16-bit unsigned integer in little-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static ushort ReadUInt16LE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt16(Endianness.LittleEndian);

            return value;
        }

        #endregion

        #region UInt32


        /// <summary>
        ///     Reads a 32-bit unsigned integer.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static uint ReadUInt32(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt32();

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
        ///     Reads a 32-bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static uint ReadUInt32BE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt32(Endianness.BigEndian);

            return value;
        }

        /// <summary>
        ///     Reads a 32-bit unsigned integer in little-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static uint ReadUInt32LE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt32(Endianness.LittleEndian);

            return value;
        }

        #endregion

        #region UInt64


        /// <summary>
        ///     Reads a 64-bit unsigned integer.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="endianness">
        ///     Integer endianness.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static ulong ReadUInt64([NotNull] this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt64();

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
        ///     Reads a 64-bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static ulong ReadUInt64BE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt64(Endianness.BigEndian);

            return value;
        }

        /// <summary>
        ///     Reads a 64-bit unsigned integer in little-endian format.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The integer read.
        /// </returns>
        [PublicAPI]
        public static ulong ReadUInt64LE([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var value = reader.ReadUInt64(Endianness.LittleEndian);

            return value;
        }

        #endregion
    }
}