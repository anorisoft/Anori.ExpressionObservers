// -----------------------------------------------------------------------
// <copyright file="ExpressionGetterBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.ExpressionGetter
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The expression getter builder class.
    ///     The builder creates a function of <see cref="Func{TResult}" />, which allow a safe access to the value of an
    ///     expression. The execution doesn't throw a NullReferenceException, it returns null or a predefined fallback. The
    ///     throwing
    ///     of an exception is very expensive, the ExpressionGetter creates an alternative express where possible null values
    ///     are
    ///     checked.
    /// </summary>
    /// <seealso cref="IExpressionGetterBuilder" />
    public class ExpressionGetterBuilder : IExpressionGetterBuilder
    {
        /// <summary>
        ///     Gets the default expression getter builder <see cref="ExpressionGetterBuilder" />.
        /// </summary>
        /// <value>
        ///     The builder.
        /// </value>
        public static IExpressionGetterBuilder Builder { get; } = new ExpressionGetterBuilder();

        /// <summary>
        ///     Builds a reference getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Reference Getter Builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TParameter2, TResult> IExpressionGetterBuilder.
            ReferenceGetter<TParameter1, TParameter2, TResult>(
                Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : class =>
            new ExpressionReferenceGetterBuilder<TParameter1, TParameter2, TResult>(expression);

        /// <summary>
        ///     Builds a reference getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Reference Getter Builder.
        /// </returns>
        IReferenceGetterBuilder<TResult> IExpressionGetterBuilder.ReferenceGetter<TResult>(
            Expression<Func<TResult>> expression)
            where TResult : class =>
            new ExpressionReferenceGetterBuilder<TResult>(expression);

        /// <summary>
        ///     Builds a reference getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TParameter2, TParameter3, TResult> IExpressionGetterBuilder.
            ReferenceGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : class =>
            new ExpressionReferenceGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>(expression);

        /// <summary>
        ///     Builds a reference getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>Reference Getter Builder.</returns>
        IReferenceGetterBuilder<TParameter1, TResult> IExpressionGetterBuilder.ReferenceGetter<TParameter1, TResult>(
            Expression<Func<TParameter1, TResult>> expression)
            where TResult : class =>
            new ExpressionReferenceGetterBuilder<TParameter1, TResult>(expression);

        /// <summary>
        ///     Builds a value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TParameter2, TParameter3, TResult> IExpressionGetterBuilder.
            ValueGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression) =>
            new ExpressionValueGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>(expression);

        /// <summary>
        ///     Builds a value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TResult> IExpressionGetterBuilder.
            ValueGetter<TResult>(Expression<Func<TResult>> expression) =>
            new ExpressionValueGetterBuilder<TResult>(expression);

        /// <summary>
        ///     Builds a value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TResult> IExpressionGetterBuilder.ValueGetter<TParameter1, TResult>(
            Expression<Func<TParameter1, TResult>> expression)
            where TResult : struct =>
            new ExpressionValueGetterBuilder<TParameter1, TResult>(expression);

        /// <summary>
        ///     Builds a value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The Value Getter Builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TParameter2, TResult> IExpressionGetterBuilder.
            ValueGetter<TParameter1, TParameter2, TResult>(
                Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : struct =>
            new ExpressionValueGetterBuilder<TParameter1, TParameter2, TResult>(expression);
    }
}