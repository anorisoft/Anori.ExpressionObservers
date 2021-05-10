// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    /// The I Builder With Action Of T And Fallback And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndFallbackAndDeferrer{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderSchedulerBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndFallbackAndDeferrer{TResult}}" />
    public interface IBuilderWithActionOfTAndFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>
        where TResult : struct
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