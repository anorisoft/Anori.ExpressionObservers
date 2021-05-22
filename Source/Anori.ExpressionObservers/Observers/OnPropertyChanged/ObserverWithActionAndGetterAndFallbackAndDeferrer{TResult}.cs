// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndGetterAndFallbackAndDeferrer{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnPropertyChanged
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionGetters;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     value property observer With Getter And Fallback.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionAndGetterAndFallbackAndDeferrer<TResult> :
        ObserverBase<IGetterPropertyObserverWithDeferrer<TResult>, TResult>,
        IGetterPropertyObserverWithDeferrer<TResult>
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
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndGetterAndFallbackAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal ObserverWithActionAndGetterAndFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.deferrer = new UpdateableMultipleDeferrer(action);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndGetterAndFallbackAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">parameter1 or action or propertyExpression is null.</exception>
        internal ObserverWithActionAndGetterAndFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback), taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(action);
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndGetterAndFallbackAndDeferrer{TResult}" /> class.
        /// </summary>
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
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback), synchronizationContext);
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
        ///     Gets the value.
        /// </summary>
        /// <returns>The result.</returns>
        public TResult GetValue() => this.getter();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The getter.
        /// </returns>
        private static Func<TResult> Getter(
            Expression<Func<TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback)
        {
            var get = ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, tree, fallback!);
            return () => get();
        }
    }
}