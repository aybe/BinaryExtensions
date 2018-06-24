using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
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
        ///     Reads an array of objects at current position.
        /// </summary>
        /// <typeparam name="T">
        ///     Objects type.
        /// </typeparam>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="func">
        ///     Function that reads the objects.
        /// </param>
        /// <param name="count">
        ///     Number of objects to read.
        /// </param>
        /// <returns>
        ///     The objects read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> or <paramref name="func" /> are <code>null</code>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count" /> is less than or equal to zero.
        /// </exception>
        [PublicAPI]
        public static T[] Read<T>(this BinaryReader reader, Func<BinaryReader, T> func, int count)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var values = new T[count];

            for (var i = 0; i < values.Length; i++)
            {
                var value = reader.Read(func);

                values[i] = value;
            }

            return values;
        }

        /// <summary>
        ///     Reads a structure (see Remarks).
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <typeparam name="T">
        ///     Structure type.
        /// </typeparam>
        /// <returns>
        ///     The structure read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> is <c>null</c>.
        /// </exception>
        /// <remarks>
        ///     The structure will be read using <see cref="Marshal.SizeOf{T}()" /> and
        ///     <see cref="Marshal.PtrToStructure{T}(System.IntPtr)" />.
        /// </remarks>
        [PublicAPI]
        public static T ReadStruct<T>([NotNull] this BinaryReader reader) where T : struct
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var size = Marshal.SizeOf<T>();
            var bytes = reader.ReadBytes(size);

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);

            var structure = Marshal.PtrToStructure<T>(ptr);
            Marshal.FreeHGlobal(ptr);

            return structure;
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
        public static T ReadEnum<T>([NotNull] this BinaryReader reader, Endianness endianness = Endianness.Native,
            bool throwOnError = true)
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

        /// <summary>
        ///     Reads a null-terminated ASCII string.
        /// </summary>
        /// <param name="reader">
        ///     The source <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="greedy">
        ///     Whether to consume all trailing NUL characters, default is <c>false</c>.
        /// </param>
        /// <returns>
        ///     The string read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> is <c>null</c>.
        /// </exception>
        public static string ReadStringAsciiNullTerminated([JetBrains.Annotations.NotNull] this BinaryReader reader,
            bool greedy = false)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var builder = new StringBuilder();

            while (true)
            {
                var c = (char) reader.ReadByte();
                if (c == '\0')
                    break;

                builder.Append(c);
            }

            if (greedy)
            {
                while (true)
                {
                    var c = (char) reader.ReadByte();
                    if (c == '\0')
                        continue;

                    reader.Roll(sizeof(byte));
                    break;
                }
            }

            var ascii = builder.ToString();

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

        #region Bytes

        /// <summary>
        ///     Reads bytes at specified position.
        /// </summary>
        /// <param name="reader">
        ///     The <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <param name="count">
        ///     Number of bytes to read.
        /// </param>
        /// <param name="position">
        ///     Position to read from.
        /// </param>
        /// <returns>
        ///     The bytes read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="count" /> and <paramref name="position" /> defines invalid range.
        /// </exception>
        [PublicAPI]
        public static byte[] ReadBytes([NotNull] this BinaryReader reader, int count, long position)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (position <= 0)
                throw new ArgumentOutOfRangeException(nameof(position));

            if (reader.Length() < position + count)
                throw new ArgumentOutOfRangeException(nameof(count));

            reader.Position(position);

            return reader.ReadBytes(count);
        }

        /// <summary>
        ///     Reads two nibbles.
        /// </summary>
        /// <param name="reader">
        ///     The source <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     The nibbles read.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="reader" /> is <c>null</c>.
        /// </exception>
        public static byte[] ReadNibbles([JetBrains.Annotations.NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var b = reader.ReadByte();

            var nibbles = new[]
            {
                (byte) ((b >> 4) & 0xF),
                (byte) ((b >> 0) & 0xF)
            };

            return nibbles;
        }

        /// <summary>
        ///     Reads bytes from current position to end of stream.
        /// </summary>
        /// <param name="reader">
        ///     The source <see cref="BinaryReader" /> to read from.
        /// </param>
        /// <returns>
        ///     Bytes read.
        /// </returns>
        [PublicAPI]
        public static byte[] ReadToEnd([NotNull] this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var count = reader.BaseStream.Length - reader.BaseStream.Position;
            var bytes = reader.ReadBytes(count.ToInt32());

            return bytes;
        }

        #endregion

        #region Integers

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

            var value1 = reader.ReadInt16();
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

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

            var value1 = reader.ReadInt32();
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

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

            var value1 = reader.ReadInt64();
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

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

            var value1 = reader.ReadUInt16();
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

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

            var value1 = reader.ReadUInt32();
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

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

            var value1 = reader.ReadUInt64();
            var value2 = value1.ToEndian(endianness);
            return value2;
        }

        #endregion
    }
}
