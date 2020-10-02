using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     ASP.NET MVC attribute. Indicates that a parameter is an MVC model type. Use this attribute
    ///     for custom wrappers similar to <c>System.Web.Mvc.Controller.View(String, Object)</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcModelTypeAttribute : Attribute
    {
    }
}