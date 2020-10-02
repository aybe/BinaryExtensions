using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that the marked method is assertion method, i.e. it halts control flow if
    ///     one of the conditions is satisfied. To set the condition, mark one of the parameters with
    ///     <see cref="AssertionConditionAttribute" /> attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AssertionMethodAttribute : Attribute
    {
    }
}