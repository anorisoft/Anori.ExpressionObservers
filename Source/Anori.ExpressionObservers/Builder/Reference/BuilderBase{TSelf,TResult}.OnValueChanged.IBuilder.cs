// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilder<TResult>
    {
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The value property observer builder.</returns>
        IBuilder<TResult> IObserverBuilderBase<IBuilder<TResult>>.AutoActivate() => this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     value property observer On Notify Property Changed.
        /// </returns>
        INotifyReferencePropertyObserver<TResult> IBuilder<TResult>.Build() =>
            this.CreateNotifyReferencePropertyObserver();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> IDeferrerBase<IBuilderWithDeferrer<TResult>>.WithDeferrer() => this;

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        IBuilderWithAction<TResult> IBuilder<TResult>.WithAction(Action action)
        {
            return this.WithAction(action);
        }

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IBuilder<TResult>.WithAction(Action<TResult> action) =>
            this.WithActionWithOldAndNewValueWithFallback((_, obj) => action(obj));

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> ISchedulerBase<IBuilder<TResult>>.WithGetterDispatcher() => this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        IBuilderWithActionOfNullT<TResult> IBuilder<TResult>.WithNullableAction(Action<TResult?> action) =>
            this.WithNullableActionWithOldAndNewValue((_, obj) => action(obj));

        /// <summary>
        ///     Builder with action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        public IBuilderWithActionOfT<TResult> WithAction(Action<TResult, TResult> action) =>
            this.WithActionWithOldAndNewValueWithFallback(action);

        /// <summary>
        ///     Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        public IBuilderWithActionOfNullT<TResult> WithNullableAction(Action<TResult?, TResult?> action) =>
            this.WithNullableActionWithOldAndNewValue(action);

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilder<TResult> ISchedulerBase<IBuilder<TResult>>.WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}