// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    /// The Property Reference Observer Builder With Action Of T Result And Getter And Fallback And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<out TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithGetterAndFallback<TResult> Build();
    }
}