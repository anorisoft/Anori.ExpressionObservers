// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndGetterAndFallbackAndDeferrer{TParameter1,TResult}.cs" company="AnoriSoft">
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

    using Anori.Deferrers;
    using Anori.ExpressionGetters;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     value property observer With Getter And Fallback.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class ObserverWithActionAndGetterAndFallbackAndDeferrer<TParameter1, TResult> :
        ObserverBase<IGetterPropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        IGetterPropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
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
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndGetterAndFallbackAndDeferrer{TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     parameter1
        ///     or
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal ObserverWithActionAndGetterAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1));
            this.deferrer = new UpdateableMultipleDeferrer(action);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndGetterAndFallbackAndDeferrer{TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     parameter1
        ///     or
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal ObserverWithActionAndGetterAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1), taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(action);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndGetterAndFallbackAndDeferrer{TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     parameter1
        ///     or
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal ObserverWithActionAndGetterAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.getter = this.CreateGetter(
                Getter(propertyExpression, this.Tree, fallback, parameter1),
                synchronizationContext);
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
        ///     Gets the value.
        /// </summary>
        /// <returns>
        ///     The result value.
        /// </returns>
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
        /// <returns>Getter.</returns>
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