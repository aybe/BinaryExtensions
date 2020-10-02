using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that marked element should be localized or not.
    /// </summary>
    /// <example>
    ///     <code>
    /// [LocalizationRequiredAttribute(true)]
    /// class Foo {
    ///   string str = "my string"; // Warning: Localizable string
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.All)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class LocalizationRequiredAttribute : Attribute
    {
        public LocalizationRequiredAttribute() : this(true)
        {
        }

        public LocalizationRequiredAttribute(bool required)
        {
            Required = required;
        }

        public bool Required { get; }
    }
}