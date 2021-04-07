// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Getter Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    internal sealed class
        PropertyReferenceObserver<TResult> : PropertyObserverBase<IPropertyReferenceObserver<TResult>, TResult>, IPropertyReferenceObserver<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult?> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyReferenceObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            : base(propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, this.Tree);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceObserver{TResult}"/> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyReferenceObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            TaskScheduler taskScheduler)
            : base(propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree);
            var taskFactory = new TaskFactory(taskScheduler);
            this.getter = () => taskFactory.StartNew(get).Result;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyReferenceObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            SynchronizationContext synchronizationContext)
            : base(propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree);
            this.getter = () => synchronizationContext.Send(get);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? Value => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree);
    }
}