// -----------------------------------------------------------------------
// <copyright file="IExpressionNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Tree.Interfaces
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Expresson Tree Node Interface.
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

        /// <summary>
        ///     Gets the parent.
        /// </summary>
        /// <value>
        ///     The parent.
        /// </value>
        [CanBeNull]
        IExpressionNode? Parent { get; }
    }
}