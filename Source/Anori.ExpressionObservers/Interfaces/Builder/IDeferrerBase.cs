// -----------------------------------------------------------------------
// <copyright file="IDeferrerBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    ///     The deferrer base interface.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public interface IDeferrerBase<out TTarget>
    {
        /// <summary>
        ///     Builder with deferrer.
        /// </summary>
        /// <returns>The Target.</returns>
        TTarget WithDeferrer();
    }
}