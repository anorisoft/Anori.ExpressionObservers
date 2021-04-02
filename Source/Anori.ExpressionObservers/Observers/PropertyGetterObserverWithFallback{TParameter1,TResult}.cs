// -----------------------------------------------------------------------
// <copyright file="PropertyGetterObserverWithFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    /// Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.Observers.PropertyGetterObserverWithFallback{TParameter1, TResult}, TParameter1, TResult}" />
    /// <seealso cref="IPropertyObserverWithFallback{TResult}" />
    public sealed class PropertyObserverWithFallback<TParameter1, TResult> :
        PropertyObserverBase<PropertyObserverWithFallback<TParameter1, TResult>, TParameter1, TResult>,
        IPropertyObserverWithFallback<TResult>
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <exception cref="ArgumentNullException">action or propertyExpression is null.</exception>
        internal PropertyObserverWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            TResult fallback)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = () =>
                ExpressionGetter.CreateGetter<TParameter1, TResult>(propertyExpression.Parameters, this.Tree, fallback)(
                    parameter1);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult Value => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        IPropertyObserverWithFallback<TResult>
            IPropertyObserverBase<IPropertyObserverWithFallback<TResult>>.Subscribe() =>
            this.Subscribe();

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>
        ///     Self object.
        /// </returns>
        IPropertyObserverWithFallback<TResult>
            IPropertyObserverBase<IPropertyObserverWithFallback<TResult>>.Subscribe(bool silent) =>
            this.Subscribe(silent);

        /// <summary>
        ///     Unsubscribes this instance.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        IPropertyObserverWithFallback<TResult>
            IPropertyObserverBase<IPropertyObserverWithFallback<TResult>>.Unsubscribe() =>
            this.Unsubscribe();
    }
}