// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndGetterAndDeferrer.cs" company="AnoriSoft">
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndGetterAndDeferrer<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The property value observer builder.</returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult>
            IObserverBuilderBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterReferencePropertyObserverWithDeferrer<TResult> IBuilderWithActionAndGetterAndDeferrer<TResult>.Build() =>
            this.CreateGetterReferencePropertyObserverAndDeferrer();

        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult> IBuilderWithActionAndGetterAndDeferrer<TResult>.
            WithFallback(TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The property value observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> ISchedulerBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> ISchedulerBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The property value observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> ICacheBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>.
            WithCache(LazyThreadSafetyMode safetyMode) =>
            this.WithCache(safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The property value observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> ICacheBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>.
            WithCache() =>
            this.WithCache();
    }
}