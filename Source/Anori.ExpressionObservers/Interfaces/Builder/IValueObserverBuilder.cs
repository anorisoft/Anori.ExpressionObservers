﻿// -----------------------------------------------------------------------
// <copyright file="IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    /// <summary>
    ///     The Value2 Property Observer Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IBuilder{TResult}}" />
    public interface IValueObserverBuilder<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Value2 Property Observer Builder.</returns>
        Value.OnPropertyChanged.IBuilder<TResult> OnProperyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Value2 Property Observer Builder.</returns>
        Value.OnValueChanged.IBuilder<TResult> OnValueChanged();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value2 Property Observer Builder.</returns>
        Value.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value2 Property Observer Builder.</returns>
        Value.OnPropertyChanged.IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value2 Property Observer Builder.</returns>
        Value.OnPropertyChanged.IBuilderWithAction<TResult> WithAction(Action action);
    }
}