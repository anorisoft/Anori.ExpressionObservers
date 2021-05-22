// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The value property observer builder base class.
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
        IBuilderWithActionOfT<TResult> IBuilder<TResult>.WithAction(Action<TResult> action) =>
            this.WithActionWithNewValueWithFallback(action);

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> IBuilder<TResult>.WithNullableAction(Action<TResult?> action) =>
            this.WithNullableActionWithNewValue(action);

        /// <summary>
        ///     Builder with cache.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> ICacheBase<IBuilder<TResult>>.WithCache() => this.WithCache();

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
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
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