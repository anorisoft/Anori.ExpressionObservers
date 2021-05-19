// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Builder With Action Of T And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}