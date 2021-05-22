﻿// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndDeferrer{TParameter1,TResult}.cs" company="AnoriSoft">
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

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
        using Anori.ExpressionGetters;using Anori.ExpressionGetters.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverBase{TSelf,TResult}" />
    internal sealed class ObserverWithActionAndDeferrer<TParameter1, TResult> :
        ObserverBase<IGetterReferencePropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        IGetterReferencePropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : class
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
        ///     The getValue.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.getValue = Getter(propertyExpression, this.Tree, parameter1);
            this.deferrer = new UpdateableMultipleDeferrer(() => action(this.getValue()));
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.getValue = this.CreateGetter(Getter(propertyExpression, this.Tree, parameter1), taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(() => action(this.getValue()));
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is Null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.getValue = this.CreateGetter(
                Getter(propertyExpression, this.Tree, parameter1),
                synchronizationContext);
            this.deferrer = new UpdateableMultipleDeferrer(() => action(this.getValue()));
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
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? GetValue() => this.getValue();

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>The Getter.</returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1)
        {
            var get = ExpressionGetter.CreateReferenceGetterByTree<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree);
            return () => get(parameter1);
        }
    }
}