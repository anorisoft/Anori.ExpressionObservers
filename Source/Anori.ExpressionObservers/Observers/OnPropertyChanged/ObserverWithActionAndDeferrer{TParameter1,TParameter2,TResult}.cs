// -----------------------------------------------------------------------
// <copyright file="ObserverWithAction{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnPropertyChanged
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverBase{TSelf,TParameter1,TResult}" />
    internal sealed class ObserverWithActionAndDeferrer<TParameter1, TParameter2, TResult> :
        ObserverBase<IPropertyObserverWithDeferrer<TResult>, TParameter1, TParameter2, TResult>,
        IPropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The deferrer.
        /// </summary>
        [NotNull]
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">The Action in null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.deferrer = new UpdateableMultipleDeferrer(action);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeferred => this.deferrer.IsDeferred;

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     The on action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}