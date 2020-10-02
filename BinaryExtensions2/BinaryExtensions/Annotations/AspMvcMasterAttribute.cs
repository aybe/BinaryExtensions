using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     ASP.NET MVC attribute. Indicates that a parameter is an MVC Master. Use this attribute
    ///     for custom wrappers similar to <c>System.Web.Mvc.Controller.View(String, String)</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcMasterAttribute : Attribute
    {
    }
}