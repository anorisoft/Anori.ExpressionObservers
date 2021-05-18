﻿// -----------------------------------------------------------------------
// <copyright file="IInternalExpressionNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    /// <summary>
    ///     The Internal Expression Tree Node Interface.
    /// </summary>
    internal interface IInternalExpressionNode : IExpressionNode
    {
        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void SetNext(IExpressionNode? node);

        /// <summary>
        ///     Sets the parent.
        /// </summary>
        /// <param name="node">The node.</param>
        void SetParent(IExpressionNode? node);

        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void SetPrevious(IExpressionNode? node);
    }
}