﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase.cs" company="Anorisoft">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    /// <summary>
    /// Property Observer Base for flurnent.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    public abstract class PropertyObserverBase<TSelf> : PropertyObserverBase
        where TSelf : PropertyObserverBase<TSelf>
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>Self object.</returns>
        public new TSelf Subscribe() => this.Subscribe(false);

        /// <summary>
        /// Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>Self object.</returns>
        public new TSelf Subscribe(bool silent)
        {
            base.Subscribe(silent);
            return (TSelf)this;
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <returns>Self object.</returns>
        public new TSelf Unsubscribe()
        {
            base.Unsubscribe();

            return (TSelf)this;
        }
    }
}