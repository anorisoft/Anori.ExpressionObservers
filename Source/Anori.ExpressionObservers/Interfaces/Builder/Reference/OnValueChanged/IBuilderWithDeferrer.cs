// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderOnValueChangedAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    /// The Property Reference Observer Builder With Value2 Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithDeferrer<out TResult> :
    IObserverBuilderBase<IBuilderWithDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>
        /// The Property Value2 Observer.
        /// </returns>
        INotifyReferencePropertyObserverWithDeferrer<TResult> Build();
    }
}