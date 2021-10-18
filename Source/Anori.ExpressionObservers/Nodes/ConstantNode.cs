// -----------------------------------------------------------------------
// <copyright file="ConstantNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions;
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;


    /// <summary>
    ///     Constant Expressen Tree Node.
    /// </summary>
    /// <seealso cref="IInternalExpressionNode" />
    internal class ConstantNode<TParameter1> :  IConstantNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstantNode" /> struct.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public ConstantNode([NotNull] ObserverNode<TParameter1> node)
        {
            this.Expression = System.Linq.Expressions.Expression.Constant(node);
            this.Type = typeof(ObserverNode<TParameter1>);
            this.Parameter = null;
            this.Result = null;
        }

        /// <summary>
        ///     Gets the expression.
        /// </summary>
        /// <value>
        ///     The expression.
        /// </value>
        public ConstantExpression Expression { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public object? Value => this.Expression.Value;

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
                yield break;
            }
        }

        /// <summary>
        ///     Gets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IExpressionNode? Result { get; private set; }

    }
}