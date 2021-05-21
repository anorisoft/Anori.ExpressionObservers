// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I value property observer builder With Action Of T Result And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndGetter<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetter<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndGetter<TResult>>,
        IDeferBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> WithFallback(TResult fallback);
    }
}