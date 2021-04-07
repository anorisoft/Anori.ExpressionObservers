// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResult.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    public interface IPropertyValueObserverBuilderWithActionOfTResult<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResult<TResult>>,
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