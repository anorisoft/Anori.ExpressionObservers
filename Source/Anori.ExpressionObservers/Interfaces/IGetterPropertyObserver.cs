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
    public interface IGetterPropertyObserver<out TResult> : IPropertyObserverBase<IGetterPropertyObserver<TResult>>
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The value getter.</returns>
        TResult GetValue();
    }
}