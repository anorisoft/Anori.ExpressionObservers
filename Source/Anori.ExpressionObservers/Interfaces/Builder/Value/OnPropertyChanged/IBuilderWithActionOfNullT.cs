﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
     public interface IBuilderWithActionOfNullT<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>,
        IPropertyObserverScheduler<
            IBuilderWithActionOfNullTAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterValuePropertyObserver<TResult> Build();
    }
}