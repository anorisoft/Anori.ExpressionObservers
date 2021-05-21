// -----------------------------------------------------------------------
// <copyright file="IReferenceObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The value property observer builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IReferenceObserverBuilder<TResult>
        where TResult : class
    {
        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilder<TResult> OnPropertyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        Reference.OnValueChanged.IBuilder<TResult> OnValueChanged();

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

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionOfNullT<TResult> WithNullableAction(Action<TResult?> action);
    }
}