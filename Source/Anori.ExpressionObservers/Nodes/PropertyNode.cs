// -----------------------------------------------------------------------
// <copyright file="PropertyNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
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
    internal class PropertyNode : IPropertyNode
    {
        private static readonly IEnumerable<Expression> NullArgs = Array.Empty<Expression>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyNode" /> struct.
        /// </summary>
        /// <param name="memberExpression">The member expression.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="nodeType"></param>
        public PropertyNode([NotNull] Expression memberExpression, [NotNull] PropertyInfo propertyInfo, Type nodeType)
        {
            this.MemberExpression = memberExpression;
            this.PropertyInfo = propertyInfo;
            this.NodeType = nodeType;
            this.Type = NodeType;
            this.MethodInfo = propertyInfo.GetMethod;
            this.Args = NullArgs;
            this.Parameter = null;
            this.Result = null;
        }
        
        /// <summary>
        ///     Gets the member expression.
        /// </summary>
        /// <value>
        ///     The member expression.
        /// </value>
        public Expression MemberExpression { get; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        public PropertyInfo PropertyInfo { get; }

        public Type NodeType { get; }

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
        public IExpressionNode? Parameter { get; private set; }

        public IEnumerable<IExpressionNode> ParameterNotes
        {
            get
            {
                if (this.Parameter != null)
                {
                    yield return this.Parameter;
                }
            }
        }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Result { get; private set; }

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

       
    }
}