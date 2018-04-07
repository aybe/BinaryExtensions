using System.IO;
using System.Runtime.InteropServices;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct UInt16LE
    {
        public readonly ushort Value;

        public UInt16LE(ushort value)
        {
            Value = value;
        }

        public UInt16LE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadUInt16();
        }

        public static implicit operator UInt16LE(ushort value)
        {
            return new UInt16LE(value);
        }

        public static implicit operator ushort(UInt16LE value)
        {
            return value.Value.ToEndian(Endianness.LittleEndian);
        }

        public override string ToString()
        {
            return ((ushort) this).ToString();
        }
    }
}