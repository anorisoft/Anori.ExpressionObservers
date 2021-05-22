// -----------------------------------------------------------------------
// <copyright file="IUnaryNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Tree.Interfaces
{
    using System.Linq.Expressions;

    /// <summary>
    ///     The Unary Node interface.
    /// </summary>
    /// <seealso cref="IExpressionNode" />
    internal interface IUnaryNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the unary expression.
        /// </summary>
        /// <value>
        ///     The unary expression.
        /// </value>
        UnaryExpression UnaryExpression { get; }

        /// <summary>
        ///     Gets the operand.
        /// </summary>
        /// <value>
        ///     The operand.
        /// </value>
        INodeCollection Operand { get; }
    }
}