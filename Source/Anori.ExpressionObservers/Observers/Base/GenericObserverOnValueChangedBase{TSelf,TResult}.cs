// -----------------------------------------------------------------------
// <copyright file="GenericObserverOnValueChangedBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.Base
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Observer On Value Changed Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract class
        GenericObserverOnValueChangedBase<TSelf, TResult> : ObserverOnValueChangedBase<TSelf, TResult>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericObserverOnValueChangedBase{TSelf, TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        protected GenericObserverOnValueChangedBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.CreateObserverTreeFromHead( this.Tree);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericObserverOnValueChangedBase{TSelf, TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <param name="fallback">The fallback.</param>
        protected GenericObserverOnValueChangedBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag,
            [NotNull] TResult fallback)
            : base(propertyExpression, observerFlag)
        {
            this.CreateObserverTreeFromHead( this.Tree, fallback);
        }

        /// <summary>
        ///     Creates the observer tree from head.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="propertyExpressionParameters"></param>
        /// <returns></returns>
        protected void CreateObserverTreeFromHead(
            IExpressionTree tree)
        {

            var node = ObserverNodeCreator.New<TResult>(tree.Head, this.OnAction);

            this.CreateObserverTree(tree);
        }

        /// <summary>
        /// Creates the observer tree from head.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="fallback">The fallback.</param>
        protected void CreateObserverTreeFromHead(
            IExpressionTree tree,
            TResult fallback)
        {

            var node = ObserverNodeCreator.New<TResult>(tree.Head, Fallback(fallback), this.OnAction);

            this.CreateObserverTree(tree);
        }
    }
}