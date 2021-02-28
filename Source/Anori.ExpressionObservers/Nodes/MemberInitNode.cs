// -----------------------------------------------------------------------
// <copyright file="MemberInitNode.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Member Init Expression Tree Node.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IInternalExpressionNode" />
    internal struct MemberInitNode : IInternalExpressionNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberInitNode" /> struct.
        /// </summary>
        /// <param name="memberInitExpression">The member initialize expression.</param>
        public MemberInitNode([NotNull] MemberInitExpression memberInitExpression)
        {
            this.MemberInitExpression = memberInitExpression;
            this.Parameters = new List<NodeCollection>();
            this.Bindings = new List<IBindingNode>();
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
        [NotNull]
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
        public IExpressionNode Previous { get; private set; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode Next { get; private set; }

        /// <summary>
        ///     Gets the parent.
        /// </summary>
        /// <value>
        ///     The parent.
        /// </value>
        public IExpressionNode Parent { get; private set; }

        /// <summary>
        ///     Gets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        [NotNull]
        public List<NodeCollection> Parameters { get; }

        /// <summary>
        ///     Gets the bindings.
        /// </summary>
        /// <value>
        ///     The bindings.
        /// </value>
        [NotNull]
        public List<IBindingNode> Bindings { get; }

        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetPrevious(IExpressionNode node) => this.Previous = node;

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetNext(IExpressionNode node) => this.Next = node;

        /// <summary>
        ///     Sets the parent.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetParent(IExpressionNode node) => this.Parent = node;
    }
}