// -----------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The type extensions class.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     Ares the type of the methods equal for declaring.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static bool AreMethodsEqualForDeclaringType(this MethodInfo first, MethodInfo second)
        {
            first = first.ReflectedType == first.DeclaringType
                        ? first
                        : first.DeclaringType.GetMethod(
                            first.Name,
                            first.GetParameters().Select(p => p.ParameterType).ToArray());
            second = second.ReflectedType == second.DeclaringType
                         ? second
                         : second.DeclaringType.GetMethod(
                             second.Name,
                             second.GetParameters().Select(p => p.ParameterType).ToArray());
            return first == second;
        }

        /// <summary>
        ///     Gets the indexers.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetIndexers(this Type type) =>
            type.GetProperties().Where(p => p.GetIndexParameters().Length > 0).ToList();

        /// <summary>
        ///     Determines whether the specified method information is indexer.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="methodInfo">The method information.</param>
        /// <returns>
        ///     <c>true</c> if the specified method information is indexer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsIndexer(this Type type, MethodInfo methodInfo) =>
            GetIndexers(type).Any(i => AreMethodsEqualForDeclaringType(i.GetMethod, methodInfo));

        /// <summary>
        ///     Determines whether the specified method call expression is indexer.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        /// <returns>
        ///     <c>true</c> if the specified method call expression is indexer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsIndexer(this Type type, MethodCallExpression methodCallExpression) =>
            type.IsIndexer(methodCallExpression.Method);

        /// <summary>
        ///     Gets the interface method.
        /// </summary>
        /// <param name="implementingClass">The implementing class.</param>
        /// <param name="implementedInterface">The implemented interface.</param>
        /// <param name="classMethod">The class method.</param>
        /// <returns></returns>
        private static MethodInfo GetInterfaceMethod(
            this Type implementingClass,
            Type implementedInterface,
            MethodInfo classMethod)
        {
            var map = implementingClass.GetInterfaceMap(implementedInterface);
            var index = Array.IndexOf(map.TargetMethods, classMethod);
            return map.InterfaceMethods[index];
        }
    }
}