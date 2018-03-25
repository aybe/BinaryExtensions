using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System
{
    /// <summary>
    ///     Extension methods for structs.
    /// </summary>
    public static class StructExtensions
    {
        /// <summary>
        ///     Gets the offset of a field in a structure (see Remarks).
        /// </summary>
        /// <typeparam name="TStruct">
        ///     Structure type.
        /// </typeparam>
        /// <typeparam name="TField">
        ///     Field type.
        /// </typeparam>
        /// <param name="struct">
        ///     The source <c>struct</c>.
        /// </param>
        /// <param name="expression">
        ///     Expression to a field in <paramref name="struct" />.
        /// </param>
        /// <param name="offset">
        ///     Desired offset.
        /// </param>
        /// <returns>
        ///     The offset to the field.
        /// </returns>
        /// <remarks>
        ///     The structure must be blittable and have <see cref="StructLayoutAttribute" /> applied.
        /// </remarks>
        [PublicAPI]
        public static int OffsetOf<TStruct, TField>(
            this TStruct @struct, Expression<Func<TStruct, TField>> expression, FieldOffset offset = FieldOffset.Begin)
            where TStruct : struct
        {
            if (!(expression.Body is MemberExpression memberExpression))
                throw new ArgumentOutOfRangeException(nameof(expression));

            if (!(memberExpression.Member is FieldInfo fieldInfo))
                throw new ArgumentOutOfRangeException(nameof(expression));

            var offset1 = Marshal.OffsetOf<TStruct>(fieldInfo.Name);
            var offset2 = offset1.ToInt32();

            switch (offset)
            {
                case FieldOffset.Begin:
                    return offset2;
                case FieldOffset.End:
                    return offset2 + Marshal.SizeOf(fieldInfo.FieldType);
                default:
                    throw new ArgumentOutOfRangeException(nameof(offset), offset, null);
            }
        }
    }
}