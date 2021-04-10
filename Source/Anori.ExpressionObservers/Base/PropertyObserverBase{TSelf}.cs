// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBase{TSelf}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     Property Observer Base for flurnent.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <seealso cref="PropertyObserverBase" />
    internal abstract class PropertyObserverBase<TSelf> : PropertyObserverBase, IPropertyObserverBase<TSelf>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverBase{TSelf}" /> class.
        /// </summary>
        /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
        protected PropertyObserverBase(PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        /// <exception cref="Anori.ExpressionObservers.Exceptions.AlreadyActivatedException"></exception>
        public new TSelf Activate()
        {
            return this.Activate(false);
        }

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