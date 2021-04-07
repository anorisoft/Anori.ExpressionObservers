// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverWithGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer With Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyReferenceObserverWithGetter<TResult> : IPropertyObserverBase<IPropertyReferenceObserverWithGetter<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        TResult? Value { get; }
    }
}