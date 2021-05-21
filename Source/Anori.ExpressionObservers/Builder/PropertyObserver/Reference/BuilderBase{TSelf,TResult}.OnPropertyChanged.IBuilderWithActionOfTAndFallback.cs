﻿// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndFallback.cs" company="AnoriSoft">
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndFallback<TResult>
    {
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IPropertyObserver<TResult> IBuilderWithActionOfTAndFallback<TResult>.Build() =>
            this.CreatePropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> IBuilderWithActionOfTAndFallback<TResult>.WithGetter() =>
            this;

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> ISchedulerBase<IBuilderWithActionOfTAndFallback<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> ISchedulerBase<IBuilderWithActionOfTAndFallback<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);

        /// <summary>
        ///    Builder with deferrer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>
            IDeferrerBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>.WithDeferrer() =>
            this;
    }
}