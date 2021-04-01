// -----------------------------------------------------------------------
// <copyright file="IPropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyGetterObserverBase{TSelf}.ExpressionObservers.Builder.IPropertyObserver{TParameter1, TResult}}" />
    public interface IPropertyObserver<TResult> : IPropertyGetterObserverBase<IPropertyObserver<TResult>>
    {
    }
}