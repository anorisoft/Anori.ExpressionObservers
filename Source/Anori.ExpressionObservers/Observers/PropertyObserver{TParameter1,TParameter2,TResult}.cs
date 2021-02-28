// -----------------------------------------------------------------------
// <copyright file="PropertyObserver{TParameter1,TParameter2,TResult}.cs" company="Anori Soft">
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
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase{TParameter1, TParameter2, TResult}" />
    public sealed class
        PropertyObserver<TParameter1, TParameter2, TResult> : PropertyObserverBase<TParameter1, TParameter2, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserver{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The Action in null.</exception>
        internal PropertyObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action action)
            : base(parameter1, parameter2, propertyExpression)
        {
            this.Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        [NotNull]
        public Action Action { get; }

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.Action();
    }
}