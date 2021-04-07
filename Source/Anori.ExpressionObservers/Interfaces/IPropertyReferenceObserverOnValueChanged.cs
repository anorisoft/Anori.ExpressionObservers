// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverOnValueChanged.cs" company="AnoriSoft">
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
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverOnValueChanged{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="System.IDisposable" />
    public interface IPropertyReferenceObserverOnValueChanged<TResult> : IPropertyObserverBase<IPropertyReferenceObserverOnValueChanged<TResult>>, INotifyPropertyChanged, IDisposable
        where TResult : class
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