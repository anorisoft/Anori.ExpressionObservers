// -----------------------------------------------------------------------
// <copyright file="IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    using System;

    using Anori.Common;

    /// <summary>
    ///     The I Property Reference Observer Builder On Value Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderOnValueChanged{TResult}}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderOnValueChangedAndScheduler{TResult}}" />
    public interface IBuilder<TResult> : IObserverBuilderBase<IBuilder<TResult>>,
                                         IPropertyObserverScheduler<IBuilderWithScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Reference Observer On Notify Propery Changed.</returns>
        INotifyReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Reference Observer Builder.</returns>
        IBuilder<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilder<TResult> Cached();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> Deferred();

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
    }
}