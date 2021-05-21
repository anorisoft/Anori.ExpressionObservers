// -----------------------------------------------------------------------
// <copyright file="IBuilderWithDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The I value property observer builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithDeferrer<TResult> : IObserverBuilderBase<IBuilderWithDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        INotifyValuePropertyObserverWithDeferrer<TResult> Build();
    }
}