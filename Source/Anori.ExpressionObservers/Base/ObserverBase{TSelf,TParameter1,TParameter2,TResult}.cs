// -----------------------------------------------------------------------
// <copyright file="ObserverBase{TSelf,TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using Anori.ExpressionGetters;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    /// <summary>
    ///     Property Observer Base.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverFoundationBase" />
    internal abstract class ObserverBase<TSelf, TParameter1, TParameter2, TResult> : ObserverFoundationBase<TSelf>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverBase{TSelf,TParameter1,TParameter2,TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression or parameter1 or parameter2 is null.</exception>
        protected ObserverBase(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.Parameter1 = parameter1 ?? throw new ArgumentNullException(nameof(parameter1));
            this.Parameter2 = parameter2 ?? throw new ArgumentNullException(nameof(parameter2));
            this.Tree = this.CreateObserverTree(parameter1, parameter2);
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
        ///     Creates the observer tree with two parameters.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>
        ///     The expression tree.
        /// </returns>
        protected IExpressionTree CreateObserverTree(TParameter1 parameter1, TParameter2 parameter2)
        {
            var tree = ExpressionTree.New(this.propertyExpression);
            this.CreateObserverTree(parameter1, parameter2, tree);
            return tree;
        }

        /// <summary>
        ///     Creates the observer tree.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="nodes">The nodes.</param>
        private void CreateObserverTree(TParameter1 parameter1, TParameter2 parameter2, IRootAware nodes)
        {
            foreach (var treeRoot in nodes.Roots)
            {
                switch (treeRoot)
                {
                    case IParameterNode parameterElement:
                        {
                            if (parameterElement is not { Next: IPropertyNode propertyElement })
                            {
                                continue;
                            }

                            var parameterGetter = ExpressionGetter.GetParameterObjectFromExpression(
                                parameterElement,
                                this.propertyExpression);

                            if (parameterGetter == null)
                            {
                                throw new ParameterNullReferenceException("Parameter Null");
                            }

                            var parameter = parameterGetter(parameter1, parameter2) as INotifyPropertyChanged;

                            var root = new RootPropertyObserverNode(
                                propertyElement.PropertyInfo,
                                this.OnAction,
                                parameter);

                            this.LoopTree(propertyElement, root);
                            this.RootNodes.Add(root);

                            break;
                        }

                    case IConstantNode constantElement when treeRoot.Next is IFieldNode fieldElement:
                        {
                            if (fieldElement is not { Next: IPropertyNode propertyElement })
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

                    case IConstantNode constantElement:
                        {
                            if (treeRoot is not { Next: IPropertyNode propertyElement })
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