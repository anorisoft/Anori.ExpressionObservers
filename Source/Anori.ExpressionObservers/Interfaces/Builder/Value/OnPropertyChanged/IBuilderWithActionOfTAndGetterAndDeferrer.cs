// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionOfTAndGetterAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}