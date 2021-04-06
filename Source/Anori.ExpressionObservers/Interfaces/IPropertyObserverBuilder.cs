﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     The I Property Observer Builder interface.
    /// </summary>
    public interface IPropertyObserverBuilder
    {
        /// <summary>
        ///     Values the observer builder.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilder<TResult> ValueObserverBuilder<TParameter1, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct;

        IPropertyValueObserverBuilder<TResult> ValueObserverBuilder<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : struct;


        IPropertyValueObserverBuilder<TResult> ValueObserverBuilder<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression)
            where TResult : struct;
    }
}