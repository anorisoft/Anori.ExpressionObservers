// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action And Getter And Fallback And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetterAndFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IGetterPropertyObserverWithDeferrer<TResult> Build();
    }
}