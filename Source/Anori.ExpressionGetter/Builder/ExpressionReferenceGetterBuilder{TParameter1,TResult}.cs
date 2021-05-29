﻿// -----------------------------------------------------------------------
// <copyright file="ExpressionReferenceGetterBuilder{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Builder
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionGetters.Interfaces.Builder;

    /// <summary>
    ///     The Expression Reference Getter Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal class ExpressionReferenceGetterBuilder<TParameter1, TResult> :
        IReferenceGetterBuilder<TParameter1, TResult>,
        IGetterBuilderWithFallback<TParameter1, TResult>
        where TResult : class
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> expression;

        /// <summary>
        ///     The fallback result.
        /// </summary>
        private TResult? fallbackResult;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionReferenceGetterBuilder{TParameter, TResult}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionReferenceGetterBuilder(Expression<Func<TParameter1, TResult>> expression) =>
            this.expression = expression;

        /// <summary>
        ///     Creates this instance of a getter function.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TParameter1, TResult> IGetterBuilderWithFallback<TParameter1, TResult>.Build() =>
            ExpressionGetter.CreateGetter(this.expression, this.fallbackResult!);

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TParameter1, TResult?> IReferenceGetterBuilder<TParameter1, TResult>.Build() =>
            ExpressionGetter.CreateReferenceGetter(this.expression);

        /// <summary>
        ///     Getter Builder with Fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Getter Builder with Fallback.
        /// </returns>
        IGetterBuilderWithFallback<TParameter1, TResult> IReferenceGetterBuilder<TParameter1, TResult>.WithFallback(
            TResult fallback)
        {
            this.fallbackResult = fallback;
            return this;
        }
    }
}