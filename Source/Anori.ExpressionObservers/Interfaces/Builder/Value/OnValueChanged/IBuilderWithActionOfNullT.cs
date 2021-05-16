﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    /// The Builder With Action Of Null T interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfNullT{TResult}}" />
    /// <seealso cref="ISchedulerBase{TSelf}.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfNullT{TResult}}" />
    public interface IBuilderWithActionOfNullT<TResult> : IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>,
                                                          ISchedulerBase<IBuilderWithActionOfNullT<TResult>>,
                                                          IDeferBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyValuePropertyObserver<TResult> Build();
    }
}