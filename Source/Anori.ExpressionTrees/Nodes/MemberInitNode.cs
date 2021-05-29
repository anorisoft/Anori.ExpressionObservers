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
            this.Previous = null;
            this.Next = null;
            this.Parent = null;
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