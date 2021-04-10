// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverWithGetter{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
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
    ///     Property Value Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    internal sealed class PropertyValueObserverWithGetter<TResult> :
        PropertyObserverBase<IPropertyValueObserverWithGetter<TResult>, TResult>,
        IPropertyValueObserverWithGetter<TResult>
        where TResult : struct
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
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree);
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
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{ TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree);
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
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{ TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree);
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
        /// <returns>
        ///     The result value.
        /// </returns>
        public TResult? Value => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>The Getter.</returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateValueGetter<TResult>(propertyExpression.Parameters, tree);
    }
}