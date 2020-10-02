using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that the return value of method invocation must be used.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class MustUseReturnValueAttribute : Attribute
    {
        public MustUseReturnValueAttribute()
        {
        }

        public MustUseReturnValueAttribute([NotNull] string justification)
        {
            Justification = justification;
        }

        [CanBeNull] public string Justification { get; }
    }
}