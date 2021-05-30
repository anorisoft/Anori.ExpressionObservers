// -----------------------------------------------------------------------
// <copyright file="IExpressionNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Expression Tree Node Interface.
    /// </summary>
    public interface IExpressionNode
    {
        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [NotNull]
        Type Type { get; }

        /// <summary>
        ///     Gets the previous.
        /// </summary>
        /// <value>
        ///     The previous.
        /// </value>
        [CanBeNull]
        IExpressionNode? Previous { get; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        [CanBeNull]
        IExpressionNode? Next { get; }

       
    }
}