// -----------------------------------------------------------------------
// <copyright file="IBuilderOnProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    using System;

    using Anori.Common;

    /// <summary>
    ///     The I Property Value2 Observer Builder With Notify Propery Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnProperyChanged{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnProperyChanged{TResult}}" />
    /// <seealso cref="IBuilderOnProperyChanged{TResult}" />
    public interface IBuilder<TResult> : IObserverBuilderBase<IBuilder<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value2 Property Observer Builder.</returns>
        IBuilderWithActionOfNullT<TResult> WithAction(Action<TResult?> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value2 Property Observer Builder.</returns>
        IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value2 Property Observer Builder.</returns>
        IBuilderWithAction<TResult> WithAction(Action action);
    }
}