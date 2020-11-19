using System;
using BinaryExtensions.Annotations;

namespace BinaryExtensions
{
    /// <summary>
    ///     Extension methods for integral types.
    /// </summary>
    [PublicAPI]
    public static class IntegralTypesExtensions
    {
        /// <summary>
        ///     Converts this integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <returns>
        ///     The integer as a 32-bit signed integer.
        /// </returns>
        public static int ToInt32(this long value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     Converts this integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <returns>
        ///     The integer as a 32-bit signed integer.
        /// </returns>
        public static int ToInt32(this uint value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     Converts this integer to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">
        ///     The integer to convert.
        /// </param>
        /// <returns>
        ///     The integer as a 32-bit signed integer.
        /// </returns>
        public static int ToInt32(this ulong value)
        {
            return Convert.ToInt32(value);
        }
    }
}