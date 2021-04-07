// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<TResult>>,
        IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithFallback<TResult> Create();
    }
}