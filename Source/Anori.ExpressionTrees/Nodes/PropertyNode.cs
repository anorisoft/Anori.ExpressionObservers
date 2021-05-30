// -----------------------------------------------------------------------
// <copyright file="PropertyNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Expression Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class PropertyNode : IInternalExpressionNode, IPropertyNode
    {
        private static readonly IEnumerable<Expression> NullArgs = Array.Empty<Expression>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyNode" /> struct.
        /// </summary>
        /// <param name="memberExpression">The member expression.</param>
        /// <param name="propertyInfo">The property information.</param>
        public PropertyNode([NotNull] MemberExpression memberExpression, [NotNull] PropertyInfo propertyInfo)
        {
            this.MemberExpression = memberExpression;
            this.PropertyInfo = propertyInfo;
            this.Type = memberExpression.Type;
            this.MethodInfo = propertyInfo.GetMethod;
            this.Args = NullArgs;
            this.Previous = null;
            this.Next = null;
        }

        public PropertyNode([NotNull] MemberExpression memberExpression, [NotNull] PropertyInfo propertyInfo, IExpressionNode next)
        {
            this.MemberExpression = memberExpression;
            this.PropertyInfo = propertyInfo;
            this.Type = memberExpression.Type;
            this.MethodInfo = propertyInfo.GetMethod;
            this.Args = NullArgs;
            this.Previous = null;
            this.Next = next;
        }

        /// <summary>
        ///     Gets the member expression.
        /// </summary>
        /// <value>
        ///     The member expression.
        /// </value>
        public MemberExpression MemberExpression { get; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        public PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public Type Type { get; }

        /// <summary>
        ///     Gets the previous.
        /// </summary>
        /// <value>
        ///     The previous.
        /// </value>
        public IExpressionNode? Previous { get; private set; }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Next { get; private set; }

        /// <summary>
        ///     Gets the method information.
        /// </summary>
        /// <value>
        ///     The method information.
        /// </value>
        public MethodInfo MethodInfo { get; }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        public IEnumerable<Expression> Args { get; }

        /// <summary>
        ///     Sets the previous.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetPrevious(IExpressionNode? node) => this.Previous = node;

        /// <summary>
        ///     Sets the next.
        /// </summary>
        /// <param name="node">The node.</param>
        void IInternalExpressionNode.SetNext(IExpressionNode? node) => this.Next = node;
    }
}