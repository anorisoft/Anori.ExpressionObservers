// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverWithGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    /// <summary>
    /// The I Property Value Observer With Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverWithGetter<TResult>
        where TResult : struct
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