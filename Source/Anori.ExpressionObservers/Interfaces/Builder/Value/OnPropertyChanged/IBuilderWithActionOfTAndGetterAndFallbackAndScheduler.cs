// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action Of T And Getter And Fallback And Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<out TResult> : IObserverBuilderBase<
        IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer.
        /// </returns>
        IGetterPropertyObserver<TResult> Build();
    }
}