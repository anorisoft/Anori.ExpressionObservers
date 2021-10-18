// -----------------------------------------------------------------------
// <copyright file="GenericObserverBase{TSelf,TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.Base
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The generic observer base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Base.ObserverBase{TSelf, TParameter1, TResult}" />
    internal abstract class GenericObserverBase<TSelf, TParameter1, TResult> : ObserverBase<TSelf, TParameter1, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericObserverBase{TSelf, TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        protected GenericObserverBase(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag) =>
            this.CreateObserverTreeFromHead(parameter1, propertyExpression.Parameters, this.Tree);

        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericObserverBase{TSelf, TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <param name="fallback">The fallback.</param>
        protected GenericObserverBase(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag,
            TResult fallback)
            : base(parameter1, propertyExpression, observerFlag) =>
            this.CreateObserverTreeFromHead(parameter1, propertyExpression.Parameters, this.Tree, fallback);
    

    /// <summary>
    ///     Creates the observer tree from head.
    /// </summary>
    /// <param name="resultType">Type of the result.</param>
    /// <param name="parameter1">The parameter1.</param>
    /// <param name="tree">The tree.</param>
    /// <param name="propertyExpressionParameters"></param>
    /// <returns></returns>
    protected void CreateObserverTreeFromHead(
    TParameter1 parameter1,
    ReadOnlyCollection<ParameterExpression> parameters,
    IExpressionTree tree)
    {

    var node = ObserverNodeCreator.New<TParameter1>(parameter1, parameters, tree.Head, this.OnAction);

        this.CreateObserverTree(parameter1, tree);
    }

    /// <summary>
    /// Creates the observer tree from head.
    /// </summary>
    /// <param name="parameter1">The parameter1.</param>
    /// <param name="tree">The tree.</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="fallback">The fallback.</param>
    protected void CreateObserverTreeFromHead(
    TParameter1 parameter1,
    ReadOnlyCollection<ParameterExpression> parameters,
    IExpressionTree tree,
    TResult fallback)
    {

    var node = ObserverNodeCreator.New<TParameter1, TResult>(parameter1, parameters, tree.Head, Fallback(fallback), this.OnAction);

        this.CreateObserverTree(parameter1, tree);
    }
}}