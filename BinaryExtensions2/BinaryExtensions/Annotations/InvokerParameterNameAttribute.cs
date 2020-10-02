﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that the function argument should be string literal and match one
    ///     of the parameters of the caller function. For example, ReSharper annotates
    ///     the parameter of <see cref="System.ArgumentNullException" />.
    /// </summary>
    /// <example>
    ///     <code>
    /// void Foo(string param) {
    ///   if (param == null)
    ///     throw new ArgumentNullException("par"); // Warning: Cannot resolve symbol
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class InvokerParameterNameAttribute : Attribute
    {
    }
}