﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The I property reference observer builder With Action Of T Result And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndGetter<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetter<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndGetter<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> WithFallback(TResult fallback);
    }
}