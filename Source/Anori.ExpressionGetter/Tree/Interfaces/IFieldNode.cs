// -----------------------------------------------------------------------
// <copyright file="IFieldNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Tree.Interfaces
{
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The Field Node interface.
    /// </summary>
    public interface IFieldNode : IExpressionNode
    {
        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        MemberExpression Expression { get; }

        /// <summary>
        ///     Gets the field information.
        /// </summary>
        /// <value>
        ///     The field information.
        /// </value>
        FieldInfo FieldInfo { get; }
    }
}