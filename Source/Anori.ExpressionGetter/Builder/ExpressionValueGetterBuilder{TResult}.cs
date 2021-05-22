// -----------------------------------------------------------------------
// <copyright file="ExpressionValueGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Builder
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionGetters.Interfaces.Builder;

    /// <summary>
    ///     The Expression Value Getter Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal class ExpressionValueGetterBuilder<TResult> : IValueGetterBuilder<TResult>,
                                                           IGetterBuilderWithFallback<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TResult>> expression;

        /// <summary>
        ///     The fallback.
        /// </summary>
        private TResult fallbackResult;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionValueGetterBuilder{TResult}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionValueGetterBuilder(Expression<Func<TResult>> expression)
        {
            this.expression = expression;
        }

        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder With Fallback.</returns>
        public IGetterBuilderWithFallback<TResult> WithFallback(TResult fallback)
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
        Func<TResult> IGetterBuilderWithFallback<TResult>.Build() =>
            Anori.ExpressionGetters.ExpressionGetter.CreateGetter(this.expression, this.fallbackResult);

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TResult?> IValueGetterBuilder<TResult>.Build() => Anori.ExpressionGetters.ExpressionGetter.CreateValueGetter(this.expression);
    }
}