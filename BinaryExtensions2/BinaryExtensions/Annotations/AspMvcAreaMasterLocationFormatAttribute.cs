using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcAreaMasterLocationFormatAttribute : Attribute
    {
        public AspMvcAreaMasterLocationFormatAttribute([NotNull] string format)
        {
            Format = format;
        }

        [NotNull] public string Format { get; }
    }
}