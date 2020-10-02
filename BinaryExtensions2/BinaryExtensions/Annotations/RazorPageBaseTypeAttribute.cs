using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class RazorPageBaseTypeAttribute : Attribute
    {
        public RazorPageBaseTypeAttribute([NotNull] string baseType)
        {
            BaseType = baseType;
        }

        public RazorPageBaseTypeAttribute([NotNull] string baseType, string pageName)
        {
            BaseType = baseType;
            PageName = pageName;
        }

        [NotNull] public string BaseType { get; }
        [CanBeNull] public string PageName { get; }
    }
}