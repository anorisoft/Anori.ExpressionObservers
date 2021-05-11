// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    /// The I Builder With Action Of Null T And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfNullTAndDeferrer{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderSchedulerBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfNullTAndDeferrer{TResult}}" />
    public interface IBuilderWithActionOfNullTAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>§
        ///     The Property Observer.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> Build();
    }
}