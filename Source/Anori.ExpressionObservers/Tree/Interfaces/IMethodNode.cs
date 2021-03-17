// -----------------------------------------------------------------------
// <copyright file="IMethodNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    /// The Method Node interface.
    /// </summary>
    public interface IMethodNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the method call expression.
        /// </summary>
        /// <value>
        ///     The method call expression.
        /// </value>
        MethodCallExpression MethodCallExpression { get; }

        /// <summary>
        ///     Gets the object.
        /// </summary>
        /// <value>
        ///     The object.
        /// </value>
        INodeCollection Object { get; }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        IList<INodeCollection> Arguments { get; }

        /// <summary>
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        MethodInfo MethodInfo { get; }
    }
}