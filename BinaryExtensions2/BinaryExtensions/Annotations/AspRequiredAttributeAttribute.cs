using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspRequiredAttributeAttribute : Attribute
    {
        public AspRequiredAttributeAttribute([NotNull] string attribute)
        {
            Attribute = attribute;
        }

        [NotNull] public string Attribute { get; }
    }
}