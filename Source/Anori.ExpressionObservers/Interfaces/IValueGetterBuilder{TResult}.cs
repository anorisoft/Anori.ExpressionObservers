// -----------------------------------------------------------------------
// <copyright file="IValueGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    ///     The I Value Getter Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IValueGetterBuilder<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TResult?> Create();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Getter Builder With Fallback.</returns>
        IGetterBuilderWithFallback<TResult> WithFallback(TResult fallback);
    }
}