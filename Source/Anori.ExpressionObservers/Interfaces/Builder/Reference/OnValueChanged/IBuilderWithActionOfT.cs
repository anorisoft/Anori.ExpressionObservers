// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I property reference observer builder With Action Of T Result And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfT<TResult> : IObserverBuilderBase<IBuilderWithActionOfT<TResult>>,
                                                      ISchedulerBase<IBuilderWithActionOfT<TResult>>,
                                                      IDeferrerBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> WithFallback(TResult fallback);
    }
}