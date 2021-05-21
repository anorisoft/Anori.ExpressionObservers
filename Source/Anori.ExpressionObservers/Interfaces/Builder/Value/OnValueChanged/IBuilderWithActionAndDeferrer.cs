// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The value property observer builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The property observer.</returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> Build();

        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The property observer builder.</returns>
        IBuilderWithActionAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}