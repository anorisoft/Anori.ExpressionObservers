// -----------------------------------------------------------------------
// <copyright file="IRootAware.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    ///     Expression Tree Interface.
    /// </summary>
    public interface IRootAware
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