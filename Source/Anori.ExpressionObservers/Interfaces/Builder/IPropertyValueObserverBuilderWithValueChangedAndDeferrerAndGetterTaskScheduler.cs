// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    /// The I Property Value Observer Builder With Value Changed And Deferrer And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithValueChangedAndDeferrerAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>
        /// Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnValueChangedWithDeferrer<TResult> Build();

    }
}