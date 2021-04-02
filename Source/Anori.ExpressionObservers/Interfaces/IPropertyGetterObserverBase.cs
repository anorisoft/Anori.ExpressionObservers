// -----------------------------------------------------------------------
// <copyright file="IPropertyGetterObserverBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    ///     The I Property Getter Observer Base interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    public interface IPropertyObserverBase<out TSelf> : IDisposable
    {
        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        TSelf Subscribe();

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>
        ///     Self object.
        /// </returns>
        TSelf Subscribe(bool silent);

        /// <summary>
        ///     Unsubscribes this instance.
        /// </summary>
        /// <returns>Self object.</returns>
        TSelf Unsubscribe();
    }
}