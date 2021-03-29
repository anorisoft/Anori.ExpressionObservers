// -----------------------------------------------------------------------
// <copyright file="IExpressionGetterBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     The Expression Getter Builder interface.
    /// </summary>
    public interface IExpressionGetterBuilder
    {
        /// <summary>
        ///     Resources the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Reference Getter Builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TParameter2, TResult> ReferenceGetter<TParameter1, TParameter2, TResult>(
            Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     References the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Reference Getter Builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>
            ReferenceGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Resources the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The Reference Getter Builder.</returns>
        IReferenceGetterBuilder<TParameter1, TResult> ReferenceGetter<TParameter1, TResult>(
            Expression<Func<TParameter1, TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Resources the getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The Reference Getter Builder.</returns>
        IReferenceGetterBuilder<TResult> ReferenceGetter<TResult>(Expression<Func<TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Values the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The Value Getter Builder.</returns>
        IValueGetterBuilder<TParameter1, TResult> ValueGetter<TParameter1, TResult>(
            Expression<Func<TParameter1, TResult>> expression)
            where TResult : struct;

        /// <summary>
        ///     Values the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TParameter2, TResult> ValueGetter<TParameter1, TParameter2, TResult>(
            Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : struct;

        /// <summary>
        ///     Values the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>
            ValueGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : struct;

        /// <summary>
        ///     Values the getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TResult> ValueGetter<TResult>(Expression<Func<TResult>> expression)
            where TResult : struct;
    }
}