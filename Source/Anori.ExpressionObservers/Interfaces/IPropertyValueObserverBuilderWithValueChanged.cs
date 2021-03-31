// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.Common;

    /// <summary>
    /// The I Property Value Observer Builder With Value Changed interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TParameter1, TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TParameter1, TResult}}" />
    public interface IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> Cached(LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None);
    }
}