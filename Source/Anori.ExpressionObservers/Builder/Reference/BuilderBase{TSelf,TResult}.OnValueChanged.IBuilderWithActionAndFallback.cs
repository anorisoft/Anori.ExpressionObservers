// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithActionAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Reference
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndFallback<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        INotifyPropertyObserver<TResult> IBuilderWithActionAndFallback<TResult>.Build() =>
            this.CreateNotifyPropertyObserverWithActionAndFallback();

        /// <summary>
        ///     Builder with deferrer.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionAndFallbackAndDeferrer<TResult>
            IDeferrerBase<IBuilderWithActionAndFallbackAndDeferrer<TResult>>.WithDeferrer() =>
            this;
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndFallback<TResult> IObserverBuilderBase<IBuilderWithActionAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndFallback<TResult> ISchedulerBase<IBuilderWithActionAndFallback<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndFallback<TResult> ISchedulerBase<IBuilderWithActionAndFallback<TResult>>.WithScheduler(
            TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}