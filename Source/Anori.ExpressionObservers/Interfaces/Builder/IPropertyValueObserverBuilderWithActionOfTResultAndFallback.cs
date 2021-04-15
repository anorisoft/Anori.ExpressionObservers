// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    /// <seealso cref="IPropertyObserverGetterTaskScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResultAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>>,
        IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithFallback<TResult> Build();

        /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult> WithGetter();
    }
}