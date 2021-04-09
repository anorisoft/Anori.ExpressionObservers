// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverWithFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Property Getter Observer With Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IPropertyObserverBase{TSelf}.ExpressionObservers.Interfaces.IPropertyGetterObserverWithFallback{TResult}}" />
    public interface
        IPropertyObserverWithFallback<out TResult> : IPropertyObserverBase<IPropertyObserverWithFallback<TResult>>
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult Value { get; }
    }
}