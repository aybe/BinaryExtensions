using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspDataFieldAttribute : Attribute
    {
    }
}