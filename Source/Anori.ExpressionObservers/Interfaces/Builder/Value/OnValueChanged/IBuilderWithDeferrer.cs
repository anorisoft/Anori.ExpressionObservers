// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderOnValueChangedAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    /// The I Property Value2 Observer Builder With Value2 Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderOnValueChangedAndDeferrer{TResult}}" />
    public interface IBuilderWithDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>
        /// The Property Value2 Observer.
        /// </returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> Build();
    }
}