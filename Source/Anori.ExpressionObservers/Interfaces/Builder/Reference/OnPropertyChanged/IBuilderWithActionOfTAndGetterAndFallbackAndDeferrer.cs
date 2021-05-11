// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    /// The Builder With Action Of T And Getter And Fallback And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserverWithDeferrer<TResult> Build();
    }
}