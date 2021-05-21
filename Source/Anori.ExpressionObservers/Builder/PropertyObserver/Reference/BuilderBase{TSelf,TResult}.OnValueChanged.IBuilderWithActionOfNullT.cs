// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfNullT<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        INotifyReferencePropertyObserver<TResult> IBuilderWithActionOfNullT<TResult>.Build() =>
            this.CreateNotifyReferencePropertyObserver();

        /// <summary>
        ///     Builder with deferrer.
        /// </summary>
        /// <returns>The reference property observer builder.</returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> IDeferBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.
            WithDeferrer() =>
            this;

        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>The reference property observer builder.</returns>
        IBuilderWithActionOfNullT<TResult> IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>The reference property observer builder.</returns>
        IBuilderWithActionOfNullT<TResult> ISchedulerBase<IBuilderWithActionOfNullT<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>The reference property observer builder.</returns>
        IBuilderWithActionOfNullT<TResult> ISchedulerBase<IBuilderWithActionOfNullT<TResult>>.WithScheduler(
            TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}