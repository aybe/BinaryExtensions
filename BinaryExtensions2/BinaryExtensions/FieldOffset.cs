using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    ///     Defines the type of offset to a field.
    /// </summary>
    [PublicAPI]
    public enum FieldOffset
    {
        /// <summary>
        ///     Beginning of the field.
        /// </summary>
        Begin,

        /// <summary>
        ///     End of the field.
        /// </summary>
        End
    }
}