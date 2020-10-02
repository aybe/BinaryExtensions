using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class RazorImportNamespaceAttribute : Attribute
    {
        public RazorImportNamespaceAttribute([NotNull] string name)
        {
            Name = name;
        }

        [NotNull] public string Name { get; }
    }
}