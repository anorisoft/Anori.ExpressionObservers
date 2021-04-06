﻿// -----------------------------------------------------------------------
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
    /// <seealso cref="PropertyObserverBase{TSelf}" />
    internal sealed class PropertyObserver<TResult> : PropertyObserverBase<PropertyObserver<TResult>, TResult>,
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
        ///     Initializes a new instance of the <see cref="PropertyObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="System.ArgumentNullException">The action is null.</exception>
        internal PropertyObserver([NotNull] Expression<Func<TResult>> propertyExpression, [NotNull] Action action)
            : base(propertyExpression) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Subscribes this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> IPropertyObserverBase<IPropertyObserver<TResult>>.Subscribe() => this.Subscribe();

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> IPropertyObserverBase<IPropertyObserver<TResult>>.Subscribe(bool silent) =>
            this.Subscribe(silent);

        /// <summary>
        ///     Unsubscribes this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> IPropertyObserverBase<IPropertyObserver<TResult>>.Unsubscribe() =>
            this.Unsubscribe();
    }
}