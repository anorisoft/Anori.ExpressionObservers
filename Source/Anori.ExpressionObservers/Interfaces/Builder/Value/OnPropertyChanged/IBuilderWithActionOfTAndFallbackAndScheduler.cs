﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTAndFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    /// The I Property Value2 Observer Builder With Action Of T Result And Fallback And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTAndFallbackAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndFallbackAndScheduler<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>
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