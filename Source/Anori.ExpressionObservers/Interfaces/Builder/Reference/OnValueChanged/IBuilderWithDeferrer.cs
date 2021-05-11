﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Property Value Observer Builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderOnValueChangedAndDeferrer{TResult}}" />
    public interface IBuilderWithDeferrer<TResult> : IObserverBuilderBase<IBuilderWithDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        INotifyReferencePropertyObserverWithDeferrer<TResult> Build();
    }
}