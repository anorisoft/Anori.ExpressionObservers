// -----------------------------------------------------------------------
// <copyright file="IValueObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The value property observer builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IValueObserverBuilder<TResult>
       where TResult : struct
    {
        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilder<TResult> OnPropertyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        Value.OnValueChanged.IBuilder<TResult> OnValueChanged();

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilderWithAction<TResult> WithAction(Action action);
    }
}