﻿// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverWithGetter{TResult}.cs" company="AnoriSoft">
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
    using Anori.ExpressionObservers.ValueTypeObservers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyObserverFundatinBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverWithGetter{TResult}, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverWithGetter{TResult}" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal sealed class PropertyReferenceObserverWithGetter<TResult> :
        PropertyObserverBase<IPropertyReferenceObserverWithGetter<TResult>, TResult>,
        IPropertyReferenceObserverWithGetter<TResult>
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
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverWithGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        /// <exception cref="PropertyValueObserverWithGetter{TResult}">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyReferenceObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree), taskScheduler);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverWithGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyReferenceObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverWithGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal PropertyReferenceObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(
                Getter(propertyExpression, this.Tree),
                synchronizationContext);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
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
            ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree);
    }
}