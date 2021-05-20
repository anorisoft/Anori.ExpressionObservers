// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    public interface IBuilderWithActionOfTAndGetterAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>,
    ISchedulerBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property value observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}