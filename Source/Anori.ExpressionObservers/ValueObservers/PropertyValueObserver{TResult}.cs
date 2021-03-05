// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserver{TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase{TResult}" />
    public sealed class PropertyValueObserver<TResult> : PropertyObserverBase<PropertyValueObserver<TResult>, TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The action is null.</exception>
        internal PropertyValueObserver([NotNull] Expression<Func<TResult>> propertyExpression, [NotNull] Action action)
            : base(propertyExpression) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <summary>
        ///     On th action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}