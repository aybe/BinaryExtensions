using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct Int32LE
    {
        public readonly int Value;

        public Int32LE(int value)
        {
            Value = value;
        }

        public Int32LE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadInt32();
        }

        public static implicit operator Int32LE(int value)
        {
            return new Int32LE(value);
        }

        public static implicit operator int(Int32LE value)
        {
            return value.Value.ToEndian(Endianness.LittleEndian);
        }

        public override string ToString()
        {
            return ((int) this).ToString();
        }
    }
}