// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilder{TResult}.cs" company="AnoriSoft">
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
    public interface
        IPropertyReferenceObserverBuilder<TResult> : IPropertyObserverBuilderBase<
            IPropertyReferenceObserverBuilder<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithActionOfTResult<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithAction<TResult> WithAction(Action action);

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithNotifyProperyChanged<TResult> WithNotifyProperyChanged();
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult> WithNullableAction(
            Action<TResult?> action);

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithValueChanged<TResult> WithValueChanged();
    }
}