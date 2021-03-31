// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    ///     The I Property Value Observer Builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns></returns>
        IPropertyObserverWithGetterAndFallback<TParameter1, TResult> Create();
    }
}