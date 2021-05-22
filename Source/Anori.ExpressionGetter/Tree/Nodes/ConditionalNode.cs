// -----------------------------------------------------------------------
// <copyright file="ConditionalNode.cs" company="AnoriSoft">
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
    ///     Conditional Node.
    /// </summary>
    /// <seealso cref="IExpressionNode" />
    internal struct ConditionalNode : IInternalExpressionNode, IConditionalNode
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
            this.Previous = null;
            this.Next = null;
            this.Parent = null;
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
        public INodeCollection Test { get; set; }

        /// <summary>
        ///     Gets or sets if true.
        /// </summary>
        /// <value>
        ///     If true.
        /// </value>
        public INodeCollection IfTrue { get; set; }

        /// <summary>
        ///     Gets or sets if false.
        /// </summary>
        /// <value>
        ///     If false.
        /// </value>
        public INodeCollection IfFalse { get; set; }

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