// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}