// -----------------------------------------------------------------------
// <copyright file="IPropertyNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The Property Node interface.
    /// </summary>
    /// <seealso cref="IExpressionNode" />
    public interface IPropertyNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the member expression.
        /// </summary>
        /// <value>
        ///     The member expression.
        /// </value>
        MemberExpression MemberExpression { get; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        PropertyInfo PropertyInfo { get; }

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
        IEnumerable<Expression> Args { get; }
    }
}