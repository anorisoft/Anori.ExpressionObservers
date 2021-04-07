// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback<TResult>>,
        IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IPropertyObserverWithGetterAndFallback<TResult> Create();
    }
}