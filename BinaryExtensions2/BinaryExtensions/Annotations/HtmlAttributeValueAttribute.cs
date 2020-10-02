using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class HtmlAttributeValueAttribute : Attribute
    {
        public HtmlAttributeValueAttribute([NotNull] string name)
        {
            Name = name;
        }

        [NotNull] public string Name { get; }
    }
}