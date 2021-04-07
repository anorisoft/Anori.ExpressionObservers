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
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TResult}}" />
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TParameter1, TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TParameter1, TResult}}" />
    public interface IPropertyValueObserverBuilderWithValueChanged<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithValueChanged<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> Cached();


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed,</returns>
        IPropertyValueObserverOnValueChanged<TResult> Create();

    }
}