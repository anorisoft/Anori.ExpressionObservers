// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnPropertyChanged
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionGetters;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionAndCachedGetterAndFallback<TParameter1, TResult> :
        ObserverBase<IGetterPropertyObserver<TResult>, TParameter1, TResult>,
        IGetterPropertyObserver<TResult>
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
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                propertyExpression,
                taskScheduler,
                fallback,
                false,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithActionAndCachedGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1), taskScheduler),
                isCached,
                safetyMode);
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : this(
                parameter1,
                propertyExpression,
                synchronizationContext,
                fallback,
                false,
                LazyThreadSafetyMode.None,
                observerFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag) =>
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1), synchronizationContext),
                isCached,
                safetyMode);

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, propertyExpression, fallback, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndCachedGetterAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithActionAndCachedGetterAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1)),
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
        /// <param name="fallback">The fallback.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback,
            TParameter1 parameter1)
        {
            var get = ExpressionGetter.CreateGetterByTree<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback!);
            return () => get(parameter1);
        }
    }
}