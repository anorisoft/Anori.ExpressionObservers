﻿// -----------------------------------------------------------------------
// <copyright file="IValueObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The Value property observer builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IValueObserverBuilder<TResult>
       where TResult : struct
    {
        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>The Value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilder<TResult> OnPropertyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Value property observer builder.</returns>
        Value.OnValueChanged.IBuilder<TResult> OnValueChanged();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value property observer builder.</returns>
        Value.OnPropertyChanged.IBuilderWithAction<TResult> WithAction(Action action);
    }
}