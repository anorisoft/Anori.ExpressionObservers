// -----------------------------------------------------------------------
// <copyright file="IGetterPropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The Property Observer On Notify Property Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverOnPropertyChanged{TResult}}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IGetterPropertyObserver<out TResult> : IPropertyObserverBase<IGetterPropertyObserver<TResult>>
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The value getter.</returns>
        TResult GetValue();
    }
}