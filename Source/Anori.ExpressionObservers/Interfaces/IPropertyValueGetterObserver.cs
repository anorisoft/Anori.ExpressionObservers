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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IPropertyGetterObserverBase{TSelf}.ExpressionObservers.ValueTypeObservers.IPropertyValueGetterObserver{TParameter1, TResult}}" />
    public interface
        IPropertyValueGetterObserver<TParameter1, TResult> : IPropertyGetterObserverBase<
            IPropertyValueGetterObserver<TParameter1, TResult>>
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