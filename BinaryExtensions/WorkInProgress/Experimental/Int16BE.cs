using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct Int16BE
    {
        public readonly short Value;

        public Int16BE(short value)
        {
            Value = value;
        }

        public Int16BE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadInt16();
        }

        public static implicit operator Int16BE(short value)
        {
            return new Int16BE(value);
        }

        public static implicit operator short(Int16BE value)
        {
            return value.Value.ToEndian(Endianness.BigEndian);
        }

        public override string ToString()
        {
            return ((short) this).ToString();
        }
    }
}