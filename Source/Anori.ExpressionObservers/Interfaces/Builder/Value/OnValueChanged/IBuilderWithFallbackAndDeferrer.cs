// -----------------------------------------------------------------------
// <copyright file="IBuilderWithFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The I property value observer builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithFallbackAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithFallbackAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> Build();
    }
}