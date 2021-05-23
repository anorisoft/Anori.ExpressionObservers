// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Value
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndGetterAndDeferrer<TResult>
    {
        /// <summary>
        ///     Buider with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The property observer builder.</returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult> IBuilderWithActionOfTAndGetterAndDeferrer<TResult>
            .WithFallback(TResult fallback) =>
            this.WithFallback(fallback);
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndDeferrer<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndDeferrer<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndDeferrer<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndGetterAndDeferrer<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}