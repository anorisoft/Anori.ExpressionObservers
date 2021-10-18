// -----------------------------------------------------------------------
// <copyright file="MethodNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Interfaces;

    /// <summary>
    ///     Method Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class MethodNode : IInternalExpressionNode, IMethodNode
    {
        private IExpressionNode @object;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MethodNode" /> struct.
        /// </summary>
        /// <param name="methodCallExpression">The method call expression.</param>
        public MethodNode(MethodCallExpression methodCallExpression)
        {
            this.MethodCallExpression = methodCallExpression;
            this.Object = null!;
            this.Arguments = null!;
            this.Result = null;
        }

        /// <summary>
        ///     Gets the method call expression.
        /// </summary>
        /// <value>
        ///     The method call expression.
        /// </value>
        public MethodCallExpression MethodCallExpression { get; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type => this.MethodCallExpression.Method.ReturnParameter?.ParameterType!;

        /// <summary>
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        public MethodInfo MethodInfo => this.MethodCallExpression.Method;

        /// <summary>
        ///     Gets or sets the object.
        /// </summary>
        /// <value>
        ///     The object.
        /// </value>
        public IExpressionNode Object
        {
            get => this.@object;
            set
            {
                this.@object = value;
    //            this.ParameterNotes = value;
            }
        }

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        public IList<IExpressionNode> Arguments { get; set; }

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
                yield return this.Object;
                foreach (var argument in this.Arguments)
                {
                    yield return argument;
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