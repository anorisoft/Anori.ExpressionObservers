// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilder<TResult>
    {
        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithAction<TResult> IBuilder<TResult>.WithAction(Action action) => this.WithAction(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> IBuilder<TResult>.WithAction(Action<TResult?> action) =>
            this.WithActionWithNewValue(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IBuilder<TResult>.WithAction(Action<TResult> action) =>
            this.WithActionOfTWithFallback(action);

        /// <summary>
        ///     Builder with cache.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> ICacheBase<IBuilder<TResult>>.WithCache(LazyThreadSafetyMode safetyMode) =>
            this.WithCache(safetyMode);

        /// <summary>
        ///     Builder with cache.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> ICacheBase<IBuilder<TResult>>.WithCache() => this.WithCache();

        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> IObserverBuilderBase<IBuilder<TResult>>.AutoActivate() => this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilder<TResult> ISchedulerBase<IBuilder<TResult>>.WithGetterDispatcher() => this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilder<TResult> ISchedulerBase<IBuilder<TResult>>.WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}