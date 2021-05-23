// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The I Builder With Action Of T And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The property observer builder.</returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}