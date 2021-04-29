// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderOnValueChangedAndDeferrerAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The I Property Value2 Observer Builder With Value2 Changed And Deferrer And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderOnValueChangedAndDeferrerAndScheduler{TResult}}" />
    public interface IBuilderWithFallbackAndDeferrerAndScheduler<TResult> :
        IObserverBuilderBase<
            IBuilderWithFallbackAndDeferrerAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value2 Observer On Notify Propery Changed.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> Build();
    }
}