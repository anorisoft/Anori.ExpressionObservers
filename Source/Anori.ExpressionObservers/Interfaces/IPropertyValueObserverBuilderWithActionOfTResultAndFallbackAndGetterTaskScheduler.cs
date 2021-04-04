// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result And Fallback And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<out TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyGetterObserverWithFallback<TResult> Create();
    }
}