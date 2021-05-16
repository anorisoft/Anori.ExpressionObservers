﻿// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using System.Threading.Tasks;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfNullT<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> Interfaces.Builder.IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> IBuilderWithActionOfNullT<TResult>.Build() =>
            this.CreatePropertyReferenceObserver();

        /// <summary>
        /// Deferreds this instance.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> IDeferBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.Deferred() => this;

        /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndGetter<TResult> IBuilderWithActionOfNullT<TResult>.WithGetter() => this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> Interfaces.Builder.ISchedulerBase<IBuilderWithActionOfNullT<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> Interfaces.Builder.ISchedulerBase<IBuilderWithActionOfNullT<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}