// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverWithGetterAndFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Property Observer With Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface
        IPropertyObserverOnNotifyProperyChangedWithGetterAndFallback<out TResult> : IPropertyObserverBase<
            IPropertyObserverOnNotifyProperyChangedWithGetterAndFallback<TResult>>
    {
        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult GetValue();
    }
}