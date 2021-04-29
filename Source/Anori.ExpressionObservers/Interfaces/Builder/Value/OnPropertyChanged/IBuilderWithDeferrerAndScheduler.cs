﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderOnValueChangedAndDeferrerAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The Property Value2 Observer Builder With Value2 Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderOnValueChangedAndDeferrerAndScheduler{TResult}}" />
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnValueChangedAndScheduler{TResult}}" />
    public interface IBuilderWithDeferrerAndScheduler<TResult> :
        IObserverBuilderBase<
            IBuilderWithDeferrerAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Value2 Observer On Notify Propery Changed.</returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> Build();
    }
}