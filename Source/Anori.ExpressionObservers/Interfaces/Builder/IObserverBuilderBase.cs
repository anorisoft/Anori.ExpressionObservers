﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverBuilderBase{TSelf}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    ///     The I Property Value2 Observer Builder Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IObserverBuilderBase<out TSelf>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        TSelf AutoActivate();
    }
}