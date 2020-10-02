using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Prevents the Member Reordering feature from tossing members of the marked class.
    /// </summary>
    /// <remarks>
    ///     The attribute must be mentioned in your member reordering patterns
    /// </remarks>
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Enum)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class NoReorderAttribute : Attribute
    {
    }
}