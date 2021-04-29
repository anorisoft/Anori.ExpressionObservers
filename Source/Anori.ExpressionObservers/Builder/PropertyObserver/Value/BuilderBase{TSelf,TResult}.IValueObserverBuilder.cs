// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.ExpressionObservers.Interfaces.Builder;
    using System;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IValueObserverBuilder<TResult>
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithAction<TResult> IValueObserverBuilder<TResult>.WithAction(
            Action action) =>
            this.WithAction(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> IValueObserverBuilder<TResult>.
            WithAction(Action<TResult?> action) =>
            this.WithActionOfT(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfT<TResult> IValueObserverBuilder<TResult>.WithAction(
            Action<TResult> action) =>
            this.WithActionOfTWithFallback(action);

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Value.OnPropertyChanged.IBuilder<TResult> IValueObserverBuilder<TResult>.
            OnProperyChanged() =>
            this.OnProperyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Value.OnValueChanged.IBuilder<TResult> IValueObserverBuilder<TResult>.
            OnValueChanged() =>
            this.OnValueChanged();
    
    }
}