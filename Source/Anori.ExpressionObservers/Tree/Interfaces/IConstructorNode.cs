// -----------------------------------------------------------------------
// <copyright file="IConstructorNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The Constructor Node interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IExpressionNode" />
    public interface IConstructorNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        NewExpression Expression { get; }

        /// <summary>
        ///     Gets the constructor.
        /// </summary>
        /// <value>
        ///     The constructor.
        /// </value>
        ConstructorInfo Constructor { get; }

        /// <summary>
        ///     Gets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        IList<INodeCollection> Parameters { get; }
    }
}