﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TParameter1,TResult}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer Base.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    public abstract class PropertyObserverBase<TParameter1, TResult> : PropertyObserverBase
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBase{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     propertyExpression
        ///     or
        ///     parameter1 in null.
        /// </exception>
        protected PropertyObserverBase(
            TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.Parameter1 = parameter1 ?? throw new ArgumentNullException(nameof(parameter1));
            this.ExpressionString = this.CreateChain(parameter1);
        }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
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
        ///     Creates the chain.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>The Expression String.</returns>
        /// <exception cref="NotSupportedException">
        ///     Operation not supported for the given expression type {expression.Type}. "
        ///     + "Only MemberExpression and ConstantExpression are currently supported.
        /// </exception>
        private string CreateChain(TParameter1 parameter1)
        {
            var tree = ExpressionTree.GetTree(this.propertyExpression.Body);
            var expressionString = this.propertyExpression.ToString();

            this.CreateChain(parameter1, tree);

            return expressionString;
        }
    }
}