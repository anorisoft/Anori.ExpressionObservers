﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfT{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfT{TResult}}" />
    public interface IBuilderWithActionOfNullT<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionOfNullT<TResult>>
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