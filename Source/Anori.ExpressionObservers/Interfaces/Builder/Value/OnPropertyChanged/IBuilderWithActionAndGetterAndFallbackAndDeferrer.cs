// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionAndGetterAndFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IGetterPropertyObserverWithDeferrer<TResult> Build();
    }
}