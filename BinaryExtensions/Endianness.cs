// ReSharper disable once CheckNamespace

namespace System.IO
{
    /// <summary>
    ///     Defines the byte order.
    /// </summary>
    public enum Endianness
    {
        /// <summary>
        ///     Big-endian byte order.
        /// </summary>
        BigEndian,

        /// <summary>
        ///     Little-endian byte order.
        /// </summary>
        LittleEndian,

        /// <summary>
        /// Platform byte order.
        /// </summary>
        Native
    }
}