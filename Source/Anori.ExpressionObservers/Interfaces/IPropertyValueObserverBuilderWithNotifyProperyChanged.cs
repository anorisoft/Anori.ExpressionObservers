// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithNotifyProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.Common;

    /// <summary>
    /// The I Property Value Observer Builder With Notify Propery Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    public interface IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> Cached();

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed.</returns>
        IPropertyValueObserverOnNotifyProperyChanged<TResult> Create();
    }
}