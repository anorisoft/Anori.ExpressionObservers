// -----------------------------------------------------------------------
// <copyright file="IPropertyValueGetterObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Property Value Getter Observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IPropertyObserverBase{TSelf}.ExpressionObservers.ValueTypeObservers.IPropertyValueGetterObserver{TResult}}" />
    public interface
        IPropertyValueObserver<TResult> : IPropertyObserverBase<
            IPropertyValueObserver<TResult>>
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