// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.Common;

    /// <summary>
    /// The I Property Value Observer Builder With Value Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> Cached();


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed,</returns>
        IPropertyReferenceObserverOnValueChanged<TResult> Create();

    }
}