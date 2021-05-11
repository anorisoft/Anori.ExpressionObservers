// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithActionOfNullT.cs" company="AnoriSoft">
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
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfNullTAndDeferrer<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> Interfaces.Builder.IObserverBuilderBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserverWithDeferrer<TResult> IBuilderWithActionOfNullTAndDeferrer<TResult>.Build() =>
            this.CreatePropertyReferenceObserverWithDeferrer();

       /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult> IBuilderWithActionOfNullTAndDeferrer<TResult>.WithGetter() => this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> IObserverBuilderSchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> IObserverBuilderSchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}