// -----------------------------------------------------------------------
// <copyright file="PropertyValueGetterObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    public sealed class
        PropertyValueGetterObserver<TResult> : PropertyObserverBase<PropertyValueGetterObserver<TResult>>
        where TResult : struct
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
        ///     Initializes a new instance of the <see cref="PropertyValueGetterObserver{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyValueGetterObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            this.ExpressionString = propertyExpression.ToString();

            this.CreateChain(tree);
            this.getter = ExpressionGetter.CreateValueGetter<TResult>(propertyExpression.Parameters, tree);
        }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public override string ExpressionString { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? GetValue() => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());
    }
}