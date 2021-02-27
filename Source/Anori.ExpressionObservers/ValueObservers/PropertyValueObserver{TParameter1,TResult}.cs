﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Anori.ExpressionObservers.ValueObservers
{
    public sealed class PropertyValueObserver<TParameter1, TResult> : PropertyValueObserverBase<TParameter1, TResult> where TParameter1 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [NotNull] public Action Action { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserver{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">action</exception>
        internal PropertyValueObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action) : base(parameter1, propertyExpression)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// The action
        /// </summary>
        protected override void OnAction() => Action();
    }
}