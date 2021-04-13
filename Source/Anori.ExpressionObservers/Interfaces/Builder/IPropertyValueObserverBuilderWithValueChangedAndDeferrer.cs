// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithValueChangedAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    /// The I Property Value Observer Builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithValueChangedAndDeferrer{TResult}}" />
    public interface IPropertyValueObserverBuilderWithValueChangedAndDeferrer<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithValueChangedAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>
        /// The Property Value Observer.
        /// </returns>
        IPropertyValueObserverOnValueChangedWithDeferrer<TResult> Build();
    }
}