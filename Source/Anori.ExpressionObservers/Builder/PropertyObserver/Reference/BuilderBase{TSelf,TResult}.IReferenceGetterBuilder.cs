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
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IReferenceObserverBuilder<TResult>
    {
        /// <summary>
        ///     Withes the notify property changed.
        /// </summary>
        /// <returns>
        ///     The Value property observer builder.
        /// </returns>
        IBuilder<TResult> IReferenceObserverBuilder<TResult>.OnPropertyChanged() => this.OnPropertyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Value property observer builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilder<TResult> IReferenceObserverBuilder<TResult>.
            OnValueChanged() =>
            this.OnValueChanged();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IReferenceObserverBuilder<TResult>.WithAction(Action<TResult> action) =>
            this.WithActionWithNewValueWithFallback(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value property observer builder.
        /// </returns>
        IBuilderWithAction<TResult> IReferenceObserverBuilder<TResult>.WithAction(Action action) =>
            this.WithAction(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> IReferenceObserverBuilder<TResult>.WithNullableAction(
            Action<TResult?> action) =>
            this.WithNullableActionWitNewValue(action);
    }
}