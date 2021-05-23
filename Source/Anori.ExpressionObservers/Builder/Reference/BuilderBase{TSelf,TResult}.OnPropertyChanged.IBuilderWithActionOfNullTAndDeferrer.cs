// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfNullTAndDeferrer.cs" company="AnoriSoft">
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
    ///     The value property observer builder base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfNullTAndDeferrer<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterReferencePropertyObserverWithDeferrer<TResult> IBuilderWithActionOfNullTAndDeferrer<TResult>.Build() =>
            this.CreatePropertyReferenceObserverWithDeferrer();

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult> IBuilderWithActionOfNullTAndDeferrer<TResult>.
            WithGetter() =>
            this;
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult>
            IObserverBuilderBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> ISchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> ISchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}