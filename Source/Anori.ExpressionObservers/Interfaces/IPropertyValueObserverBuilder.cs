// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    ///     The Value Property Observer Builder interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilder<TResult> : IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilder<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        /// Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithAction<TResult> WithAction(Action action);

        /// <summary>
        /// Withes the notify propery changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> WithNotifyProperyChanged();


        /// <summary>
        /// Withes the value changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> WithValueChanged();
    }
}