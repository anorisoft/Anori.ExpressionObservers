// -----------------------------------------------------------------------
// <copyright file="IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    using System;

    /// <summary>
    ///     The value property observer builder with notify property changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilder<TResult> : IObserverBuilderBase<IBuilder<TResult>>,
                                         ISchedulerBase<IBuilder<TResult>>,
                                         ICacheBase<IBuilder<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionOfNullT<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithAction<TResult> WithAction(Action action);
    }
}