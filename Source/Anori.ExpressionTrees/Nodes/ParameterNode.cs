// -----------------------------------------------------------------------
// <copyright file="ParameterNode.cs" company="AnoriSoft">
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
    ///     Parameter Expression Tree Node.
    /// </summary>
    internal class ParameterNode : IInternalExpressionNode, IParameterNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ParameterNode" /> struct.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ParameterNode([NotNull] ParameterExpression expression)
        {
            this.Type = expression.Type;
            this.Expression = expression;
            this.Parameter = null;
            this.Result = null;
        }

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

        public IEnumerable<IExpressionNode> ParameterNotes
        {
            get
            {
                var parameter = this.Parameter;
                if (parameter != null)
                {
                    yield return parameter;
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
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        public ParameterExpression Expression { get; }

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