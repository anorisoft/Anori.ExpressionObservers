// -----------------------------------------------------------------------
// <copyright file="ValueGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     Value2 Getter.
    /// </summary>
    public static class ValueGetter
    {
        /// <summary>
        ///     Creates the getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>Value2 Getter.</returns>
        public static Func<TParameter, TResult?> CreateGetter<TParameter, TResult>(
            Expression<Func<TParameter, TResult>> propertyExpression)
            where TResult : struct
        {
            return ExpressionGetter.CreateValueGetter(propertyExpression);
        }
    }
}