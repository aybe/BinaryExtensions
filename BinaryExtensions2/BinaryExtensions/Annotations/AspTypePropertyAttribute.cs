using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspTypePropertyAttribute : Attribute
    {
        public AspTypePropertyAttribute(bool createConstructorReferences)
        {
            CreateConstructorReferences = createConstructorReferences;
        }

        public bool CreateConstructorReferences { get; }
    }
}