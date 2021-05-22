// -----------------------------------------------------------------------
// <copyright file="IMemberInitNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Anori.ExpressionTrees.Interfaces;

    /// <summary>
    ///     The Member Initialize Node interface.
    /// </summary>
    public interface IMemberInitNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the member initialize expression.
        /// </summary>
        /// <value>
        ///     The member initialize expression.
        /// </value>
        MemberInitExpression MemberInitExpression { get; }

        /// <summary>
        ///     Gets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        IList<INodeCollection> Parameters { get; }

        /// <summary>
        ///     Gets the bindings.
        /// </summary>
        /// <value>
        ///     The bindings.
        /// </value>
        IList<IBindingNode> Bindings { get; }
    }
}