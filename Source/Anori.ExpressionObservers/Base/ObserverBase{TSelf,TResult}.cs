﻿// -----------------------------------------------------------------------
// <copyright file="ObserverBase{TSelf,TResult}.cs" company="AnoriSoft">
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
    ///     The Observer Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract class ObserverBase<TSelf, TResult> : ObserverFoundationBase<TSelf>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverBase{TSelf,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        protected ObserverBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(observerFlag) =>
            this.Tree = this.CreateObserverTree(propertyExpression);

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public sealed override string ExpressionString => this.Tree.ExpressionString;

        /// <summary>
        ///     Gets the tree.
        /// </summary>
        /// <value>
        ///     The tree.
        /// </value>
        protected IExpressionTree Tree { get; }

        /// <summary>
        ///     Creates the observer tree.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The expression tree.
        /// </returns>
        protected IExpressionTree CreateObserverTree(Expression<Func<TResult>> propertyExpression)
        {
            var tree = ExpressionTree.New(propertyExpression);
            this.CreateObserverTree(tree);
            return tree;
        }

        /// <summary>
        ///     Creates the observer tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        protected void CreateObserverTree(IRootAware tree)
        {
            foreach (var treeRoot in tree.Roots)
            {
                switch (treeRoot)
                {
                    case ConstantNode constantElement when treeRoot.Next is FieldNode fieldElement:
                        {
                            if (fieldElement.Next is not PropertyNode propertyElement)
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
                            if (treeRoot is not { Next: PropertyNode propertyElement })
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