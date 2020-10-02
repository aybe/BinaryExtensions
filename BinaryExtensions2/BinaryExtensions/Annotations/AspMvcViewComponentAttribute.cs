using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter
    ///     is an MVC view component name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcViewComponentAttribute : Attribute
    {
    }
}