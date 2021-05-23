// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Reference
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndGetter<TResult>
    {
        /// <summary>
        ///     Builder with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The property observer builder.</returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> IBuilderWithActionOfTAndGetter<TResult>.WithFallback(
            TResult fallback) =>
            this.WithFallback(fallback);
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetter<TResult> IObserverBuilderBase<IBuilderWithActionOfTAndGetter<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetter<TResult> ISchedulerBase<IBuilderWithActionOfTAndGetter<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetter<TResult> ISchedulerBase<IBuilderWithActionOfTAndGetter<TResult>>.WithScheduler(
            TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}