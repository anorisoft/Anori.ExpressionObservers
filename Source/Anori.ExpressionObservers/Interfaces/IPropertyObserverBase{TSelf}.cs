// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverBase{TSelf}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    using Anori.Common;

    /// <summary>
    ///     The I Property Getter Observer Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IPropertyObserverBase<out TSelf> : IActivatable<TSelf>, IDisposable
    {
        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>
        ///     Self object.
        /// </returns>
        TSelf Activate(bool silent);
    }
}