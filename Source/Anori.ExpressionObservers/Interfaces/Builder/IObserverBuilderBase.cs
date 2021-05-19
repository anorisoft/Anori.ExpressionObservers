// -----------------------------------------------------------------------
// <copyright file="IObserverBuilderBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    ///     The Property Value Observer Builder Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IObserverBuilderBase<out TSelf>
    {
        /// <summary>
        ///     Automatic activation of the property observer on build.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        TSelf AutoActivate();
    }
}