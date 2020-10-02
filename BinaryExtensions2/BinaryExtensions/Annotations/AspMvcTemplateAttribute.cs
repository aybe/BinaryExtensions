using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     ASP.NET MVC attribute. Indicates that a parameter is an MVC template.
    ///     Use this attribute for custom wrappers similar to
    ///     <c>System.ComponentModel.DataAnnotations.UIHintAttribute(System.String)</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcTemplateAttribute : Attribute
    {
    }
}