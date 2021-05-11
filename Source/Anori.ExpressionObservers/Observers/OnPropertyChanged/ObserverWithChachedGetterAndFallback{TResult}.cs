﻿// -----------------------------------------------------------------------
// <copyright file="ObserverWithChachedGetterAndFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnPropertyChanged
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
    ///     cref="PropertyReferenceObserverOnNotifyPropertyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class ObserverWithChachedGetterAndFallback<TResult> :
        ObserverBase<IGetterPropertyObserver<TResult>, TResult>,
        IGetterPropertyObserver<TResult>
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
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithChachedGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithChachedGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, taskScheduler, fallback, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithChachedGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithChachedGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback), taskScheduler),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithChachedGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithChachedGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : this(propertyExpression, synchronizationContext, fallback, false, LazyThreadSafetyMode.None, observerFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithChachedGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithChachedGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback), synchronizationContext),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithChachedGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithChachedGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, fallback, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithChachedGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithChachedGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback)),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult GetValue() => this.getter();

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
        private static Func<TResult> Getter(
            Expression<Func<TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback) =>
            ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, tree, fallback!);
    }
}