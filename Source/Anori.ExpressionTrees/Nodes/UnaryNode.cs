// -----------------------------------------------------------------------
// <copyright file="UnaryNode.cs" company="AnoriSoft">
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
    ///     Unary Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class UnaryNode : IInternalExpressionNode, IUnaryNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnaryNode" /> struct.
        /// </summary>
        /// <param name="unaryExpression">The unary expression.</param>
        public UnaryNode([NotNull] UnaryExpression unaryExpression)
        {
            this.UnaryExpression = unaryExpression;
            this.Operand = null!;
            this.Type = unaryExpression.Type;
            this.Parameter = null;
            this.Result = null;
        }

        /// <summary>
        ///     Gets the unary expression.
        /// </summary>
        /// <value>
        ///     The unary expression.
        /// </value>
        public UnaryExpression UnaryExpression { get; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type { get; }

        /// <summary>
        ///     Gets or sets the operand.
        /// </summary>
        /// <value>
        ///     The operand.
        /// </value>
        public IExpressionNode Operand { get; set; }

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
                if (this.Operand != null)
                {
                    yield return this.Operand;
                }
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