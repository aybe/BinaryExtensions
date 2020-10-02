using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct Int16LE
    {
        public readonly short Value;

        public Int16LE(short value)
        {
            Value = value;
        }

        public Int16LE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadInt16();
        }

        public static implicit operator Int16LE(short value)
        {
            return new Int16LE(value);
        }

        public static implicit operator short(Int16LE value)
        {
            return value.Value.ToEndian(Endianness.LittleEndian);
        }

        public override string ToString()
        {
            return ((short) this).ToString();
        }
    }
}