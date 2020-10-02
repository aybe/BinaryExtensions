﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that the value of the marked element could never be <c>null</c>.
    /// </summary>
    /// <example>
    ///     <code>
    /// [NotNull] object Foo() {
    ///   return null; // Warning: Possible 'null' assignment
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property |
        AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event |
        AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.GenericParameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class NotNullAttribute : Attribute
    {
    }
}