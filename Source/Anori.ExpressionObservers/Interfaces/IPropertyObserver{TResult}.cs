// -----------------------------------------------------------------------
// <copyright file="IPropertyObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The Property Observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyObserver<TResult> : IPropertyObserverBase<IPropertyObserver<TResult>>
    {
    }
}