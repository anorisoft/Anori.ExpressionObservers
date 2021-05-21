// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The value property observer builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetterAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndFallback<TResult>>,
        ISchedulerBase<IBuilderWithActionAndGetterAndFallback<TResult>>,
        IDeferBase<IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IGetterPropertyObserver<TResult> Build();
    }
}