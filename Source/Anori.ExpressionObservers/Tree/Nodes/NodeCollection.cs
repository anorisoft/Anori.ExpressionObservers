// -----------------------------------------------------------------------
// <copyright file="NodeCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Nodes
{
    using System.Collections.Generic;
    using System.Linq;

    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Expression Tree Node Collection.
    /// </summary>
    /// <seealso cref="IExpressionNode" />
    /// <seealso cref="IExpressionTree" />
    internal class NodeCollection : List<IExpressionNode>, INodeCollection
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NodeCollection" /> class.
        /// </summary>
        /// <param name="expressionTree">The expression tree.</param>
        /// <param name="parent">The parent.</param>
        public NodeCollection([NotNull] IExpressionTree expressionTree, IExpressionNode? parent)
        {
            this.ExpressionTree = expressionTree;
            this.Parent = parent;
        }

        /// <summary>
        ///     Gets the expression tree.
        /// </summary>
        /// <value>
        ///     The expression tree.
        /// </value>
        [NotNull]
        public IExpressionTree ExpressionTree { get; }

        /// <summary>
        ///     Gets the parent.
        /// </summary>
        /// <value>
        ///     The parent.
        /// </value>
        public IExpressionNode? Parent { get; }

        /// <summary>
        ///     Gets the roots.
        /// </summary>
        /// <value>
        ///     The roots.
        /// </value>
        public IList<IExpressionNode> Roots => this.ExpressionTree.Roots;

        /// <summary>
        ///     Adds an Expressione Tree Node and update relations.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        ///     The Node.
        /// </returns>
        public IExpressionNode AddElement([NotNull] IExpressionNode node)
        {
            var internalNode = (IInternalExpressionNode)node;
            if (this.Any())
            {
                ((IInternalExpressionNode)this.Last()).SetPrevious(node);

                internalNode.SetNext(this.Last());
            }

            internalNode.SetParent(this.Parent);
            this.Add(internalNode);
            return internalNode;
        }
    }
}