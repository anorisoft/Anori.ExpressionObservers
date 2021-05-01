// -----------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     Type Extensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     Determines whether this instance is nullable.
        /// </summary>
        /// <typeparam name="T">The underlying nullable type.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">type is null.</exception>
        public static bool IsNullableOf<T>([NotNull] this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Nullable.GetUnderlyingType(type) == typeof(T);
        }

        /// <summary>
        ///     Determines whether [is nullable type assignable from].
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     <c>true</c> if [is nullable type assignable from] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">obj is null.</exception>
        public static bool IsNullableTypeAssignableFrom<T>([NotNull] this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var unserling = Nullable.GetUnderlyingType(obj.GetType());
            if (unserling is null)
            {
                return false;
            }

            return unserling.IsAssignableFrom(typeof(T));
        }

        /// <summary>
        ///     Determines whether this instance is nullable.
        /// </summary>
        /// <typeparam name="T">The underlying nullable type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">type is null.</exception>
        public static bool IsNullableTypeOf<T>([NotNull] this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return Nullable.GetUnderlyingType(obj.GetType()) == typeof(T);
        }
    }
}