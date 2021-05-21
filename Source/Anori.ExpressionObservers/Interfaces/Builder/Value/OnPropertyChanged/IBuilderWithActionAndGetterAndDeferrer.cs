// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The value property observer builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetterAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>,
        ICacheBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The property observer.</returns>
        IGetterValuePropertyObserverWithDeferrer<TResult> Build();

        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> WithFallback(TResult fallback);
    }
}