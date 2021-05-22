// -----------------------------------------------------------------------
// <copyright file="ICacheBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using Anori.Common;

    /// <summary>
    ///     The Cache Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface ICacheBase<out TSelf>
    {
        /// <summary>
        /// Builder with cache whit specified mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The value property observer builder.</returns>
        TSelf WithCache(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Builder with cache.
        /// </summary>
        /// <returns>
        /// The value property observer builder.
        /// </returns>
        TSelf WithCache();
    }
}