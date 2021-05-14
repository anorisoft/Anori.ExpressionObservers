// -----------------------------------------------------------------------
// <copyright file="IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    using System;

    using Anori.Common;

    /// <summary>
    ///     The Property Value Observer Builder With Notify Property Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilder<TResult> : IObserverBuilderBase<IBuilder<TResult>>,
                                         IObserverBuilderSchedulerBase<IBuilder<TResult>>,
                                         IObserverBuilderCacheBase<IBuilder<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionOfNullT<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithAction<TResult> WithAction(Action action);
    }
}