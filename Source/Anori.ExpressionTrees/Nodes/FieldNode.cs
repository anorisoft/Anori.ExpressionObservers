// -----------------------------------------------------------------------
// <copyright file="FieldNode.cs" company="AnoriSoft">
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
    ///     Field Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class FieldNode : IInternalExpressionNode, IFieldNode
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
            this.Parameter = null;
            this.Result = null;
        }

        public FieldNode([NotNull] MemberExpression expression, [NotNull] FieldInfo fieldInfo, IExpressionNode next)
        {
            this.Expression = expression;
            this.Type = expression.Type;
            this.FieldInfo = fieldInfo;
            this.Parameter = null;
            this.Result = next;
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
        public IExpressionNode? Parameter { get; private set; }

        public IEnumerable<IExpressionNode> ParameterNotes
        {
            get
            {
                yield return Parameter;
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
        void IInternalExpressionNode.SetParameter(IExpressionNode? node) => this.Parameter = node;

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetResult(IExpressionNode? node) => this.Result = node;
    }
}