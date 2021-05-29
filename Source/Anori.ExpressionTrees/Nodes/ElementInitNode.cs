// -----------------------------------------------------------------------
// <copyright file="ElementInitNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Element Init Node.
    /// </summary>
    internal class ElementInitNode : IElementInitNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ElementInitNode" /> struct.
        /// </summary>
        /// <param name="elementInit">The element initialize.</param>
        /// <param name="arguments">The arguments.</param>
        public ElementInitNode([NotNull] ElementInit elementInit, IEnumerable<IExpressionNode> arguments)
        {
            this.ElementInit = elementInit;
            this.Arguments = arguments;
        }

        /// <summary>
        ///     Gets the element initialize.
        /// </summary>
        /// <value>
        ///     The element initialize.
        /// </value>
        public ElementInit ElementInit { get; }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        public IEnumerable<IExpressionNode> Arguments { get; }
    }
}