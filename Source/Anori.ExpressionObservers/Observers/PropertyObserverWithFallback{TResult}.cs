// -----------------------------------------------------------------------
// <copyright file="PropertyObserverWithFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyGetterObserverWithFallback{TParameter1,TParameter2,TResult}" />
    /// <seealso cref="PropertyObserverBase" />
    internal sealed class PropertyObserverWithFallback<TResult> :
        PropertyObserverBase<IPropertyObserverWithFallback<TResult>, TResult>,
        IPropertyObserverWithFallback<TResult>
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverWithFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action or propertyExpression is null.</exception>
        internal PropertyObserverWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, fallback);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                this.getter = () => this.IsActive ? get() : throw new NotActivatedException();
            }
            else
            {
                this.getter = get;
            }

        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverWithFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyObserverWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            TaskScheduler taskScheduler,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, fallback);
            var taskFactory = new TaskFactory(taskScheduler);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                this.getter = () => this.IsActive ? taskFactory.StartNew(get).Result : throw new NotActivatedException();
            }
            else
            {
                this.getter = () => taskFactory.StartNew(get).Result;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverWithFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyObserverWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            SynchronizationContext synchronizationContext,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, fallback);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                this.getter = () => this.IsActive ? synchronizationContext.Send(get) : throw new NotActivatedException();
            }
            else
            {
                this.getter = () => synchronizationContext.Send(get);
            }
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult Value => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        private static Func<TResult> Getter(
            Expression<Func<TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback) =>
            ExpressionGetter.CreateGetter(propertyExpression.Parameters, tree, fallback);
    }
}