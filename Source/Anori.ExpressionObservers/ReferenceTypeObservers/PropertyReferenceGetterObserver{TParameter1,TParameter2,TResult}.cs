// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceGetterObserver{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase{TSelf,TParameter1,TResult}" />
    public sealed class PropertyReferenceGetterObserver<TParameter1, TParameter2, TResult> : PropertyObserverBase<
        PropertyReferenceGetterObserver<TParameter1, TParameter2, TResult>, TParameter1, TParameter2, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceGetterObserver{TParameter1,TParameter2,TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The action is null.</exception>
        internal PropertyReferenceGetterObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult> action)
            : base(parameter1, parameter2, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = () =>
                ExpressionGetter.CreateReferenceGetter<TParameter1, TParameter2, TResult>(
                    propertyExpression.Parameters,
                    this.Tree)(parameter1, parameter2);
        }

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());
    }
}