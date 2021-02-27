using System;
using System.Linq.Expressions;
using Anori.ExpressionObservers.Observers;
using JetBrains.Annotations;

namespace Anori.ExpressionObservers.ReferenceObservers
{
    public sealed class PropertyReferenceObserverWithGetterAndFallback<TResult> : PropertyObserverBase
        where TResult : class
    {
        /// <summary>
        /// The action
        /// </summary>
        [NotNull] private readonly Action action;
        /// <summary>
        /// The getter
        /// </summary>
        [NotNull] private readonly Func<TResult> getter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceObserverWithGetterAndFallback{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <exception cref="System.ArgumentNullException">
        /// action
        /// or
        /// propertyExpression
        /// </exception>
        /// <exception cref="ArgumentNullException">action
        /// or
        /// propertyExpression</exception>
        internal PropertyReferenceObserverWithGetterAndFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action, TResult fallback)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            ExpressionString = propertyExpression.ToString();
            CreateChain(tree);
            this.getter = ExpressionGetter.CreateReferenceGetter(propertyExpression.Parameters, tree, fallback);
        }

        /// <summary>
        /// The action
        /// </summary>
        protected override void OnAction() => action();


        /// <summary>
        /// The expression
        /// </summary>
        public override string ExpressionString { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        public TResult GetValue() => getter();
    }
}