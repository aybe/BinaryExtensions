using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class RazorInjectionAttribute : Attribute
    {
        public RazorInjectionAttribute([NotNull] string type, [NotNull] string fieldName)
        {
            Type = type;
            FieldName = fieldName;
        }

        [NotNull] public string Type { get; }

        [NotNull] public string FieldName { get; }
    }
}