// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action Of T And Getter And Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndGetterAndScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult> WithFallback(TResult fallback);
    }
}