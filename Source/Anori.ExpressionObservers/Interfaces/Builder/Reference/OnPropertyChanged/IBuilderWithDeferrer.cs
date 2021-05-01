﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Property Reference Observer Builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithDeferrer<out TResult> : IObserverBuilderBase<IBuilderWithDeferrer<TResult>>
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