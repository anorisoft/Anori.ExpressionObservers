// -----------------------------------------------------------------------
// <copyright file="ExpressionReferenceGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    /// The Expression Reference Getter Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IReferenceGetterBuilder{TParameter1,TResult}" />
    internal class ExpressionReferenceGetterBuilder<TResult> : IReferenceGetterBuilder<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TResult>> expression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionReferenceGetterBuilder{TResult}" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionReferenceGetterBuilder(Expression<Func<TResult>> expression) => this.expression = expression;

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TResult?> IReferenceGetterBuilder<TResult>.Create() =>
            ExpressionGetter.CreateReferenceGetter(this.expression);
    }
}