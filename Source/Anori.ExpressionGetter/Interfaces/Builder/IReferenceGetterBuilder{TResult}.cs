// -----------------------------------------------------------------------
// <copyright file="IReferenceGetterBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The Reference Getter Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IReferenceGetterBuilder<TResult>
        where TResult : class
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
        /// <returns>The Getter Builder with Fallback.</returns>
        IGetterBuilderWithFallback<TResult> WithFallback(TResult fallback);
    }
}