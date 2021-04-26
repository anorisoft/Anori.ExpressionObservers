﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderWithActionOfTAndFallback<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult>
            IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterPropertyObserver<TResult>
            IBuilderWithActionOfTAndFallback<TResult>.Build() =>
            this.CreatePropertyObserverWithActionOfTAndFallback();

        /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns>
        /// The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> IBuilderWithActionOfTAndFallback<TResult>.WithGetter() => this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndScheduler<TResult>
            IPropertyObserverScheduler<
                IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        IBuilderWithActionOfTAndFallbackAndScheduler<TResult>
            IPropertyObserverScheduler<
                IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}