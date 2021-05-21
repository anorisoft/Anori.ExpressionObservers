﻿// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndGetter<TResult>
    {
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionAndGetter<TResult> IObserverBuilderBase<IBuilderWithActionAndGetter<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> IBuilderWithActionAndGetter<TResult>.Build()
        {
            if (this.IsCached)
            {
                return this.CreateGetterReferencePropertyObserverCached();
            }

            return this.CreateGetterReferencePropertyObserver();
        }

        /// <summary>
        ///     Builder with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> IBuilderWithActionAndGetter<TResult>.WithFallback(
            TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetter<TResult> ISchedulerBase<IBuilderWithActionAndGetter<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetter<TResult> ISchedulerBase<IBuilderWithActionAndGetter<TResult>>.WithScheduler(
            TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);

        /// <summary>
        ///    Builder with deferrer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> IDeferBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>.
            WithDeferrer() =>
            this;

        /// <summary>
        /// Builder with cache.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetter<TResult> ICacheBase<IBuilderWithActionAndGetter<TResult>>.WithCache(
            LazyThreadSafetyMode safetyMode) =>
            this.WithCache(safetyMode);

        /// <summary>
        /// Builder with cache.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetter<TResult> ICacheBase<IBuilderWithActionAndGetter<TResult>>.WithCache() => this.WithCache();
    }
}