// -----------------------------------------------------------------------
// <copyright file="IPropertyObserverOnNotifyPropertyChangedWithFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Property Observer On Notify Propery Changed With Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverOnNotifyPropertyChangedWithFallback{TResult}}" />
    public interface IPropertyObserverOnNotifyPropertyChangedWithFallback<out TResult> : IPropertyObserverBase<
        IPropertyObserverOnNotifyPropertyChangedWithFallback<TResult>>
    {
    }

    public interface IPropertyObserverOnNotifyPropertyChangedWithDeferrer<out TResult> : IPropertyObserverBase<
        IPropertyObserverOnNotifyPropertyChangedWithDeferrer<TResult>>
    {
    }
}