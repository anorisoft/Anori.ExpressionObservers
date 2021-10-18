// -----------------------------------------------------------------------
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
    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Observer Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract class ObserverBase<TSelf, TResult> : ObserverFoundationBase<TSelf>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        private static ClassDebugger DebugExtensions { get; } = new ClassDebugger(typeof(ObserverBase<TSelf, TResult>));


        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverBase{TSelf,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        protected ObserverBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
            using var debug = DebugExtensions.DebugMethod();
            this.propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.Tree = this.CreateObserverTree();
        }

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
        private IExpressionTree CreateObserverTree()
        {
            using var debug = DebugExtensions.DebugMethod();

            var tree = ExpressionTree.Factory.New(this.propertyExpression);
            //        this.CreateObserverTree(tree);
            return tree;
        }

        ///// <summary>
        /////     Creates the observer tree from head.
        ///// </summary>
        ///// <param name="resultType">Type of the result.</param>
        ///// <param name="tree">The tree.</param>
        ///// <param name="fallback">The fallback.</param>
        //protected void CreateObserverTreeFromHead([NotNull] Type resultType, [NotNull] IExpressionTree tree,[NotNull] TResult fallback)
        //{
        //    this.GetRootStruct(resultType, tree, () => { }, Fallback(fallback));
        //    this.CreateObserverTree(tree);
        //}

        ///// <summary>
        /////     Creates the observer tree from head.
        ///// </summary>
        ///// <param name="resultType">Type of the result.</param>
        ///// <param name="tree">The tree.</param>
        //protected void CreateObserverTreeFromHead([NotNull] Type resultType, [NotNull] IExpressionTree tree)
        //{
        //    this.GetRootStruct(resultType, tree, () => { });
        //    this.CreateObserverTree(tree);
        //}

        /// <summary>
        ///     Creates the observer tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        protected void CreateObserverTree(IRootAware tree)
        {
            using var debug = DebugExtensions.DebugMethod();
            foreach (var treeRoot in tree.Roots)
            {
                switch (treeRoot)
                {
                    case IConstantNode constantElement when treeRoot.Result is IFieldNode fieldElement:
                        {
                            if (fieldElement.Result is not IPropertyNode propertyElement)
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

                    case IConstantNode constantElement:
                        {
                            if (treeRoot is not { Result: IPropertyNode propertyElement })
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