namespace BinaryExtensions
{
    /// <summary>
    ///     Specifies the byte order for an integral type.
    /// </summary>
    public enum Endianness
    {
        /// <summary>
        ///     Platform endianness.
        /// </summary>
        Native,

        /// <summary>
        ///     Big-endian, i.e. MSB.
        /// </summary>
        BigEndian,

        /// <summary>
        ///     Little-endian, i.e. LSB.
        /// </summary>
        LittleEndian
    }
}