using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspChildControlTypeAttribute : Attribute
    {
        public AspChildControlTypeAttribute([NotNull] string tagName, [NotNull] Type controlType)
        {
            TagName = tagName;
            ControlType = controlType;
        }

        [NotNull] public string TagName { get; }

        [NotNull] public Type ControlType { get; }
    }
}