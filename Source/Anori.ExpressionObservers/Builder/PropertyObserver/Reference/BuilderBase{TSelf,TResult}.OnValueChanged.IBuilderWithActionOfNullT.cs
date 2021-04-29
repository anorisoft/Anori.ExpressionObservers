// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    internal abstract partial class BuilderBase<TSelf, TResult> :
        IBuilderWithActionOfNullT<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value2 Observer Builder.</returns>
        IBuilderWithActionOfNullT<TResult> IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        /// The target object.
        /// </returns>
        IBuilderWithActionOfNullTAndScheduler<TResult> IPropertyObserverScheduler<IBuilderWithActionOfNullTAndScheduler<TResult>>.WithScheduler(TaskScheduler taskScheduler)
            =>
                this.WithScheduler(taskScheduler);

        /// <summary>
        /// Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        /// The target object.
        /// </returns>
        IBuilderWithActionOfNullTAndScheduler<TResult> IPropertyObserverScheduler<IBuilderWithActionOfNullTAndScheduler<TResult>>.WithGetterDispatcher()
            =>
                this.WithGetterDispatcher();


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>
        /// Property Observer With Getter And Fallback.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> IBuilderWithActionOfNullTAndScheduler<TResult>.Build() =>
            this.CreateGetterReferencePropertyObserver();

    }
}