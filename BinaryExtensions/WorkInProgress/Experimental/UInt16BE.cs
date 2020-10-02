using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct UInt16BE
    {
        public readonly ushort Value;

        public UInt16BE(ushort value)
        {
            Value = value;
        }

        public UInt16BE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadUInt16();
        }

        public static implicit operator UInt16BE(ushort value)
        {
            return new UInt16BE(value);
        }

        public static implicit operator ushort(UInt16BE value)
        {
            return value.Value.ToEndian(Endianness.BigEndian);
        }

        public override string ToString()
        {
            return ((ushort) this).ToString();
        }
    }
}