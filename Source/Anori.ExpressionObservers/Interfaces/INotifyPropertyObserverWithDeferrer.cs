// -----------------------------------------------------------------------
// <copyright file="INotifyPropertyObserverWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;
    using System.ComponentModel;

    /// <summary>
    ///     The notify property observer with deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface INotifyPropertyObserverWithDeferrer<out TResult> :
        IPropertyObserverBase<INotifyPropertyObserverWithDeferrer<TResult>>,
        INotifyPropertyChanged
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult Value { get; }

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