// -----------------------------------------------------------------------
// <copyright file="IExpressionTree.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     Expression Tree Interface.
    /// </summary>
    public interface IExpressionTree
    {
        /// <summary>
        ///     Gets the roots.
        /// </summary>
        /// <value>
        ///     The roots.
        /// </value>
        IList<IExpressionNode> Roots { get; }
    }
}