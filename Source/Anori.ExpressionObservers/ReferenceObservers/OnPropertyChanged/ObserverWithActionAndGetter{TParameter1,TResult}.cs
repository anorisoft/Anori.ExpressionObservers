// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndGetter{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="ObserverWithActionAndGetter{TResult}" />
    /// <seealso cref="ObserverFundatinBase" />
    internal sealed class ObserverWithActionAndGetter<TParameter1, TResult> :
        ObserverBase<IGetterReferencePropertyObserver<TResult>, TParameter1, TResult>,
        IGetterReferencePropertyObserver<TResult>
        where TResult : class
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
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="action">The property expression.</param>
        /// <param name="taskScheduler">The action.</param>
        /// <param name="observerFlag">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ObserverWithActionAndGetter{TParameter1,TResult}">actionis null.</exception>
        /// <exception cref="ObserverWithActionAndGetter{TResult}">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal ObserverWithActionAndGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(
                Getter(propertyExpression, this.Tree, parameter1),
                taskScheduler);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="action">The property expression.</param>
        /// <param name="observerFlag">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ObserverWithActionAndGetter{TResult}">action is null.</exception>
        internal ObserverWithActionAndGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree, parameter1));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="action">The property expression.</param>
        /// <param name="synchronizationContext">The action.</param>
        /// <param name="observerFlag">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ObserverWithActionAndGetter{TResult}">action is null.</exception>
        internal ObserverWithActionAndGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(
                Getter(propertyExpression, this.Tree, parameter1),
                synchronizationContext);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? GetValue() => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1) =>
            () => ExpressionGetter.CreateReferenceGetterByTree<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree)(parameter1);
    }
}