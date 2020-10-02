using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter
    ///     is an MVC view component view. If applied to a method, the MVC view component view name is default.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcViewComponentViewAttribute : Attribute
    {
    }
}