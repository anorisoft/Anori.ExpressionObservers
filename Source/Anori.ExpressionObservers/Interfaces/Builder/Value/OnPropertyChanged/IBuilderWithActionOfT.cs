﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I Property Value Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfT<TResult> : IObserverBuilderBase<IBuilderWithActionOfT<TResult>>,
                                                      IDeferBase<IBuilderWithActionOfTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionOfTAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The getter.</returns>
        IBuilderWithActionOfTAndGetter<TResult> WithGetter();
    }
}