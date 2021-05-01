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
    ///     The Value Property Observer Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IReferenceObserverBuilder<TResult>
        where TResult : class
    {
        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilder<TResult> OnProperyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        Reference.OnValueChanged.IBuilder<TResult> OnValueChanged();

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

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionOfNullT<TResult> WithNullableAction(Action<TResult?> action);
    }
}