using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class HtmlElementAttributesAttribute : Attribute
    {
        public HtmlElementAttributesAttribute()
        {
        }

        public HtmlElementAttributesAttribute([NotNull] string name)
        {
            Name = name;
        }

        [CanBeNull] public string Name { get; }
    }
}