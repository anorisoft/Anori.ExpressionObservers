// -----------------------------------------------------------------------
// <copyright file="IConstantNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Nodes;

    /// <summary>
    /// The Constant Node interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IExpressionNode" />
    public interface IConstantNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        ConstantExpression Expression { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        object? Value { get; }
    }
}