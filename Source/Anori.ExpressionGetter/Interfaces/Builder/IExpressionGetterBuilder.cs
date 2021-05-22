// -----------------------------------------------------------------------
// <copyright file="IExpressionGetterBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Interfaces.Builder
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionGetters.Interfaces.Builder;

    /// <summary>
    ///     The expression getter builder interface.
    /// </summary>
    public interface IExpressionGetterBuilder
    {
        /// <summary>
        ///     Expression getter builder for reference type with two parameters.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The reference type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The reference type expression getter builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TParameter2, TResult> ReferenceGetter<TParameter1, TParameter2, TResult>(
            Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Expression getter builder for reference type with three parameters.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The reference type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The reference type expression getter builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>
            ReferenceGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Expression getter builder for reference type with one parameter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The reference type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The reference type expression getter builder.
        /// </returns>
        IReferenceGetterBuilder<TParameter1, TResult> ReferenceGetter<TParameter1, TResult>(
            Expression<Func<TParameter1, TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Expression getter builder for reference type.
        /// </summary>
        /// <typeparam name="TResult">The reference type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The reference type expression getter builder.
        /// </returns>
        IReferenceGetterBuilder<TResult> ReferenceGetter<TResult>(Expression<Func<TResult>> expression)
            where TResult : class;

        /// <summary>
        ///     Expression getter builder for value type with one parameter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The value type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The value type expression getter builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TResult> ValueGetter<TParameter1, TResult>(
            Expression<Func<TParameter1, TResult>> expression)
            where TResult : struct;

        /// <summary>
        ///     Expression getter builder for value type with two parameters.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The value type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The value type expression expression getter builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TParameter2, TResult> ValueGetter<TParameter1, TParameter2, TResult>(
            Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : struct;

        /// <summary>
        ///     Expression getter builder for value type with three parameters.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The value type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The value type expression getter builder.
        /// </returns>
        IValueGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>
            ValueGetter<TParameter1, TParameter2, TParameter3, TResult>(
                Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : struct;

        /// <summary>
        ///     Expression getter builder for value.
        /// </summary>
        /// <typeparam name="TResult">The value type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The value type expression getter builder.
        /// </returns>
        IValueGetterBuilder<TResult> ValueGetter<TResult>(Expression<Func<TResult>> expression)
            where TResult : struct;
    }
}