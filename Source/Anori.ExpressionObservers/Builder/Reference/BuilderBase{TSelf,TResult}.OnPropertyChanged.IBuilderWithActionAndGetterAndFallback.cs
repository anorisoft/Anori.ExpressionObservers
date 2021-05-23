// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Reference
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionAndGetterAndFallback<TResult>
    {
        /// <summary>
        ///     Builder with deferrer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        public IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult> WithDeferrer() => this;

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IGetterPropertyObserver<TResult> IBuilderWithActionAndGetterAndFallback<TResult>.Build() =>
            this.CreateGetterPropertyObserverWithFallback();
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionAndGetterAndFallback<TResult>
            IObserverBuilderBase<IBuilderWithActionAndGetterAndFallback<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> ISchedulerBase<IBuilderWithActionAndGetterAndFallback<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> ISchedulerBase<IBuilderWithActionAndGetterAndFallback<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}