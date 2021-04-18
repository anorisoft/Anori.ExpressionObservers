// -----------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions
{
    using System;
    using System.Reflection;

    using JetBrains.Annotations;

    /// <summary>
    /// Type Extensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     Determines whether this instance is nullable.
        /// </summary>
        /// <param name="genericTypeInfo">The generic type information.</param>
        /// <returns>
        ///     <c>true</c> if the specified generic type information is nullable; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">genericTypeInfo is null.</exception>
        public static bool IsNullable([NotNull] this TypeInfo genericTypeInfo)
        {
            if (genericTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(genericTypeInfo));
            }

            return Nullable.GetUnderlyingType(genericTypeInfo) != null;
        }

        /// <summary>
        ///     Determines whether this instance is nullable.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">type is null.</exception>
        public static bool IsNullable([NotNull] this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Nullable.GetUnderlyingType(type) != null;
        }

        /// <summary>
        ///     Determines whether this instance is nullable.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>
        ///     <c>true</c> if this instance is nullable; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullable<T>() => typeof(T).IsNullable();
    }
}