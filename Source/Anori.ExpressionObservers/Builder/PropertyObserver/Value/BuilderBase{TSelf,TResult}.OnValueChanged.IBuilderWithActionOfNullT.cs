﻿// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithActionOfNullT.cs" company="AnoriSoft">
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfNullT<TResult>
    {
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilderWithActionOfNullT<TResult> IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> ISchedulerBase<IBuilderWithActionOfNullT<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> ISchedulerBase<IBuilderWithActionOfNullT<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        INotifyValuePropertyObserver<TResult> IBuilderWithActionOfNullT<TResult>.Build() =>
            this.CreateNotifyValuePropertyObserverWithActionOfNullT();

        /// <summary>
        ///    Builder with deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> IDeferrerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.WithDeferrer() => this;
    }
}