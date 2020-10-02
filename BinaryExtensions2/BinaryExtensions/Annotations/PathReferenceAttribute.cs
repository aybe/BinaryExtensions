using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that a parameter is a path to a file or a folder within a web project.
    ///     Path can be relative or absolute, starting from web root (~).
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class PathReferenceAttribute : Attribute
    {
        public PathReferenceAttribute()
        {
        }

        public PathReferenceAttribute([NotNull] [PathReference] string basePath)
        {
            BasePath = basePath;
        }

        [CanBeNull] public string BasePath { get; }
    }
}