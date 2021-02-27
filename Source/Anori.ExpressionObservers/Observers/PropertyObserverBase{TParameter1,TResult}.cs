﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Anori.ExpressionObservers.Observers
{
    public abstract class PropertyObserverBase<TParameter1, TResult> : PropertyObserverBase
        where TParameter1 : INotifyPropertyChanged
    {

        /// <summary>
        ///     The property expression
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        protected PropertyObserverBase(
            TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.Parameter1 = parameter1 ?? throw new ArgumentNullException(nameof(parameter1));
            this.ExpressionString = this.CreateChain(parameter1);
        }

        /// <summary>
        ///     The expression
        /// </summary>
        public override string ExpressionString { get; }

        /// <summary>
        ///     Gets the parameter1.
        /// </summary>
        /// <value>
        ///     The parameter1.
        /// </value>
        [CanBeNull]
        public TParameter1 Parameter1 { get; }

        /// <summary>
        /// Creates the chain.
        /// </summary>
        /// <param name="owner">The parameter1.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">Operation not supported for the given expression type {expression.Type}. "
        ///                     + "Only MemberExpression and ConstantExpression are currently supported.</exception>
        private string CreateChain(TParameter1 parameter1)
        {
            var tree = ExpressionTree.GetTree(this.propertyExpression.Body);
            var expressionString = propertyExpression.ToString();

            base.CreateChain(parameter1, tree);

            return expressionString;
        }
    }
}