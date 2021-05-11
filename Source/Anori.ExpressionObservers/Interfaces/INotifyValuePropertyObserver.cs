// -----------------------------------------------------------------------
// <copyright file="INotifyValuePropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    ///     The I Property Value Observer On Notify Property Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface INotifyValuePropertyObserver<TResult> :
        IPropertyObserverBase<INotifyValuePropertyObserver<TResult>>,
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
    }
}