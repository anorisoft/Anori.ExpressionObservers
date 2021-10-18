// -----------------------------------------------------------------------
// <copyright file="MemberInitNode.cs" company="AnoriSoft">
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
    ///     Member Init Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class MemberInitNode : IInternalExpressionNode, IMemberInitNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberInitNode" /> struct.
        /// </summary>
        /// <param name="memberInitExpression">The member initialize expression.</param>
        public MemberInitNode([NotNull] MemberInitExpression memberInitExpression)
        {
            this.MemberInitExpression = memberInitExpression;
            this.Parameters = null!;
            this.Bindings = null!;
            this.Parameter = null;
            this.Result = null;
        }

        /// <summary>
        ///     Gets the member initialize expression.
        /// </summary>
        /// <value>
        ///     The member initialize expression.
        /// </value>
        public MemberInitExpression MemberInitExpression { get; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type => this.MemberInitExpression.Type;

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
                return this.Parameters;
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
        ///     Gets or sets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        public IList<IExpressionNode> Parameters { get; internal set; }

        /// <summary>
        ///     Gets or sets the bindings.
        /// </summary>
        /// <value>
        ///     The bindings.
        /// </value>
        public IList<IBindingNode> Bindings { get; internal set; }

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