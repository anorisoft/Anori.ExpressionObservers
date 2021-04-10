// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverWithGetter{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyValueObserverWithGetter{TResult}" />
    /// <seealso cref="PropertyObserverBase" />
    internal sealed class PropertyValueObserverWithGetter<TParameter1, TResult> :
        PropertyObserverBase<IPropertyValueObserverWithGetter<TResult>, TParameter1, TResult>,
        IPropertyValueObserverWithGetter<TResult>
        where TResult : struct
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
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, parameter1);
            var taskFactory = new TaskFactory(taskScheduler);
            this.getter = () => taskFactory.StartNew(get).Result;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = Getter(propertyExpression, this.Tree, parameter1);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, parameter1);
            this.getter = () => synchronizationContext.Send(get);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>
        ///     The result value.
        /// </returns>
        public TResult? Value => this.getter();

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult? IPropertyValueObserverWithGetter<TResult>.Value => this.Value;

        /// <summary>
        ///     On the action.
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
            TParameter1 parameter1) =>
            () => ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, tree)(
                parameter1);
    }
}