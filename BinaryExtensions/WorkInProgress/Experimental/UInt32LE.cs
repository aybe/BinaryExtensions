using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct UInt32LE
    {
        public readonly uint Value;

        public UInt32LE(uint value)
        {
            Value = value;
        }

        public UInt32LE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadUInt32();
        }

        public static implicit operator UInt32LE(uint value)
        {
            return new UInt32LE(value);
        }

        public static implicit operator uint(UInt32LE value)
        {
            return value.Value.ToEndian(Endianness.LittleEndian);
        }

        public override string ToString()
        {
            return ((uint) this).ToString();
        }
    }
}