// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IPropertyValueObserverBuilderBase<out TSelf>
    {
        /// <summary>
        /// Automatics the activate.
        /// </summary>
        /// <returns></returns>
        TSelf AutoActivate();
    }
}