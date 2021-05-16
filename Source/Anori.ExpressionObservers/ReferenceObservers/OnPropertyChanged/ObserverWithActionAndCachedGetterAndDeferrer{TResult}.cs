// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndCachedGetterAndDeferrer{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionAndCachedGetterAndDeferrer<TResult> :
        ObserverBase<IGetterReferencePropertyObserverWithDeferrer<TResult>, TResult>,
        IGetterReferencePropertyObserverWithDeferrer<TResult>
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
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The getValue.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndCachedGetterAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            TaskScheduler taskScheduler,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, action, taskScheduler, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndCachedGetterAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithActionAndCachedGetterAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TaskScheduler taskScheduler,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            Action updateAction;
            (updateAction, this.getValue) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree), taskScheduler),
                isCached,
                safetyMode,
                action);
            this.deferrer = new UpdateableMultipleDeferrer(updateAction);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndCachedGetterAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] SynchronizationContext synchronizationContext,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            Action updateAction;
            (updateAction, this.getValue) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree), synchronizationContext),
                isCached,
                safetyMode,
                action);
            this.deferrer = new UpdateableMultipleDeferrer(updateAction);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndCachedGetterAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, action, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndCachedGetterAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            Action updateAction;
            (updateAction, this.getValue) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree)),
                isCached,
                safetyMode,
                action);
            this.deferrer = new UpdateableMultipleDeferrer(updateAction);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Gets a Reference indicating whether this instance is deferred.
        /// </summary>
        /// <Reference>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </Reference>
        public bool IsDeferred => this.deferrer.IsDeferred;

        /// <summary>
        ///     Gets the Reference.
        /// </summary>
        /// <returns>The result.</returns>
        public TResult? GetValue() => this.getValue();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>Getter.</returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, tree);
    }
}