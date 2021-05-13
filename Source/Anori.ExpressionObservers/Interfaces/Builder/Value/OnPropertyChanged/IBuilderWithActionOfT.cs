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
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfT{TResult}}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfT{TResult}}" />
    public interface IBuilderWithActionOfT<TResult> : IObserverBuilderBase<IBuilderWithActionOfT<TResult>>
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

        /// <summary>
        ///     Deferreds this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionOfTAndDeferrer<TResult> Deferred();
    }
}