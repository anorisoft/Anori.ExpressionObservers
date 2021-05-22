// -----------------------------------------------------------------------
// <copyright file="ExpressionValueGetterBuilder{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal class ExpressionValueGetterBuilder<TParameter1, TParameter2, TResult> :
        IValueGetterBuilder<TParameter1, TParameter2, TResult>,
        IGetterBuilderWithFallback<TParameter1, TParameter2, TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TParameter2, TResult>> expression;

        /// <summary>
        ///     The fallback.
        /// </summary>
        private TResult fallbackResult;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionValueGetterBuilder{TParameter,TParameter2,TResult}" />
        ///     class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionValueGetterBuilder(Expression<Func<TParameter1, TParameter2, TResult>> expression) =>
            this.expression = expression;

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The getter.</returns>
        Func<TParameter1, TParameter2, TResult> IGetterBuilderWithFallback<TParameter1, TParameter2, TResult>.Build() =>
            Anori.ExpressionGetters.ExpressionGetter.CreateGetter(this.expression, this.fallbackResult);

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The getter.</returns>
        Func<TParameter1, TParameter2, TResult?> IValueGetterBuilder<TParameter1, TParameter2, TResult>.Build() =>
            Anori.ExpressionGetters.ExpressionGetter.CreateValueGetter(this.expression);

        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder With Fallback.</returns>
        IGetterBuilderWithFallback<TParameter1, TParameter2, TResult>
            IValueGetterBuilder<TParameter1, TParameter2, TResult>.WithFallback(TResult fallback)
        {
            this.fallbackResult = fallback;
            return this;
        }
    }
}