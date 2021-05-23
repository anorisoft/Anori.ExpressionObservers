// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Value
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterPropertyObserverWithDeferrer<TResult> IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>.
            Build() =>
            this.CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer();
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}