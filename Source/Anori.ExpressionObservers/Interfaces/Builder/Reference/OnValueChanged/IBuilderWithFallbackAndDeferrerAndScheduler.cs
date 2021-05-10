// -----------------------------------------------------------------------
// <copyright file="IBuilderWithFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Property Value Observer Builder With Value Changed And Deferrer And Getter Task Scheduler
    ///     interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderOnValueChangedAndDeferrer{TResult}}" />
    public interface IBuilderWithFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithFallbackAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> Build();
    }
}