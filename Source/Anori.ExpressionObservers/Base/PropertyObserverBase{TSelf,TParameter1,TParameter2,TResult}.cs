// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TSelf,TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverFundatinBase{TSelf}" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal abstract class
        PropertyObserverBase<TSelf, TParameter1, TParameter2, TResult> : PropertyObserverFundatinBase<TSelf>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBase{TSelf, TParameter1, TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression or parameter1 or parameter2 is null.</exception>
        protected PropertyObserverBase(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.Parameter1 = parameter1 ?? throw new ArgumentNullException(nameof(parameter1));
            this.Parameter2 = parameter2 ?? throw new ArgumentNullException(nameof(parameter2));
            (this.ExpressionString, this.Tree) = this.CreateChain(parameter1, parameter2);
        }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public sealed override string ExpressionString { get; }

        /// <summary>
        ///     Gets the parameter1.
        /// </summary>
        /// <value>
        ///     The parameter1.
        /// </value>
        [CanBeNull]
        public TParameter1 Parameter1 { get; }

        /// <summary>
        ///     Gets the parameter2.
        /// </summary>
        /// <value>
        ///     The parameter2.
        /// </value>
        [CanBeNull]
        public TParameter2 Parameter2 { get; }

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
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>
        ///     The ExpressionString.
        /// </returns>
        /// <exception cref="NotSupportedException">
        ///     Operation not supported for the given expression type {expression.Type}. "
        ///     + "Only MemberExpression and ConstantExpression are currently supported.
        /// </exception>
        protected (string, IExpressionTree) CreateChain(TParameter1 parameter1, TParameter2 parameter2)
        {
            var tree = ExpressionTree.GetTree(this.propertyExpression.Body);
            var expressionString = this.propertyExpression.ToString();
            this.CreateChain(parameter1, parameter2, tree);
            return (expressionString, tree);
        }

        /// <summary>
        ///     Creates the chain.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="nodes">The nodes.</param>
        /// <exception cref="NotSupportedException">Expression Tree Node not supported.</exception>
        private void CreateChain(TParameter1 parameter1, TParameter2 parameter2, IRootAware nodes)
        {
            foreach (var treeRoot in nodes.Roots)
            {
                switch (treeRoot)
                {
                    case ParameterNode parameterElement:
                        {
                            if (!(parameterElement is { Next: PropertyNode propertyElement }))
                            {
                                continue;
                            }

                            var parameterGetter = ExpressionGetter.CreateParameterGetter(
                                parameterElement,
                                this.propertyExpression);
                            var root = new RootPropertyObserverNode(
                                propertyElement.PropertyInfo,
                                this.OnAction,
                                (INotifyPropertyChanged)parameterGetter(parameter1, parameter2));

                            this.LoopTree(propertyElement, root);
                            this.RootNodes.Add(root);
                            break;
                        }

                    case ConstantNode constantElement when treeRoot.Next is FieldNode fieldElement:
                        {
                            if (!(fieldElement is { Next: PropertyNode propertyElement }))
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
                            if (!(treeRoot is { Next: PropertyNode propertyElement }))
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
    }
}