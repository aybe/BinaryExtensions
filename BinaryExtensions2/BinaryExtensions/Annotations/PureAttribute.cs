﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that a method does not make any observable state changes.
    ///     The same as <c>System.Diagnostics.Contracts.PureAttribute</c>.
    /// </summary>
    /// <example>
    ///     <code>
    /// [Pure] int Multiply(int x, int y) => x * y;
    /// 
    /// void M() {
    ///   Multiply(123, 42); // Waring: Return value of pure method is not used
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Method)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class PureAttribute : Attribute
    {
    }
}