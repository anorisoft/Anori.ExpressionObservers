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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilder<TParameter1, TResult> : IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilder<TParameter1, TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithAction<TParameter1, TResult> WithAction(Action action);

        /// <summary>
        /// Withes the notify propery changed.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult> WithNotifyProperyChanged();


        /// <summary>
        /// Withes the value changed.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> WithValueChanged();
    }
}