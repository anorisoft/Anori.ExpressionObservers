// -----------------------------------------------------------------------
// <copyright file="PropertyObserverWithGetterAndFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter And Fallback.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    public sealed class
        PropertyObserverWithGetterAndFallback<TResult> : PropertyObserverBase<
            PropertyObserverWithGetterAndFallback<TResult>, TResult>
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverWithGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <exception cref="ArgumentNullException">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyObserverWithGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            TResult fallback)
            : base(propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));

            this.getter = ExpressionGetter.CreateGetter(propertyExpression.Parameters, this.Tree, fallback);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult GetValue() => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}