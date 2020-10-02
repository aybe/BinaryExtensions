﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that the marked method builds string by format pattern and (optional) arguments.
    ///     Parameter, which contains format string, should be given in constructor. The format string
    ///     should be in <see cref="string.Format(IFormatProvider,string,object[])" />-like form.
    /// </summary>
    /// <example>
    ///     <code>
    /// [StringFormatMethod("message")]
    /// void ShowError(string message, params object[] args) { /* do something */ }
    /// 
    /// void Foo() {
    ///   ShowError("Failed: {0}"); // Warning: Non-existing argument in format string
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Constructor | AttributeTargets.Method |
        AttributeTargets.Property | AttributeTargets.Delegate)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class StringFormatMethodAttribute : Attribute
    {
        /// <param name="formatParameterName">
        ///     Specifies which parameter of an annotated method should be treated as format-string
        /// </param>
        public StringFormatMethodAttribute([NotNull] string formatParameterName)
        {
            FormatParameterName = formatParameterName;
        }

        [NotNull] public string FormatParameterName { get; }
    }
}