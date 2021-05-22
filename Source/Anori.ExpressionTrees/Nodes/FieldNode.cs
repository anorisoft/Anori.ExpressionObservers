// -----------------------------------------------------------------------
// <copyright file="FieldNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Field Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal struct FieldNode : IInternalExpressionNode, IFieldNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FieldNode" /> struct.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="fieldInfo">The field information.</param>
        public FieldNode([NotNull] MemberExpression expression, [NotNull] FieldInfo fieldInfo)
        {
            this.Expression = expression;
            this.Type = expression.Type;
            this.FieldInfo = fieldInfo;
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
        public MemberExpression Expression { get; }

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
        ///     Gets the field information.
        /// </summary>
        /// <value>
        ///     The field information.
        /// </value>
        public FieldInfo FieldInfo { get; }

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