// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverWithGetter{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.ValueTypeObservers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.ReferenceTypeObservers.PropertyReferenceObserverWithGetter{TParameter1, TResult}, TParameter1, TResult}" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyReferenceObserverWithGetter<TParameter1, TResult> : PropertyObserverBase<
        PropertyReferenceObserverWithGetter<TParameter1, TResult>, TParameter1, TResult>
        where TResult : class
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
        private readonly Func<TParameter1, TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverWithGetter{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">actionis null.</exception>
        /// <exception cref="PropertyValueObserverWithGetter{TParameter1,TResult}">
        ///     action
        ///     or
        ///     propertyExpression is null.
        /// </exception>
        internal PropertyReferenceObserverWithGetter(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = ExpressionGetter.CreateReferenceGetter<TParameter1, TResult>(
                propertyExpression.Parameters,
                this.Tree);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult Value => this.getter(this.Parameter1);

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();
    }
}