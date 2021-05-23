// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndDeferrer.cs" company="AnoriSoft">
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IPropertyObserverWithDeferrer<TResult> IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>.Build() =>
            this.CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>
            IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>.WithGetter() =>
            this;
        /// <summary>
        ///     Automatic activation when creating the property observer.
        /// </summary>
        /// <returns>
        ///     The property observer builder.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Builder with getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Builder with getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>
            ISchedulerBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}