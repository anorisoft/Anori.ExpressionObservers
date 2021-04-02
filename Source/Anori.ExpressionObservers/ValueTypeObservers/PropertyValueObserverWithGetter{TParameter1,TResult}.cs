// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverWithGetter{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Builder;
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     Property Value Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyValueObserverWithGetter{TResult}" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyValueObserverWithGetter<TParameter1, TResult> : PropertyObserverBase<
        PropertyValueObserverWithGetter<TParameter1, TResult>, TParameter1, TResult>,
        IPropertyValueObserverWithGetter<TResult>
        where TResult : struct
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
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = () =>
                ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, this.Tree)(
                    parameter1);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>
        ///     The result value.
        /// </returns>
        public TResult? Value => this.getter();

        /// <summary>
        /// On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        TResult? IPropertyValueObserverWithGetter<TResult>.Value => this.Value;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        /// Self object.
        /// </returns>
        IPropertyValueObserverWithGetter<TResult> IPropertyObserverBase<IPropertyValueObserverWithGetter<TResult>>.Subscribe() => this.Subscribe();

        /// <summary>
        /// Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>
        /// Self object.
        /// </returns>
        IPropertyValueObserverWithGetter<TResult> IPropertyObserverBase<IPropertyValueObserverWithGetter<TResult>>.Subscribe(bool silent)
            => this.Subscribe(silent);

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <returns>
        /// Self object.
        /// </returns>
        IPropertyValueObserverWithGetter<TResult> IPropertyObserverBase<IPropertyValueObserverWithGetter<TResult>>.Unsubscribe()
            => this.Unsubscribe();
    }
}