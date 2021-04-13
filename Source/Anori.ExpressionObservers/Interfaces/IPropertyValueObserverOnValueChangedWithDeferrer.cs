// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverOnValueChangedWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The Property Value Observer On Value Changed With Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverOnValueChangedWithDeferrer{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IPropertyValueObserverOnValueChangedWithDeferrer<TResult> :
        IPropertyObserverBase<IPropertyValueObserverOnValueChangedWithDeferrer<TResult>>,
        INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult? Value { get; }

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