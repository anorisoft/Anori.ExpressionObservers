// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverOnProperyChanged.cs" company="AnoriSoft">
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
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverOnProperyChanged{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IGetterPropertyObserver<out TResult> :
        IPropertyObserverBase<IGetterPropertyObserver<TResult>>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns></returns>
        TResult GetValue();

    }
}