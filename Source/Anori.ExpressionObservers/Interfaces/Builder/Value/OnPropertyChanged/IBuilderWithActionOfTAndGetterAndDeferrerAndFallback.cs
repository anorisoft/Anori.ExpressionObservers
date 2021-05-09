// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndDeferrerAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionOfTAndGetterAndDeferrerAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndDeferrerAndFallback<TResult>>,
        IPropertyObserverScheduler<IBuilderWithActionOfTAndGetterAndDeferrerAndFallbackAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserverAndDeferrer<TResult> Build();


    }
}