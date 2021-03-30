// -----------------------------------------------------------------------
// <copyright file="ExpressionGetterBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     The Expression Getter Builder class.
    /// </summary>
    /// <seealso cref="IExpressionGetterBuilder" />
    public class ExpressionGetterBuilder : IExpressionGetterBuilder
    {
        /// <summary>
        ///     Gets the builder.
        /// </summary>
        /// <value>
        ///     The builder.
        /// </value>
        public static IExpressionGetterBuilder Builder { get; } = new ExpressionGetterBuilder();

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
        IReferenceGetterBuilder<TParameter1, TParameter2, TResult> IExpressionGetterBuilder.
            ReferenceGetter<TParameter1, TParameter2, TResult>(
                Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : class =>
            new ExpressionReferenceGetterBuilder<TParameter1, TParameter2, TResult>(expression);

        /// <summary>
        ///     Resources the getter.
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
        ///     References the getter.
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
        ///     Resources the getter.
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
        IValueGetterBuilder<TParameter1, TParameter2, TParameter3, TResult> IExpressionGetterBuilder.
            ValueGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression) =>
            new ExpressionValueGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>(expression);

        /// <summary>
        ///     Values the getter.
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
        ///     Values the getter.
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
        ///     Values the getter.
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