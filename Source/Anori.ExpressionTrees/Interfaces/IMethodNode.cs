﻿// -----------------------------------------------------------------------
// <copyright file="IMethodNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The Method Node interface.
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
        IExpressionNode Object { get; }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        IList<IExpressionNode> Arguments { get; }

        /// <summary>
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        MethodInfo MethodInfo { get; }
    }
}