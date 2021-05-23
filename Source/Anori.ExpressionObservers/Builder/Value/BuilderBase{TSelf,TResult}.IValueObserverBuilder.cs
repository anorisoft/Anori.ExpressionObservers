// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.IValueObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Value
{
    using System;

    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IValueObserverBuilder<TResult>
    {
        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilder<TResult> IValueObserverBuilder<TResult>.
            OnPropertyChanged() =>
            this.OnPropertyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        Interfaces.Builder.Value.OnValueChanged.IBuilder<TResult> IValueObserverBuilder<TResult>.OnValueChanged() =>
            this.OnValueChanged();

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithAction<TResult> IValueObserverBuilder<TResult>.
            WithAction(Action action) =>
            this.WithAction(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> IValueObserverBuilder<TResult>.
            WithAction(Action<TResult?> action) =>
            this.WithActionWithNewValue(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfT<TResult> IValueObserverBuilder<TResult>.
            WithAction(Action<TResult> action) =>
            this.WithActionOfTWithFallback(action);
    }
}