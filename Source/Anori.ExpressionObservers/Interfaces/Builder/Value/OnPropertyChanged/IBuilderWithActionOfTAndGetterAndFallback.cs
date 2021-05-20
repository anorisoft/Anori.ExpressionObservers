// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The property value observer builder With Action Of T Result And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndGetterAndFallback<TResult> :
       IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>,
       ISchedulerBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>,
       IDeferBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>
       where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterPropertyObserver<TResult> Build();
    }
}