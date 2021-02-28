// -----------------------------------------------------------------------
// <copyright file="ValueGetter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Value Getter.
    /// </summary>
    public static class ValueGetter
    {
        /// <summary>
        /// Creates the getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>Value Getter.</returns>
        public static Func<TParameter, TResult?> CreateGetter<TParameter, TResult>(
            Expression<Func<TParameter, TResult>> propertyExpression)
            where TResult : struct
        {
            return ExpressionGetter.CreateValueGetter(propertyExpression);
        }
    }
}