// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverOnNotifyProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    ///     The Property Observer On Notify Propery Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverOnNotifyProperyChanged{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IPropertyObserverOnNotifyProperyChanged<out TResult> :
        IPropertyObserverBase<IPropertyObserverOnNotifyProperyChanged<TResult>>,
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