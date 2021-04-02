// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverOnNotifyProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The I Property Value Observer On Notify Propery Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IPropertyValueObserverOnNotifyProperyChanged<TResult> : IPropertyObserverBase<IPropertyValueObserverOnNotifyProperyChanged<TResult>>, INotifyPropertyChanged ,IDisposable
        where TResult : struct

    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public TResult? Value { get; }
    }
}