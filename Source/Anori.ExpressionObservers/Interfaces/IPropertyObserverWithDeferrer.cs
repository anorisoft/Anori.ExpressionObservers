// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    /// The Property Observer With Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverWithDeferrer{TResult}" />
    public interface IPropertyObserverWithDeferrer<TResult> : IPropertyObserverBase<IPropertyObserverWithDeferrer<TResult>>
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        bool IsDeferred { get; }

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>Disposable deferrer.</returns>
        IDisposable Defer();
    }
}