// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    /// The I Property Value2 Observer Builder With Action Of T Result And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTAndGetterAndFallback{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndGetterAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>,
        IPropertyObserverScheduler<IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserver<TResult> Build();
    }
}