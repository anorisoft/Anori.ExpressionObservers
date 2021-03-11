// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase{TResult}" />
    public sealed class
        PropertyReferenceObserver<TResult> : PropertyObserverBase<PropertyReferenceObserver<TResult>, TResult>
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The action is null.</exception>
        internal PropertyReferenceObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            : base(propertyExpression) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}