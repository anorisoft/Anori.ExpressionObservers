// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    public interface IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<out TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndGetterAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        IPropertyObserverWithGetterAndFallback<TResult> Build();
    }
}