// -----------------------------------------------------------------------
// <copyright file="IBuilderWithFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I value property observer builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
     public interface IBuilderWithFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithFallbackAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> Build();
    }
}