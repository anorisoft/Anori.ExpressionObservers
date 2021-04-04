// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResultAndFallback<out TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>>
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