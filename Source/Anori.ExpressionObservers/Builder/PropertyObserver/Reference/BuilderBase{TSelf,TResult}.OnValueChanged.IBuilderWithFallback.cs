﻿// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyPropertyChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyPropertyChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithAction{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithFallback<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithFallback<TResult> IObserverBuilderBase<IBuilderWithFallback<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Property Changed.
        /// </returns>
        INotifyPropertyObserver<TResult> IBuilderWithFallback<TResult>.Build() =>
            this.CreateNotifyPropertyObserverWithFallback();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallback<TResult> IBuilderWithFallback<TResult>.Cached() => this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallback<TResult> IBuilderWithFallback<TResult>.Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndDeferrer<TResult> IBuilderWithFallback<TResult>.Deferred() => this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilderWithFallback<TResult> IObserverBuilderSchedulerBase<IBuilderWithFallback<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilderWithFallback<TResult> IObserverBuilderSchedulerBase<IBuilderWithFallback<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}