// -----------------------------------------------------------------------
// <copyright file="IFunctionNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The Function Node interface.
    /// </summary>
    public interface IFunctionNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the method.
        /// </summary>
        /// <value>
        ///     The method.
        /// </value>
        MethodCallExpression Method { get; }

        /// <summary>
        ///     Gets or sets the parameters.
        /// </summary>
        /// <value>
        ///     The parameters.
        /// </value>
        IList<INodeCollection> Parameters { get; set; }

        /// <summary>
        ///     Gets the type of the return.
        /// </summary>
        /// <value>
        ///     The type of the return.
        /// </value>
        Type ReturnType { get; }

        /// <summary>
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        MethodInfo MethodInfo { get; }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        ReadOnlyCollection<Expression> Arguments { get; }
    }
}