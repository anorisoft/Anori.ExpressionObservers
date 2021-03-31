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
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TParameter1,TResult}" />
    public interface IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult> : 
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithAction<TParameter1, TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult> Cached(LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None);
    }
}