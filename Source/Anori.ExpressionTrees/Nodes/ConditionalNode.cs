// -----------------------------------------------------------------------
// <copyright file="ConditionalNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Conditional Node.
    /// </summary>
    /// <seealso cref="IExpressionNode" />
    internal class ConditionalNode : IInternalExpressionNode, IConditionalNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConditionalNode" /> struct.
        /// </summary>
        /// <param name="conditionalExpression">The conditional expression.</param>
        public ConditionalNode([NotNull] ConditionalExpression conditionalExpression)
        {
            this.ConditionalExpression = conditionalExpression;
            this.Test = null!;
            this.IfTrue = null!;
            this.IfFalse = null!;
            this.Type = conditionalExpression.Type;
            this.Parameter = null;
            this.Result = null;
        }

        /// <summary>
        ///     Gets the conditional expression.
        /// </summary>
        /// <value>
        ///     The conditional expression.
        /// </value>
        public ConditionalExpression ConditionalExpression { get; }

        /// <summary>
        ///     Gets or sets the test.
        /// </summary>
        /// <value>
        ///     The test.
        /// </value>
        public IExpressionNode Test { get; set; }

        /// <summary>
        ///     Gets or sets if true.
        /// </summary>
        /// <value>
        ///     If true.
        /// </value>
        public IExpressionNode IfTrue { get; set; }

        /// <summary>
        ///     Gets or sets if false.
        /// </summary>
        /// <value>
        ///     If false.
        /// </value>
        public IExpressionNode IfFalse { get; set; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type { get; }

        /// <summary>
        ///     Gets the previous.
        /// </summary>
        /// <value>
        ///     The previous.
        /// </value>
        public IExpressionNode? Parameter { get; private set; }

        public IEnumerable<IExpressionNode> ParameterNotes
        {
            get
            {
                yield return this.Test;
                yield return this.IfTrue;
                yield return this.IfFalse;
            }
        }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Result { get; private set; }

        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetParameter(IExpressionNode? node) => this.Parameter = node;

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetResult(IExpressionNode? node) => this.Result = node;
    }
}