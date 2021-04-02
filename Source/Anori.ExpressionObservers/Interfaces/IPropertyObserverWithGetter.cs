// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverWithGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Observer With Getter interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyObserverWithGetter<TParameter1, TResult> : IPropertyObserverBase<
        IPropertyObserverWithGetter<TParameter1, TResult>>
    {
    }
}