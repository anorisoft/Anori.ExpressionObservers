﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfNullableTAndGetterAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The I Property Value2 Observer Builder With Action Of T Result Nullable And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfNullTAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfNullTAndGetterAndScheduler<TResult> :
        IObserverBuilderBase<
            IBuilderWithActionOfNullTAndGetterAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> Build();
    }
}