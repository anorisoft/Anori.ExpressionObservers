// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter And Fallback And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}}" />
    public interface IBuilderWithActionAndFallbackAndScheduler<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndFallbackAndScheduler<TResult>>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        INotifyPropertyObserver<TResult> Build();
    }
}