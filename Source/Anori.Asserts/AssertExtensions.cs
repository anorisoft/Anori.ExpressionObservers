// -----------------------------------------------------------------------
// <copyright file="AssertExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Asserts
{
    using System;

    using NUnit.Framework;

    public static class AssertExtensions
    {
        /// <summary>
        /// Determines whether [is type assignable from] [the specified expected].
        /// </summary>
        /// <param name="expected">The expected.</param>
        /// <param name="type">The type.</param>
        public static void IsTypeAssignableFrom(Type expected, Type type)
        {
            Assert.IsTrue(
                expected.IsAssignableFrom(type),
                $"Type {expected.Name} is not assignable from Type {type.Name}");
        }

        /// <summary>
        /// Determines whether [is type assignable from] [the specified type].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        public static void IsTypeAssignableFrom<T>(Type type)
        {
            IsTypeAssignableFrom(typeof(T), type);
        }
    }
}