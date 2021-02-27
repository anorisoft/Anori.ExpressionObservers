using System;
using System.ComponentModel;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Anori.ExpressionObservers.ValueObservers
{
    public sealed class PropertyValueGetterObserver<TParameter1, TParameter2, TResult> : PropertyValueObserverBase<TParameter1, TParameter2, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        /// The getter
        /// </summary>
        private readonly Func<TParameter1, TParameter2, TResult?> getter;

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [NotNull] private readonly Action<TResult?> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueGetterObserver{TParameter1, TParameter2, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">action</exception>
        internal PropertyValueGetterObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action) : base(parameter1, parameter2, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            getter = ExpressionGetter.CreateValueGetter(propertyExpression);
        }

        /// <summary>
        /// The action
        /// </summary>
        protected override void OnAction() => action(getter(Parameter1, Parameter2));
    }
}