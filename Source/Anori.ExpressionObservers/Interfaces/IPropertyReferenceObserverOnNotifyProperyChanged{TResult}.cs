// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverOnNotifyPropertyChanged{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    ///     The Property Value Observer On Notify Property Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverOnNotifyPropertyChanged{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IPropertyReferenceObserverOnNotifyPropertyChanged<out TResult> :
        IPropertyObserverBase<IPropertyReferenceObserverOnNotifyPropertyChanged<TResult>>,
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