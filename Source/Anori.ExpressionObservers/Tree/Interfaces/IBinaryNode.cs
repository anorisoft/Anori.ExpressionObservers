// -----------------------------------------------------------------------
// <copyright file="IBinaryNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     Binary Node Interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IExpressionNode" />
    public interface IBinaryNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the binary expression.
        /// </summary>
        /// <value>
        ///     The binary expression.
        /// </value>
        BinaryExpression BinaryExpression { get; }

        /// <summary>
        ///     Gets the type of the node.
        /// </summary>
        /// <value>
        ///     The type of the node.
        /// </value>
        ExpressionType NodeType { get; }

        /// <summary>
        ///     Gets the left nodes.
        /// </summary>
        /// <value>
        ///     The left nodes.
        /// </value>
        INodeCollection LeftNodes { get; }

        /// <summary>
        ///     Gets the righttree.
        /// </summary>
        /// <value>
        ///     The righttree.
        /// </value>
        INodeCollection RightNodes { get; }
    }
}