// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The builder with action of T and getter and deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndGetterAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builder with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}