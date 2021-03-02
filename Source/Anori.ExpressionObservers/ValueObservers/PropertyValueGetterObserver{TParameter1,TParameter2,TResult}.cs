﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueGetterObserver{TParameter1,TParameter2,TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase{TParameter1, TParameter2, TResult}" />
    public sealed class
        PropertyValueGetterObserver<TParameter1, TParameter2, TResult> : PropertyObserverBase<TParameter1, TParameter2,
            TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        [NotNull]
        private readonly Action<TResult?> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TParameter1, TParameter2, TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueGetterObserver{TParameter1, TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The action is null.</exception>
        internal PropertyValueGetterObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            : base(parameter1, parameter2, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = ExpressionGetter.CreateValueGetter(propertyExpression);
        }

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter(this.Parameter1, this.Parameter2));
    }
}