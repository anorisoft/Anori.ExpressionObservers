// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndChachedGetter{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="ObserverWithActionAndChachedGetter{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFundatinBase" />
    internal sealed class ObserverWithActionAndChachedGetter<TResult> :
        ObserverBase<IGetterReferencePropertyObserver<TResult>, TResult>,
        IGetterReferencePropertyObserver<TResult>
        where TResult : class
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
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndChachedGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithActionAndChachedGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, taskScheduler, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndChachedGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithActionAndChachedGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree), taskScheduler),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndChachedGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndChachedGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree), synchronizationContext),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndChachedGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithActionAndChachedGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndChachedGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndChachedGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree)),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result.</returns>
        public TResult? GetValue() => this.getter();

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