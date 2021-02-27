using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Anori.ExpressionObservers.Observers
{
    public sealed class PropertyObserver<TResult> : PropertyObserverBase<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueObservers.PropertyObserver{TResult}"/> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">action</exception>
        internal PropertyObserver(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action) : base(propertyExpression)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [NotNull]
        public Action Action { get; }

        /// <summary>
        /// The action
        /// </summary>
        protected override void OnAction() => Action();
    }
}