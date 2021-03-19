// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverWithGetter{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.ValueTypeObservers.PropertyValueObserverWithGetter{TParameter1, TParameter2, TResult}, TParameter1, TParameter2, TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.ValueTypeObservers.PropertyValueObserverWithGetter{TParameter1, TParameter2, TResult}}" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyValueObserverWithGetter<TParameter1, TParameter2, TResult> : PropertyObserverBase<
        PropertyValueObserverWithGetter<TParameter1, TParameter2, TResult>, TParameter1, TParameter2, TResult>
        where TResult : struct
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
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
        /// Initializes a new instance of the <see cref="PropertyValueObserverWithGetter{TParameter1,TParameter2,TResult}" />
        /// class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">action or propertyExpression is null.</exception>
        internal PropertyValueObserverWithGetter(
            TParameter1 parameter1,
            TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action action)
            : base(parameter1, parameter2, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = () => ExpressionGetter.CreateValueGetter<TParameter1, TParameter2, TResult>(propertyExpression.Parameters, this.Tree)(parameter1, parameter2);
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