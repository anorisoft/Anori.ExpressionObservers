// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResult.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    public interface IPropertyReferenceObserverBuilderWithActionOfTResult<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResult<TResult>>,
        IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>
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