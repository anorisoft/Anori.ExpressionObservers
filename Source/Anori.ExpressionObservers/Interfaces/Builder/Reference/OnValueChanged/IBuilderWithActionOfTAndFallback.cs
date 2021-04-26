﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback{TResult}}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>,
        IPropertyObserverScheduler<
            IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>
        where TResult : class
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