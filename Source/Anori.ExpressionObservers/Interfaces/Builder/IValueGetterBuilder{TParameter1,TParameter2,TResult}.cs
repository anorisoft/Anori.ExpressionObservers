﻿// -----------------------------------------------------------------------
// <copyright file="IValueGetterBuilder{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The Value Getter Builder interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IValueGetterBuilder<in TParameter1, in TParameter2, TResult>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TParameter1, TParameter2, TResult?> Build();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder With Fallback.</returns>
        IGetterBuilderWithFallback<TParameter1, TParameter2, TResult> WithFallback(TResult fallback);
    }
}