// -----------------------------------------------------------------------
// <copyright file="ExpressionValueGetterBuilder{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.ExpressionGetter
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Expression Value Getter Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IValueGetterBuilder{TParameter1,TResult}" />
    /// <seealso cref="IGetterBuilderWithFallback{TParameter1,TResult}" />
    internal class ExpressionValueGetterBuilder<TParameter1, TResult> : IValueGetterBuilder<TParameter1, TResult>,
                                                                        IGetterBuilderWithFallback<TParameter1, TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> expression;

        /// <summary>
        ///     The fallback.
        /// </summary>
        private TResult fallbackResult;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionValueGetterBuilder{TParameter, TResult}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionValueGetterBuilder(Expression<Func<TParameter1, TResult>> expression)
        {
            this.expression = expression;
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder With Fallback.</returns>
        public IGetterBuilderWithFallback<TParameter1, TResult> WithFallback(TResult fallback)
        {
            this.fallbackResult = fallback;
            return this;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TParameter1, TResult> IGetterBuilderWithFallback<TParameter1, TResult>.Build() =>
            Anori.ExpressionObservers.ExpressionGetter.CreateGetter(this.expression, this.fallbackResult);

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TParameter1, TResult?> IValueGetterBuilder<TParameter1, TResult>.Build() =>
            Anori.ExpressionObservers.ExpressionGetter.CreateValueGetter(this.expression);
    }
}