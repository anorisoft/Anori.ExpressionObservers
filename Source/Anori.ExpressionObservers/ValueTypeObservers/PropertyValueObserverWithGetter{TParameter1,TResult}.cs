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

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Tree;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.ValueTypeObservers.PropertyValueObserverWithGetter{TParameter1, TResult}}" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class
        PropertyValueObserverWithGetter<TParameter1, TResult> : PropertyObserverBase<
            PropertyValueObserverWithGetter<TParameter1, TResult>>
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
        /// <exception cref="ArgumentNullException">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyValueObserverWithGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            this.ExpressionString = propertyExpression.ToString();
            this.CreateChain(parameter1, tree);
            this.getter = () =>
                ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, tree)(
                    parameter1);
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