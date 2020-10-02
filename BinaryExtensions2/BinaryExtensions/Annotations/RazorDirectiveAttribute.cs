using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class RazorDirectiveAttribute : Attribute
    {
        public RazorDirectiveAttribute([NotNull] string directive)
        {
            Directive = directive;
        }

        [NotNull] public string Directive { get; }
    }
}