﻿// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetterAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndFallback<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionAndGetterAndFallback<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IGetterPropertyObserver<TResult> Build();

        /// <summary>
        /// Deferreds this instance.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult> Deferred();

    }
}