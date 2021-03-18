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
    public interface IRootAweare
    {
        /// <summary>
        ///     Gets the roots.
        /// </summary>
        /// <value>
        ///     The roots.
        /// </value>
        IList<IExpressionNode> Roots { get; }
    }

    /// <summary>
    /// The I Expression Tree interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Tree.Interfaces.IRootAweare" />
    public interface IExpressionTree : IRootAweare
    {
        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        INodeCollection Nodes { get;  }
    }

    
}