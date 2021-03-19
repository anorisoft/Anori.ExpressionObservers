// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverWithGetter{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    public sealed class
        PropertyValueObserverWithGetter<TResult> : PropertyObserverBase<PropertyValueObserverWithGetter<TResult>,
            TResult>
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
        /// <exception cref="ArgumentNullException">
        ///     action is null.
        /// </exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            : base(propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = ExpressionGetter.CreateValueGetter<TResult>(propertyExpression.Parameters, this.Tree);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>
        ///     The result value.
        /// </returns>
        public TResult? GetValue() => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}