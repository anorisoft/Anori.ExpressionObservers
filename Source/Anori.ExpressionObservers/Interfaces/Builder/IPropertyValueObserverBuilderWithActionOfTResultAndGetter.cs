// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetter{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResultAndGetter<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndGetter<TResult>>,
        IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}