// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer Base.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    public abstract class PropertyObserverBase<TResult> : PropertyObserverBase
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBase{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        protected PropertyObserverBase([NotNull] Expression<Func<TResult>> propertyExpression)
        {
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.ExpressionString = this.CreateChain();
        }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public override string ExpressionString { get; }

        /// <summary>
        ///     Creates the chain.
        /// </summary>
        /// <param name="owner">The parameter1.</param>
        /// <returns>The Expression String.</returns>
        /// <exception cref="NotSupportedException">
        ///     Operation not supported for the given expression type {expression.Type}. "
        ///     + "Only MemberExpression and ConstantExpression are currently supported.
        /// </exception>
        protected string CreateChain()
        {
            var tree = ExpressionTree.GetTree(this.propertyExpression.Body);
            var expressionString = this.propertyExpression.ToString();

            this.CreateChain(tree);

            return expressionString;
        }
    }
}