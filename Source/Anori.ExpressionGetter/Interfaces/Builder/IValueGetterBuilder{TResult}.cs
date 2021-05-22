// -----------------------------------------------------------------------
// <copyright file="IValueGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The Value Getter Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IValueGetterBuilder<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance of a getter function.
        /// </summary>
        /// <returns>The getter function.</returns>
        Func<TResult?> Build();

        /// <summary>
        ///     Getter Builder with Fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder With Fallback.</returns>
        IGetterBuilderWithFallback<TResult> WithFallback(TResult fallback);
    }
}