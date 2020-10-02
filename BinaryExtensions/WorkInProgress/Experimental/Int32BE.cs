using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public struct Int32BE
    {
        public readonly int Value;

        public Int32BE(int value)
        {
            Value = value;
        }

        public Int32BE([NotNull] BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Value = reader.ReadInt32();
        }

        public static implicit operator Int32BE(int value)
        {
            return new Int32BE(value);
        }

        public static implicit operator int(Int32BE value)
        {
            return value.Value.ToEndian(Endianness.BigEndian);
        }

        public override string ToString()
        {
            return ((int) this).ToString();
        }
    }
}