﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverWithGetterAndFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter And Fallback.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyObserverWithGetterAndFallback<TParameter1, TResult> : PropertyObserverBase<
        PropertyObserverWithGetterAndFallback<TParameter1, TResult>, TParameter1, TResult>
        where TParameter1 : INotifyPropertyChanged
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
        private readonly Func<TParameter1, TResult> getter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyObserverWithGetterAndFallback{TParameter1, TResult}" />
        /// class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <exception cref="ArgumentNullException">parameter1
        /// or
        /// action
        /// or
        /// propertyExpression is null.</exception>
        internal PropertyObserverWithGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            TResult fallback)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));

            this.getter = ExpressionGetter.CreateGetter<TParameter1, TResult>(
                propertyExpression.Parameters,
                this.Tree,
                fallback);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>
        ///     The result value.
        /// </returns>
        public TResult GetValue() => this.getter(this.Parameter1);

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}