// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndGetter<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetter<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndGetter<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetter<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);
        

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndScheduler<TResult> IPropertyObserverScheduler<
            IBuilderWithActionOfTAndGetterAndScheduler<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndScheduler<TResult>
            IPropertyObserverScheduler<IBuilderWithActionOfTAndGetterAndScheduler<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}