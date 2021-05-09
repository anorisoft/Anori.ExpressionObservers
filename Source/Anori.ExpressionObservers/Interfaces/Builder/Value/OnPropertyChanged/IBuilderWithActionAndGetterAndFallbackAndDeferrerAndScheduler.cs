// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndFallbackAndDeferrerAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionAndGetterAndFallbackAndDeferrerAndScheduler<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndFallbackAndDeferrerAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IGetterPropertyObserverAndDeferrer<TResult> Build();
    }
}