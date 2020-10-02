using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     ASP.NET MVC attribute. Indicates that a parameter is an MVC area.
    ///     Use this attribute for custom wrappers similar to
    ///     <c>System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper, String)</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class AspMvcAreaAttribute : Attribute
    {
        public AspMvcAreaAttribute()
        {
        }

        public AspMvcAreaAttribute([NotNull] string anonymousProperty)
        {
            AnonymousProperty = anonymousProperty;
        }

        [CanBeNull] public string AnonymousProperty { get; }
    }
}