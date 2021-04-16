// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TSelf,TParameter1,TResult}.cs" company="AnoriSoft">
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
    /// Property Observer Base.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Base.PropertyObserverFundatinBase{TSelf, TResult}" />
    /// <seealso cref="PropertyObserverFundatinBase{TSelf}" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal abstract class PropertyObserverBase<TSelf, TParameter1, TResult> : PropertyObserverFundatinBase<TSelf>
        where TParameter1 : INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBase{TSelf, TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     propertyExpression
        ///     or
        ///     parameter1 is null.
        /// </exception>
        protected PropertyObserverBase(
            TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.Parameter1 = parameter1 ?? throw new ArgumentNullException(nameof(parameter1));
            this.Tree = this.CreateObserverTree(parameter1);
        }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public sealed override string ExpressionString => this.Tree.ExpressionString;

        /// <summary>
        ///     Gets the parameter1.
        /// </summary>
        /// <value>
        ///     The parameter1.
        /// </value>
        [CanBeNull]
        public TParameter1 Parameter1 { get; }

        /// <summary>
        ///     Gets the tree.
        /// </summary>
        /// <value>
        ///     The tree.
        /// </value>
        public IExpressionTree Tree { get; }

        /// <summary>
        ///     Creates the chain.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="tree">The nodes.</param>
        /// <exception cref="NotSupportedException">Expression Tree Node not supported.</exception>
        protected void CreateObserverTree(INotifyPropertyChanged parameter1, IRootAware tree)
        {
            foreach (var treeRoot in tree.Roots)
            {
                switch (treeRoot)
                {
                    case ParameterNode parameterElement:
                        {
                            if (!(parameterElement is { Next: PropertyNode propertyElement }))
                            {
                                continue;
                            }

                            var root = new RootPropertyObserverNode(
                                propertyElement.PropertyInfo,
                                this.OnAction,
                                parameter1);
                            this.LoopTree(propertyElement, root);
                            this.RootNodes.Add(root);
                            break;
                        }

                    case ConstantNode constantElement when treeRoot.Next is FieldNode fieldElement:
                        {
                            if (fieldElement.Next is not PropertyNode propertyElement)
                            {
                                continue;
                            }

                            var root = new RootPropertyObserverNode(
                                propertyElement.PropertyInfo,
                                this.OnAction,
                                (INotifyPropertyChanged)fieldElement.FieldInfo.GetValue(constantElement.Value));

                            this.LoopTree(propertyElement, root);
                            this.RootNodes.Add(root);
                            break;
                        }

                    case ConstantNode constantElement:
                        {
                            if (treeRoot.Next is not PropertyNode propertyElement)
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
                        throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// Creates the chain.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>Expression Tree.</returns>
        /// <exception cref="NotSupportedException">Operation not supported for the given expression type {expression.Type}. "
        /// + "Only MemberExpression and ConstantExpression are currently supported.</exception>
        private IExpressionTree CreateObserverTree(TParameter1 parameter1)
        {
            var tree = ExpressionTree.New(this.propertyExpression);
            this.CreateObserverTree(parameter1, tree);
            return tree;
        }
    }
}