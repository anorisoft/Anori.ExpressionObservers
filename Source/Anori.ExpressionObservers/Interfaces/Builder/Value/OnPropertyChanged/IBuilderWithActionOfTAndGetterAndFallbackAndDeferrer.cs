// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserverWithDeferrer<TResult> Build();
    }
}