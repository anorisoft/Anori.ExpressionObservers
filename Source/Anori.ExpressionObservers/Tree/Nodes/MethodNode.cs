﻿// -----------------------------------------------------------------------
// <copyright file="MethodNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionObservers.Tree.Interfaces;

    /// <summary>
    ///     Method Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal struct MethodNode : IInternalExpressionNode, IMethodNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MethodNode" /> struct.
        /// </summary>
        /// <param name="methodCallExpression">The method call expression.</param>
        public MethodNode(MethodCallExpression methodCallExpression)
        {
            this.MethodCallExpression = methodCallExpression;
            this.Object = null!;
            this.Arguments = null!;
            this.Previous = null;
            this.Next = null;
            this.Parent = null;
        }

        /// <summary>
        ///     Gets the method call expression.
        /// </summary>
        /// <value>
        ///     The method call expression.
        /// </value>
        public MethodCallExpression MethodCallExpression { get; }

        /// <summary>
        ///     Gets or sets the object.
        /// </summary>
        /// <value>
        ///     The object.
        /// </value>
        public INodeCollection Object { get; set; }

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        public IList<INodeCollection> Arguments { get; set; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type => this.MethodCallExpression.Method.ReturnParameter.ParameterType;

        /// <summary>
        ///     Gets the previous.
        /// </summary>
        /// <value>
        ///     The previous.
        /// </value>
        public IExpressionNode? Previous { get; private set; }

        /// <summary>
        /// Gets the next.
        /// </summary>
        /// <value>
        /// The next.
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
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        public MethodInfo MethodInfo => this.MethodCallExpression.Method;

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