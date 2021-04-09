// -----------------------------------------------------------------------
// <copyright file="IPropertyObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Property Observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBase{TSelf}.ExpressionObservers.Builder.IPropertyObserver{TResult}}" />
    public interface IPropertyObserver<TResult> : IPropertyObserverBase<IPropertyObserver<TResult>>
    {
    }
}