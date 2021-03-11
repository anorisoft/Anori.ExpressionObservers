// -----------------------------------------------------------------------
// <copyright file="ReferenceGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     Reference Getter.
    /// </summary>
    public static class ReferenceGetter
    {
        /// <summary>
        ///     Creates the getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>Reference Getter.</returns>
        public static Func<TParameter, TResult> CreateGetter<TParameter, TResult>(
            Expression<Func<TParameter, TResult>> propertyExpression)
            where TResult : class
        {
            return ExpressionGetter.CreateReferenceGetter(propertyExpression);
        }
    }
}