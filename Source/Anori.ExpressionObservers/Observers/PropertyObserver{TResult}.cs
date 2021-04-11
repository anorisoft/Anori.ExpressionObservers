// -----------------------------------------------------------------------
// <copyright file="PropertyObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverFundatinBase{TSelf}" />
    internal sealed class PropertyObserver<TResult> : PropertyObserverBase<IPropertyObserver<TResult>, TResult>,
                                                      IPropertyObserver<TResult>
    {
        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        [NotNull]
        private readonly Action action;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">The action is null.</exception>
        internal PropertyObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}