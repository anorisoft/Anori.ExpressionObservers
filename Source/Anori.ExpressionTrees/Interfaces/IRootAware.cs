// -----------------------------------------------------------------------
// <copyright file="IRootAware.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    ///     The Root Aware interface.
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