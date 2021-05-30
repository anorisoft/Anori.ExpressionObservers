﻿// -----------------------------------------------------------------------
// <copyright file="UnaryNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System;
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
            this.Previous = null;
            this.Next = null;
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
        public IExpressionNode? Previous { get; private set; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Next { get; private set; }

        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetPrevious(IExpressionNode? node) => this.Previous = node;

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetNext(IExpressionNode? node) => this.Next = node;
    }
}