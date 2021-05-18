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
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilder<TResult> IObserverBuilderBase<IBuilder<TResult>>.AutoActivate() => this.AutoActivate();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilder<TResult> ICacheBase<IBuilder<TResult>>.Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilder<TResult> ICacheBase<IBuilder<TResult>>.Cached() => this.Cached();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithAction<TResult> IBuilder<TResult>.WithAction(Action action) => this.WithAction(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> IBuilder<TResult>.WithAction(Action<TResult?> action) =>
            this.WithActionOfT(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IBuilder<TResult>.WithAction(Action<TResult> action) =>
            this.WithActionOfTWithFallback(action);

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilder<TResult> ISchedulerBase<IBuilder<TResult>>.WithGetterDispatcher() => this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilder<TResult> ISchedulerBase<IBuilder<TResult>>.WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}