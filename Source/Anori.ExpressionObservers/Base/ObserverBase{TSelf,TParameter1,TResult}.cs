// -----------------------------------------------------------------------
// <copyright file="ObserverBase{TSelf,TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer Base.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverFoundationBase" />
    internal abstract class ObserverBase<TSelf, TParameter1, TResult> : ObserverFoundationBase<TSelf>
        where TParameter1 : INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverBase{TSelf,TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">
        ///     propertyExpression
        ///     or
        ///     parameter1 is null.
        /// </exception>
        protected ObserverBase(
            [NotNull] TParameter1 parameter1,
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
        protected void CreateObserverTree(INotifyPropertyChanged parameter1, IExpressionTree tree)
        {
            foreach (var treeRoot in tree.Roots)
            {
                switch (treeRoot)
                {
                    case IParameterNode parameterElement:
                        {
                            if (parameterElement is not { Result: IPropertyNode propertyElement })
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

                    case IConstantNode constantElement when treeRoot.Result is IFieldNode fieldElement:
                        {
                            if (fieldElement.Result is not IPropertyNode propertyElement)
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
                            if (treeRoot.Result is not IPropertyNode propertyElement)
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

        ///// <summary>
        /////     Creates the observer tree from head.
        ///// </summary>
        ///// <param name="resultType">Type of the result.</param>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="tree">The tree.</param>
        ///// <param name="fallback">The fallback.</param>
        ///// <returns></returns>
        //protected void CreateObserverTreeFromHead(
        //    Type resultType,
        //    INotifyPropertyChanged parameter1,
        //    IExpressionTree tree,
        //    TResult fallback)
        //{
        //    this.GetRootStruct(resultType, tree, () => { }, Fallback(fallback));
        //    this.CreateObserverTree(parameter1, tree);
        //}

        ///// <summary>
        /////     Creates the observer tree from head.
        ///// </summary>
        ///// <param name="resultType">Type of the result.</param>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="tree">The tree.</param>
        ///// <param name="propertyExpressionParameters"></param>
        ///// <returns></returns>
        //protected virtual void CreateObserverTreeFromHead(
        //    Type resultType,
        //    INotifyPropertyChanged parameter1,
        //    IExpressionTree tree,
        //    ReadOnlyCollection<ParameterExpression> parameters)
        //{
        //    var body = this.GetRootStruct(resultType, tree, () => { }); 
        //    var lambda = Expression.Lambda<Func<TParameter1, TResult>>(body, parameters);
        //    lambda.Compile();

           
        //    this.CreateObserverTree(parameter1, tree);
        //}

        /// <summary>
        ///     Creates the observer tree.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>
        ///     The expression tree.
        /// </returns>
        private IExpressionTree CreateObserverTree(TParameter1 parameter1)
        {
            var tree = ExpressionTree.Factory.New(this.propertyExpression);
            // this.CreateObserverTree(parameter1, tree);
            return tree;
        }
    }
}