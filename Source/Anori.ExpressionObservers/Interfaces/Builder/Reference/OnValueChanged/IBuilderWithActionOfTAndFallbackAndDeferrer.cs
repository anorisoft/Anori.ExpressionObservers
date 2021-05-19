// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Builder With Action Of T And Fallback And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> Build();
    }
}