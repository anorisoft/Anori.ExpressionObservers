// -----------------------------------------------------------------------
// <copyright file="IConditionalNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Linq.Expressions;

    /// <summary>
    ///     The Conditional Node interface.
    /// </summary>
    public interface IConditionalNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the conditional expression.
        /// </summary>
        /// <value>
        ///     The conditional expression.
        /// </value>
        ConditionalExpression ConditionalExpression { get; }

        /// <summary>
        ///     Gets the test.
        /// </summary>
        /// <value>
        ///     The test.
        /// </value>
        IExpressionNode Test { get; }

        /// <summary>
        ///     Gets if true.
        /// </summary>
        /// <value>
        ///     If true.
        /// </value>
        IExpressionNode IfTrue { get; }

        /// <summary>
        ///     Gets if false.
        /// </summary>
        /// <value>
        ///     If false.
        /// </value>
        IExpressionNode IfFalse { get; }
    }
}