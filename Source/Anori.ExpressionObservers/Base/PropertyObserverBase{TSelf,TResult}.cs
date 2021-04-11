// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionObservers.Tree;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.ExpressionObservers.Tree.Nodes;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer Base.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverFundatinBase{TSelf}" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal abstract class PropertyObserverBase<TSelf, TResult> : PropertyObserverFundatinBase<TSelf>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBase{TSelf, TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        protected PropertyObserverBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
            (this.ExpressionString, this.Tree) = this.CreateChain(propertyExpression);
        }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public sealed override string ExpressionString { get; }

        /// <summary>
        ///     Gets the tree.
        /// </summary>
        /// <value>
        ///     The tree.
        /// </value>
        protected IExpressionTree Tree { get; }

        /// <summary>
        ///     Creates the chain.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The Expression String.
        /// </returns>
        /// <exception cref="NotSupportedException">
        ///     Operation not supported for the given expression type {expression.Type}. "
        ///     + "Only MemberExpression and ConstantExpression are currently supported.
        /// </exception>
        protected (string, IExpressionTree) CreateChain(Expression<Func<TResult>> propertyExpression)
        {
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            var expressionString = propertyExpression.ToString();

            this.CreateChain(tree);

            return (expressionString, tree);
        }

        /// <summary>
        ///     Creates the chain.
        /// </summary>
        /// <param name="tree">The nodes.</param>
        /// <exception cref="System.NotSupportedException">Expression Tree Node not supported.</exception>
        protected void CreateChain(IRootAware tree)
        {
            foreach (var treeRoot in tree.Roots)
            {
                switch (treeRoot)
                {
                    case ConstantNode constantElement when treeRoot.Next is FieldNode fieldElement:
                        {
                            if (!(fieldElement.Next is PropertyNode propertyElement))
                            {
                                continue;
                            }

                            var root = new RootPropertyObserverNode(
                                propertyElement.PropertyInfo,
                                this.OnAction,
                                fieldElement.FieldInfo.GetValue(constantElement.Value));

                            this.LoopTree(propertyElement, root);
                            this.RootNodes.Add(root);
                            break;
                        }

                    case ConstantNode constantElement:
                        {
                            if (!(treeRoot.Next is PropertyNode propertyElement))
                            {
                                continue;
                            }

                            var root = new RootPropertyObserverNode(
                                propertyElement.PropertyInfo,
                                this.OnAction,
                                (INotifyPropertyChanged)constantElement.Value!);

                            this.LoopTree(propertyElement, root);
                            this.RootNodes.Add(root);

                            break;
                        }

                    default:
                        throw new NotSupportedException($"{treeRoot}");
                }
            }
        }
    }
}