// -----------------------------------------------------------------------
// <copyright file="INotifyPropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    ///     The notify property observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface INotifyPropertyObserver<out TResult> : IPropertyObserverBase<INotifyPropertyObserver<TResult>>,
                                                            INotifyPropertyChanged
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult Value { get; }
    }
}