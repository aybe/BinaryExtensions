using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates how method, constructor invocation or property access
    ///     over collection type affects content of the collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Property)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class CollectionAccessAttribute : Attribute
    {
        public CollectionAccessAttribute(CollectionAccessType collectionAccessType)
        {
            CollectionAccessType = collectionAccessType;
        }

        public CollectionAccessType CollectionAccessType { get; }
    }
}