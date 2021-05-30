// -----------------------------------------------------------------------
// <copyright file="FunctionNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Function Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class FunctionNode : IInternalExpressionNode, IFunctionNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FunctionNode" /> struct.
        /// </summary>
        /// <param name="method">The method.</param>
        public FunctionNode([NotNull] MethodCallExpression method)
        {
            this.Method = method;
            this.Parameters = null!;
            this.ReturnType = method.Method.ReturnType;
            this.MethodInfo = method.Method;
            this.Arguments = method.Arguments;
            this.Type = method.Method.ReturnType;
            this.Previous = null;
            this.Next = null;
        }

        /// <summary>
        ///     Gets the method.
        /// </summary>
        /// <value>
        ///     The method.
        /// </value>
        public MethodCallExpression Method { get; }

        /// <summary>
        ///     Gets or sets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        public IList<IExpressionNode> Parameters { get; set; }

        /// <summary>
        ///     Gets the type of the return.
        /// </summary>
        /// <value>
        ///     The type of the return.
        /// </value>
        public Type ReturnType { get; }

        /// <summary>
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        public ReadOnlyCollection<Expression> Arguments { get; }

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