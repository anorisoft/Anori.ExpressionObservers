// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderOnValueChangedAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    /// The Property Reference Observer Builder With Value2 Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithDeferrer<TResult> :
    IObserverBuilderBase<IBuilderWithDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>
        /// The Property Value2 Observer.
        /// </returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> Build();
    }
}