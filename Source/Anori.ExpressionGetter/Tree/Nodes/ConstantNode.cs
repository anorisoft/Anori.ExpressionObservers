// -----------------------------------------------------------------------
// <copyright file="ConstantNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Tree.Nodes
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionGetters.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Constant Expressen Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal struct ConstantNode : IInternalExpressionNode, IConstantNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstantNode" /> struct.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ConstantNode([NotNull] ConstantExpression expression)
        {
            this.Expression = expression;
            this.Type = expression.Type;
            this.Previous = null;
            this.Next = null;
            this.Parent = null;
        }

        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        public ConstantExpression Expression { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public object? Value => this.Expression.Value;

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
        public IExpressionNode? Previous { get; private set; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Next { get; private set; }

        /// <summary>
        ///     Gets the parent.
        /// </summary>
        /// <value>
        ///     The parent.
        /// </value>
        public IExpressionNode? Parent { get; private set; }

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

        /// <summary>
        ///     Sets the parent.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetParent(IExpressionNode? node) => this.Parent = node;
    }
}