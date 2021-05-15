// -----------------------------------------------------------------------
// <copyright file="ExpressionReferenceGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.ExpressionGetter
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Expression Reference Getter Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal class ExpressionReferenceGetterBuilder<TResult> : IReferenceGetterBuilder<TResult>,
                                                               IGetterBuilderWithFallback<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TResult>> expression;

        /// <summary>
        ///     The fallback result.
        /// </summary>
        private TResult? fallbackResult;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionReferenceGetterBuilder{TResult}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionReferenceGetterBuilder(Expression<Func<TResult>> expression) => this.expression = expression;

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TResult?> IReferenceGetterBuilder<TResult>.Build() =>
            Anori.ExpressionObservers.ExpressionGetter.CreateReferenceGetter(this.expression);

        /// <summary>
        ///     Creates this instance of a getter function.
        /// </summary>
        /// <returns>
        ///     The getter function.
        /// </returns>
        Func<TResult> IGetterBuilderWithFallback<TResult>.Build() =>
            Anori.ExpressionObservers.ExpressionGetter.CreateGetter(this.expression, this.fallbackResult!);

        /// <summary>
        ///     Getter Builder with Fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Getter Builder with Fallback.
        /// </returns>
        IGetterBuilderWithFallback<TResult> IReferenceGetterBuilder<TResult>.WithFallback(TResult fallback)
        {
            this.fallbackResult = fallback;
            return this;
        }
    }
}