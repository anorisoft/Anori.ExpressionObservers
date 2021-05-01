// -----------------------------------------------------------------------
// <copyright file="IGetterReferencePropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Property Reference Observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserver{TResult}}" />
    public interface IGetterReferencePropertyObserver<out TResult> : IPropertyObserverBase<
        IGetterReferencePropertyObserver<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        TResult? GetValue();
    }
}