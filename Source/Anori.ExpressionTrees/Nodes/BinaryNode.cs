// -----------------------------------------------------------------------
// <copyright file="BinaryNode.cs" company="AnoriSoft">
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
    ///     Binary Expression Tree Node.
    /// </summary>
    internal class BinaryNode : IInternalExpressionNode, IBinaryNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BinaryNode" /> struct.
        /// </summary>
        /// <param name="binaryExpression">The binary expression.</param>
        public BinaryNode([NotNull] BinaryExpression binaryExpression)
        {
            this.BinaryExpression = binaryExpression;
            this.NodeType = binaryExpression.NodeType;
            this.LeftNode = null!;
            this.RightNode = null!;
            this.Type = binaryExpression.Type;
            this.Parameter = null;
            this.Result = null;
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
        public IExpressionNode? Parameter { get; private set; }

        /// <summary>
        /// Gets the parameter notes.
        /// </summary>
        /// <value>
        /// The parameter notes.
        /// </value>
        public IEnumerable<IExpressionNode> ParameterNotes 
        {
            get
            {
                yield return this.LeftNode;
                yield return this.RightNode;
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
        public IExpressionNode LeftNode { get; internal set; }


        /// <summary>
        ///     Gets or sets the right nodes.
        /// </summary>
        /// <value>
        ///     The right nodes.
        /// </value>
        public IExpressionNode RightNode { get; internal set; }

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