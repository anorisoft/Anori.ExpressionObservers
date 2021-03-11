﻿// -----------------------------------------------------------------------
// <copyright file="IInternalExpressionNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using JetBrains.Annotations;

    /// <summary>
    ///     Internal Expression Tree Node Interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IExpressionNode" />
    internal interface IInternalExpressionNode : IExpressionNode
    {
        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void SetPrevious([CanBeNull] IExpressionNode node);

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void SetNext([CanBeNull] IExpressionNode node);

        /// <summary>
        ///     Sets the parent.
        /// </summary>
        /// <param name="node">The node.</param>
        void SetParent([CanBeNull] IExpressionNode node);
    }
}