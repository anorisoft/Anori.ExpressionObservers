// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndGetterAndFallback<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserver<TResult> IBuilderWithActionOfTAndGetterAndFallback<TResult>.Build() =>
            this.CreateGetterPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Deferreds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>
        IDeferBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>.Deferred() =>
            this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndGetterAndFallback<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}