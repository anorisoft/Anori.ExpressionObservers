// -----------------------------------------------------------------------
// <copyright file="ExpressionReferenceGetterBuilder{TParameter1,TParameter2,TParameter3,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    /// The Expression Reference Getter Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IReferenceGetterBuilder{TParameter1,TParameter2,TParameter3,TResult}" />
    internal class
        ExpressionReferenceGetterBuilder<TParameter1, TParameter2, TParameter3, TResult> : IReferenceGetterBuilder<
            TParameter1, TParameter2, TParameter3, TResult>
        where TResult : class
    {
        /// <summary>
        ///     The expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ExpressionReferenceGetterBuilder{TParameter,TParameter2,TParameter3,  TResult}" />
        ///     class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ExpressionReferenceGetterBuilder(
            Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression) =>
            this.expression = expression;

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TParameter1, TParameter2, TParameter3, TResult?>
            IReferenceGetterBuilder<TParameter1, TParameter2, TParameter3, TResult>.Build() =>
            ExpressionGetter.CreateReferenceGetter(this.expression);
    }
}