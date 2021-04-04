// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResult.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The Property Value Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResult{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResult{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResult<TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResult<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}