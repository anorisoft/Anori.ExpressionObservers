﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserver{TParameter1,TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase{TParameter1, TResult}" />
    public sealed class PropertyObserver<TParameter1, TResult> : PropertyObserverBase<TParameter1, TResult>
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserver{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="System.ArgumentNullException">The action is null.</exception>
        internal PropertyObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            : base(parameter1, propertyExpression) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}