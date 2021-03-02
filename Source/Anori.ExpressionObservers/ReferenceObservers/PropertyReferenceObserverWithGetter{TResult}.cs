﻿// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverWithGetter{TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ValueObservers;

    using JetBrains.Annotations;

    /// <summary>
    /// Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    public sealed class PropertyReferenceObserverWithGetter<TResult> : PropertyObserverBase
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
        private readonly Func<TResult> getter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceObserverWithGetter{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="PropertyValueObserverWithGetter{TResult}">action
        /// or
        /// propertyExpression is null.</exception>
        internal PropertyReferenceObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            this.ExpressionString = propertyExpression.ToString();

            this.CreateChain(tree);
            this.getter = ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree);
        }

        /// <summary>
        /// Gets the expression string.
        /// </summary>
        /// <value>
        /// The expression string.
        /// </value>
        public override string ExpressionString { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult GetValue() => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}