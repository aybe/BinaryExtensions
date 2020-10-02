using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct UInt32BE
    {
        public readonly uint Value;

        public UInt32BE(uint value)
        {
            Value = value;
        }

        public UInt32BE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadUInt32();
        }

        public static implicit operator UInt32BE(uint value)
        {
            return new UInt32BE(value);
        }

        public static implicit operator uint(UInt32BE value)
        {
            return value.Value.ToEndian(Endianness.BigEndian);
        }

        public override string ToString()
        {
            return ((uint) this).ToString();
        }
    }
}