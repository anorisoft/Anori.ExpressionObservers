// -----------------------------------------------------------------------
// <copyright file="ReferenceObserverOnValueChangedBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.Base
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Observer On Value Changed Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract class
        ReferenceObserverOnValueChangedBase<TSelf, TResult> : ObserverOnValueChangedBase<TSelf, TResult>
        where TSelf : IPropertyObserverBase<TSelf>
        where TResult : class
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferenceObserverOnValueChangedBase{TSelf, TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        protected ReferenceObserverOnValueChangedBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.CreateObserverTree(this.Tree);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferenceObserverOnValueChangedBase{TSelf, TParameter1, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <param name="fallback">The fallback.</param>
        protected ReferenceObserverOnValueChangedBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag,
            TResult fallback)
            : base(propertyExpression, observerFlag)
        {
            this.CreateObserverTree( this.Tree);
        }
    }
}