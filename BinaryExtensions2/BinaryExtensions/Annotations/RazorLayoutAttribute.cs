using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class RazorLayoutAttribute : Attribute
    {
    }
}