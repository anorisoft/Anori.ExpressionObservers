// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceGetterObserver{TParameter1,TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase{TParameter1, TResult}" />
    public sealed class
        PropertyReferenceGetterObserver<TParameter1, TResult> 
        : PropertyObserverBase<PropertyReferenceGetterObserver<TParameter1, TResult>, TParameter1, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : class
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
        private readonly Func<TParameter1, TResult> getter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceGetterObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="System.ArgumentNullException">The action is null.</exception>
        internal PropertyReferenceGetterObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = ExpressionGetter.CreateReferenceGetter(propertyExpression);
        }

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter(this.Parameter1));
    }
}