﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    using Anori.Common;

    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetter{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithAction{TResult}}" />
    public interface IBuilderWithActionAndGetterAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>

        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IGetterValuePropertyObserver<TResult> Build();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> Cached();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> WithFallback(TResult fallback);
    }
}