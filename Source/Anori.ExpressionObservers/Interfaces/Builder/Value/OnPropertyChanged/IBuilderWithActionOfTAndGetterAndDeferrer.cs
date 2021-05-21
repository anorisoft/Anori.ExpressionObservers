// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    /// The builder with action of T and getter and deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndDeferrer{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.ISchedulerBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndDeferrer{TResult}}" />
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