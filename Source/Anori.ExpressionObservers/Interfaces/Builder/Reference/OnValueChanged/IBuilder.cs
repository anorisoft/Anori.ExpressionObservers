﻿// -----------------------------------------------------------------------
// <copyright file="IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    using System;

    /// <summary>
    ///     The I Property Reference Observer Builder On Value Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilder<TResult> : IObserverBuilderBase<IBuilder<TResult>>,
                                         ISchedulerBase<IBuilder<TResult>>,
                                         IDeferBase<IBuilderWithDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Reference Observer On Notify Property Changed.</returns>
        INotifyReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithAction<TResult> WithAction(Action action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> WithNullableAction(Action<TResult?> action);


        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> WithAction(Action<TResult, TResult> action);

        /// <summary>
        ///     Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> WithNullableAction(Action<TResult?, TResult?> action);
    }
}