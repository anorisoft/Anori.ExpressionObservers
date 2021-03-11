// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverWithGetterAndFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter And Fallback.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyValueObserverWithGetterAndFallback<TParameter1, TResult> : PropertyObserverBase<
        PropertyValueObserverWithGetterAndFallback<TParameter1, TResult>>
        where TResult : struct where TParameter1 : INotifyPropertyChanged
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
        private readonly Func<TParameter1, TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverWithGetterAndFallback{TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     parameter
        ///     or
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyValueObserverWithGetterAndFallback(
            [NotNull] TParameter1 parameter,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            TResult fallback)
        {
            this.Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            this.ExpressionString = propertyExpression.ToString();

            this.CreateChain(parameter, tree);
            this.getter = ExpressionGetter.CreateValueGetter<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback);
        }

        /// <summary>
        ///     Gets the parameter.
        /// </summary>
        /// <value>
        ///     The parameter.
        /// </value>
        public TParameter1 Parameter { get; }

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
        /// <returns>
        ///     The result value.
        /// </returns>
        public TResult GetValue() => this.getter(this.Parameter);

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}