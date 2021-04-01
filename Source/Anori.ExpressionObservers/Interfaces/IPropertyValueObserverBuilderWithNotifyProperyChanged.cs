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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TResult}" />
    public interface IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> : 
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithAction<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> Cached(LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None);

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed,</returns>
        IPropertyValueObserverOnValueChanged<TResult> Create();

    }
}