// -----------------------------------------------------------------------
// <copyright file="ConstructorNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionObservers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Constructor Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal struct ConstructorNode : IInternalExpressionNode, IConstructorNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstructorNode" /> struct.
        /// </summary>
        /// <param name="expression">The new expression.</param>
        public ConstructorNode([NotNull] NewExpression expression)
        {
            this.Expression = expression;
            this.Parameters = null!;
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
        public NewExpression Expression { get; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type => this.Expression.Type;

        /// <summary>
        ///     Gets the constructor.
        /// </summary>
        /// <value>
        ///     The constructor.
        /// </value>
        public ConstructorInfo Constructor => this.Expression.Constructor;

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
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public IList<INodeCollection> Parameters { get; internal set; }

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