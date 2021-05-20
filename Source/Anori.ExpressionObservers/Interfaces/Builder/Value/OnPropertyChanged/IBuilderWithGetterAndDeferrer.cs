// -----------------------------------------------------------------------
// <copyright file="IBuilderWithGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The property reference observer builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface
        IBuilderWithGetterAndDeferrer<TResult> : IObserverBuilderBase<IBuilderWithGetterAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        IPropertyObserverWithDeferrer<TResult> Build();
    }
}