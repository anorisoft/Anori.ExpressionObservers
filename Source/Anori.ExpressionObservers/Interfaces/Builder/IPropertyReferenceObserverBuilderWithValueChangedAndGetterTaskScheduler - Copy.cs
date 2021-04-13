// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using Anori.Common;

    /// <summary>
    /// The I Property Value Observer Builder With Value Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed,</returns>
        IPropertyReferenceObserverOnValueChangedWithDeferrer<TResult> Build();

    }
}