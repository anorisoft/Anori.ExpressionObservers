// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using Anori.Common;

    /// <summary>
    ///     The I Property Value Observer Builder With Value Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed,</returns>
        IPropertyValueObserverOnValueChanged<TResult> Build();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> Cached(
            LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> Cached();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler<TResult> Deferred();
    }
}