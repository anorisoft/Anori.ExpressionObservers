// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The value property observer builder with action of T Result and getter and fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndGetterAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>,
        IDeferrerBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>
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