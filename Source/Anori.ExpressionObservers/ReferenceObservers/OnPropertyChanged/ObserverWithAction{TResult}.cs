﻿// -----------------------------------------------------------------------
// <copyright file="ObserverWithAction{TResult}.cs" company="AnoriSoft">
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
        using Anori.ExpressionGetters;using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Getter Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class ObserverWithAction<TResult> :
        ObserverBase<IGetterReferencePropertyObserver<TResult>, TResult>,
        IGetterReferencePropertyObserver<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult?> action;

        /// <summary>
        ///     The getValue.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getValue =
                ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getValue = this.CreateGetter(Getter(propertyExpression, this.Tree), taskScheduler);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getValue = this.CreateGetter(Getter(propertyExpression, this.Tree), synchronizationContext);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? GetValue() => this.getValue();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action(this.getValue());

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree)
        {
            var get = ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, tree);
            return () => get();
        }
    }
}