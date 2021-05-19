// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithActionOfTAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndFallback<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyPropertyObserver<TResult> IBuilderWithActionOfTAndFallback<TResult>.Build() =>
            this.CreateNotifyPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Deferreds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>
            IDeferBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>.Deferred() =>
            this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> ISchedulerBase<IBuilderWithActionOfTAndFallback<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> ISchedulerBase<IBuilderWithActionOfTAndFallback<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}