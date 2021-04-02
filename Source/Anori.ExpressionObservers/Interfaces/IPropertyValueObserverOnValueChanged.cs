// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverOnValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// The I Property Value Observer On Value Changed interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverOnValueChanged<TResult> : IPropertyObserverBase<IPropertyValueObserverOnValueChanged<TResult>>, INotifyPropertyChanged, IDisposable
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