// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TSelf}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using System;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.Extensions;

    /// <summary>
    ///     Property Observer Base for flurnent.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    internal abstract class PropertyObserverBase<TSelf> : PropertyObserverBase, IPropertyObserverBase<TSelf>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        private bool isActive;

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>Self object.</returns>
        public new TSelf Activate() => this.Activate(false);

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>Self object.</returns>
        public new TSelf Activate(bool silent)
        {
            base.Activate(silent);
            return (TSelf)(IPropertyObserverBase<TSelf>)this;
        }

        /// <summary>
        ///     Unsubscribes this instance.
        /// </summary>
        /// <returns>Self object.</returns>
        public new TSelf Deactivate()
        {
            base.Deactivate();
            return (TSelf)(IPropertyObserverBase<TSelf>)this;
        }

      
    }
}