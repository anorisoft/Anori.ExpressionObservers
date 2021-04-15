// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverOnNotifyProperyChanged{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.ComponentModel;

    /// <summary>
    ///     The Property Value Observer On Notify Propery Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverOnNotifyProperyChanged{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IPropertyReferenceObserverOnNotifyProperyChanged<out TResult> :
        IPropertyObserverBase<IPropertyReferenceObserverOnNotifyProperyChanged<TResult>>,
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