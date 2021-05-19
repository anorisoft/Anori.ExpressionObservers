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
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        TSelf Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        TSelf Cached();
    }
}