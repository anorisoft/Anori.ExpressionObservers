// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.IReferenceGetterBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System;

    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The builder base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IReferenceObserverBuilder<TResult>
    {
        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> IReferenceObserverBuilder<TResult>.OnPropertyChanged() => this.OnPropertyChanged();

        /// <summary>
        ///     Called when [value changed].
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilder<TResult> IReferenceObserverBuilder<TResult>.
            OnValueChanged() =>
            this.OnValueChanged();

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IReferenceObserverBuilder<TResult>.WithAction(Action<TResult> action) =>
            this.WithActionWithNewValueWithFallback(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithAction<TResult> IReferenceObserverBuilder<TResult>.WithAction(Action action) =>
            this.WithAction(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> IReferenceObserverBuilder<TResult>.WithNullableAction(
            Action<TResult?> action) =>
            this.WithNullableActionWithNewValue(action);
    }
}