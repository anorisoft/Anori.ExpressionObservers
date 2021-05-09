// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndDeferrerAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionOfTAndGetterAndDeferrerAndScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndDeferrerAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrerAndScheduler<TResult> WithFallback(TResult fallback);

       

    }
}