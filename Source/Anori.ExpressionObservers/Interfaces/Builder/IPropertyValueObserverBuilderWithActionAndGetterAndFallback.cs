﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilderWithActionAndGetterAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>,
        IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IPropertyObserverWithGetterAndFallback<TResult> Build();
    }
}