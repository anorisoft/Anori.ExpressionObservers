// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using System;

    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Value Property Observer Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface
        IReferenceObserverBuilder<TResult> : IObserverBuilderBase<
            IReferenceObserverBuilder<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        Reference.OnPropertyChanged.IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        Reference.OnPropertyChanged.IBuilderWithAction<TResult> WithAction(Action action);

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderOnProperyChanged<TResult> OnNotifyProperyChanged();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        Reference.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> WithNullableAction(
            Action<TResult?> action);

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilder<TResult> OnValueChanged();
    }
}