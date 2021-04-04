// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    /// The I Property Value Observer Builder With Action And Getter And Fallback And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<out TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IPropertyObserverWithGetterAndFallback<TResult> Create();
    }
}