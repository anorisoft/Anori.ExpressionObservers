// -----------------------------------------------------------------------
// <copyright file="BinaryNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Binary Expression Tree Node.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IExpressionNode" />
    internal struct BinaryNode : IInternalExpressionNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BinaryNode" /> struct.
        /// </summary>
        /// <param name="binaryExpression">The binary expression.</param>
        public BinaryNode([NotNull] BinaryExpression binaryExpression)
        {
            this.BinaryExpression = binaryExpression;
            this.NodeType = binaryExpression.NodeType;
            this.LeftNodes = null;
            this.RightNodes = null;
            this.Type = binaryExpression.Type;
            this.Previous = null;
            this.Next = null;
            this.Parent = null;
        }

        /// <summary>
        ///     Gets the binary expression.
        /// </summary>
        /// <value>
        ///     The binary expression.
        /// </value>
        public BinaryExpression BinaryExpression { get; }

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
        public IExpressionNode Previous { get; private set; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode Next { get; private set; }

        /// <summary>
        ///     Gets the parent.
        /// </summary>
        /// <value>
        ///     The parent.
        /// </value>
        public IExpressionNode Parent { get; private set; }

        /// <summary>
        ///     Gets the type of the node.
        /// </summary>
        /// <value>
        ///     The type of the node.
        /// </value>
        public ExpressionType NodeType { get; }

        /// <summary>
        ///     Gets or sets the left nodes.
        /// </summary>
        /// <value>
        ///     The left nodes.
        /// </value>
        public NodeCollection LeftNodes { get; internal set; }

        /// <summary>
        ///     Gets or sets the righttree.
        /// </summary>
        /// <value>
        ///     The righttree.
        /// </value>
        public NodeCollection RightNodes { get; internal set; }

        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetPrevious(IExpressionNode node) => this.Previous = node;

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetNext(IExpressionNode node) => this.Next = node;

        /// <summary>
        ///     Sets the parent.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetParent(IExpressionNode node) => this.Parent = node;
    }
}