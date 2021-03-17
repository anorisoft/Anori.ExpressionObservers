// -----------------------------------------------------------------------
// <copyright file="IParameterNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Tree.Interfaces;

    /// <summary>
    /// The Parameter Node interface.
    /// </summary>
    public interface IParameterNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        ParameterExpression Expression { get; }
    }
}