// this file was auto-generated
using System;
using System.IO;

namespace BinaryExtensions
{
    public static partial class EndiannessExtensions
    {
        /// <summary>Reads a 16-bit signed integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="EndOfStreamException">Not enough bytes to read the integer from current position.</exception>
        public static Int16 ReadInt16(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(Int16) > reader.BaseStream.Length)
                throw new EndOfStreamException();

            var value = reader.ReadInt16();

            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        }

        /// <summary>Reads a 32-bit signed integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="EndOfStreamException">Not enough bytes to read the integer from current position.</exception>
        public static Int32 ReadInt32(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(Int32) > reader.BaseStream.Length)
                throw new EndOfStreamException();

            var value = reader.ReadInt32();

            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        }

        /// <summary>Reads a 64-bit signed integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="EndOfStreamException">Not enough bytes to read the integer from current position.</exception>
        public static Int64 ReadInt64(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(Int64) > reader.BaseStream.Length)
                throw new EndOfStreamException();

            var value = reader.ReadInt64();

            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        }

        /// <summary>Reads a 16-bit unsigned integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="EndOfStreamException">Not enough bytes to read the integer from current position.</exception>
        public static UInt16 ReadUInt16(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(UInt16) > reader.BaseStream.Length)
                throw new EndOfStreamException();

            var value = reader.ReadUInt16();

            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        }

        /// <summary>Reads a 32-bit unsigned integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="EndOfStreamException">Not enough bytes to read the integer from current position.</exception>
        public static UInt32 ReadUInt32(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(UInt32) > reader.BaseStream.Length)
                throw new EndOfStreamException();

            var value = reader.ReadUInt32();

            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        }

        /// <summary>Reads a 64-bit unsigned integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the stream.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="EndOfStreamException">Not enough bytes to read the integer from current position.</exception>
        public static UInt64 ReadUInt64(this BinaryReader reader, Endianness endianness)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(UInt64) > reader.BaseStream.Length)
                throw new EndOfStreamException();

            var value = reader.ReadUInt64();

            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        }

        /// <summary>Reads a 16-bit signed integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the array.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Not enough bytes to read the integer from <paramref name="index" />.</exception>
        public static Int16 ReadInt16(this byte[] array, int index, Endianness endianness)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(Int16) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var value = BitConverter.ToInt16(array, index);
            
            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        } 
         
        /// <summary>Reads a 32-bit signed integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the array.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Not enough bytes to read the integer from <paramref name="index" />.</exception>
        public static Int32 ReadInt32(this byte[] array, int index, Endianness endianness)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(Int32) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var value = BitConverter.ToInt32(array, index);
            
            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        } 
         
        /// <summary>Reads a 64-bit signed integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the array.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Not enough bytes to read the integer from <paramref name="index" />.</exception>
        public static Int64 ReadInt64(this byte[] array, int index, Endianness endianness)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(Int64) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var value = BitConverter.ToInt64(array, index);
            
            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        } 
         
        /// <summary>Reads a 16-bit unsigned integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the array.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Not enough bytes to read the integer from <paramref name="index" />.</exception>
        public static UInt16 ReadUInt16(this byte[] array, int index, Endianness endianness)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(UInt16) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var value = BitConverter.ToUInt16(array, index);
            
            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        } 
         
        /// <summary>Reads a 32-bit unsigned integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the array.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Not enough bytes to read the integer from <paramref name="index" />.</exception>
        public static UInt32 ReadUInt32(this byte[] array, int index, Endianness endianness)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(UInt32) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var value = BitConverter.ToUInt32(array, index);
            
            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        } 
         
        /// <summary>Reads a 64-bit unsigned integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <returns>The integer read from the array.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Not enough bytes to read the integer from <paramref name="index" />.</exception>
        public static UInt64 ReadUInt64(this byte[] array, int index, Endianness endianness)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(UInt64) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var value = BitConverter.ToUInt64(array, index);
            
            return endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
        } 
         
        
        /// <summary>Tries to read a 16-bit signed integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from stream; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        public static bool TryReadInt16(this BinaryReader reader, Endianness endianness, out Int16 result)
        {
            result = default;
            
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(Int16) > reader.BaseStream.Length)
                return false;

            var value = reader.ReadInt16(endianness);

            result = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);

            return true;
        }
        
        
        /// <summary>Tries to read a 32-bit signed integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from stream; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        public static bool TryReadInt32(this BinaryReader reader, Endianness endianness, out Int32 result)
        {
            result = default;
            
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(Int32) > reader.BaseStream.Length)
                return false;

            var value = reader.ReadInt32(endianness);

            result = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);

            return true;
        }
        
        
        /// <summary>Tries to read a 64-bit signed integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from stream; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        public static bool TryReadInt64(this BinaryReader reader, Endianness endianness, out Int64 result)
        {
            result = default;
            
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(Int64) > reader.BaseStream.Length)
                return false;

            var value = reader.ReadInt64(endianness);

            result = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);

            return true;
        }
        
        
        /// <summary>Tries to read a 16-bit unsigned integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from stream; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        public static bool TryReadUInt16(this BinaryReader reader, Endianness endianness, out UInt16 result)
        {
            result = default;
            
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(UInt16) > reader.BaseStream.Length)
                return false;

            var value = reader.ReadUInt16(endianness);

            result = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);

            return true;
        }
        
        
        /// <summary>Tries to read a 32-bit unsigned integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from stream; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        public static bool TryReadUInt32(this BinaryReader reader, Endianness endianness, out UInt32 result)
        {
            result = default;
            
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(UInt32) > reader.BaseStream.Length)
                return false;

            var value = reader.ReadUInt32(endianness);

            result = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);

            return true;
        }
        
        
        /// <summary>Tries to read a 64-bit unsigned integer from current stream.</summary>
        /// <param name="reader">The source binary reader.</param>
        /// <param name="endianness">The endianness of the integer.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from stream; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
        public static bool TryReadUInt64(this BinaryReader reader, Endianness endianness, out UInt64 result)
        {
            result = default;
            
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if (reader.BaseStream.Position + sizeof(UInt64) > reader.BaseStream.Length)
                return false;

            var value = reader.ReadUInt64(endianness);

            result = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);

            return true;
        }
        
       
        /// <summary>Tries to read a 16-bit signed integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer to read.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from array; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        public static bool TryReadInt16(this byte[] array, int index, Endianness endianness, out Int16 result)
        {
            result = default;

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(Int16) > array.Length)
                return false;
            
            var value = BitConverter.ToInt16(array, index);
            
            value = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
            
            return true;
        }
       
        /// <summary>Tries to read a 32-bit signed integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer to read.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from array; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        public static bool TryReadInt32(this byte[] array, int index, Endianness endianness, out Int32 result)
        {
            result = default;

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(Int32) > array.Length)
                return false;
            
            var value = BitConverter.ToInt32(array, index);
            
            value = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
            
            return true;
        }
       
        /// <summary>Tries to read a 64-bit signed integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer to read.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from array; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        public static bool TryReadInt64(this byte[] array, int index, Endianness endianness, out Int64 result)
        {
            result = default;

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(Int64) > array.Length)
                return false;
            
            var value = BitConverter.ToInt64(array, index);
            
            value = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
            
            return true;
        }
       
        /// <summary>Tries to read a 16-bit unsigned integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer to read.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from array; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        public static bool TryReadUInt16(this byte[] array, int index, Endianness endianness, out UInt16 result)
        {
            result = default;

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(UInt16) > array.Length)
                return false;
            
            var value = BitConverter.ToUInt16(array, index);
            
            value = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
            
            return true;
        }
       
        /// <summary>Tries to read a 32-bit unsigned integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer to read.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from array; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        public static bool TryReadUInt32(this byte[] array, int index, Endianness endianness, out UInt32 result)
        {
            result = default;

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(UInt32) > array.Length)
                return false;
            
            var value = BitConverter.ToUInt32(array, index);
            
            value = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
            
            return true;
        }
       
        /// <summary>Tries to read a 64-bit unsigned integer from this array.</summary>
        /// <param name="array">The source array.</param>
        /// <param name="index">The position to read the integer from <paramref name="array"/>.</param>
        /// <param name="endianness">The endianness of the integer to read.</param>
        /// <param name="result">The variable receiving the integer.</param>
        /// <returns><c>true</c> if the integer was read from array; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is <c>null</c>.</exception>
        public static bool TryReadUInt64(this byte[] array, int index, Endianness endianness, out UInt64 result)
        {
            result = default;

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index + sizeof(UInt64) > array.Length)
                return false;
            
            var value = BitConverter.ToUInt64(array, index);
            
            value = endianness == Endianness || endianness == Endianness.Native ? value : ReverseEndianness(value);
            
            return true;
        }
    }
}
