﻿// -----------------------------------------------------------------------
// <copyright file="IExpressionTree.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    /// <summary>
    ///     The I Expression Tree interface.
    /// </summary>
    /// <seealso cref="IRootAware" />
    public interface IExpressionTree : IRootAware
    {
        /// <summary>
        ///     Gets the nodes.
        /// </summary>
        /// <value>
        ///     The nodes.
        /// </value>
        INodeCollection Nodes { get; }


        /// <summary>
        /// Gets the expression string.
        /// </summary>
        /// <value>
        /// The expression string.
        /// </value>
        string ExpressionString { get; }


        /// <summary>
        /// Gets the head.
        /// </summary>
        /// <value>
        /// The head.
        /// </value>
        IExpressionNode Head { get; }
    }
}