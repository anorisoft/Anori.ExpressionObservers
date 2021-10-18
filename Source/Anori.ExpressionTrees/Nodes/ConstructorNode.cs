// -----------------------------------------------------------------------
// <copyright file="ConstructorNode.cs" company="AnoriSoft">
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

    using JetBrains.Annotations;

    /// <summary>
    ///     Constructor Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class ConstructorNode : IInternalExpressionNode, IConstructorNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstructorNode" /> struct.
        /// </summary>
        /// <param name="expression">The new expression.</param>
        public ConstructorNode([NotNull] NewExpression expression)
        {
            this.Expression = expression;
            this.Parameters = null!;
            this.Parameter = null;
            this.Result = null;
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
        public IExpressionNode? Parameter { get; private set; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Result { get; private set; }

        /// <summary>
        ///     Gets or sets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        public IList<IExpressionNode> Parameters { get; internal set; }

        public IEnumerable<IExpressionNode> ParameterNotes => Parameters;

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