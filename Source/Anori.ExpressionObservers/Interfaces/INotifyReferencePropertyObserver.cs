// -----------------------------------------------------------------------
// <copyright file="INotifyReferencePropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    ///     The Property Value Observer On Value Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface INotifyReferencePropertyObserver<out TResult> :
        IPropertyObserverBase<INotifyReferencePropertyObserver<TResult>>,
        INotifyPropertyChanged
        where TResult : class
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult? Value { get; }
    }
}