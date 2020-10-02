using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Method)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class RazorHelperCommonAttribute : Attribute
    {
    }
}