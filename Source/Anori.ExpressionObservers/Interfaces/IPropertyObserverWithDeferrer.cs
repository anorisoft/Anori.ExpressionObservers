// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The Property Observer With Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverWithDeferrer{TResult}}" />
    public interface IPropertyObserverWithDeferrer<TResult> : IPropertyObserverBase<IPropertyObserverWithDeferrer<TResult>>
    {
    }
}