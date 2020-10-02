using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     For a parameter that is expected to be one of the limited set of values.
    ///     Specify fields of which type should be used as values for this parameter.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field,
        AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class ValueProviderAttribute : Attribute
    {
        public ValueProviderAttribute([NotNull] string name)
        {
            Name = name;
        }

        [NotNull] public string Name { get; }
    }
}