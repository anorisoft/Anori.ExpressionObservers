// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The Property Reference Observer Builder With Action Of T Result And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndFallback<TResult>>,
        IDeferBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyPropertyObserver<TResult> Build();
    }
}