// -----------------------------------------------------------------------
// <copyright file="IConditionalNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
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
        INodeCollection Test { get; }

        /// <summary>
        ///     Gets if true.
        /// </summary>
        /// <value>
        ///     If true.
        /// </value>
        INodeCollection IfTrue { get; }

        /// <summary>
        ///     Gets if false.
        /// </summary>
        /// <value>
        ///     If false.
        /// </value>
        INodeCollection IfFalse { get; }
    }
}