﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Tells code analysis engine if the parameter is completely handled when the invoked method is on stack.
    ///     If the parameter is a delegate, indicates that delegate is executed while the method is executed.
    ///     If the parameter is an enumerable, indicates that it is enumerated while the method is executed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class InstantHandleAttribute : Attribute
    {
    }
}