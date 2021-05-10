﻿// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged;

    /// <summary>
    /// The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Builder.PropertyObserver.BuilderBase{TSelf}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallbackAndDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IValueObserverBuilder{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilder{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallbackAndDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithActionAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged.IBuilder{TResult}" />
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithActionOfT<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithActionOfT<TResult> IObserverBuilderBase<IBuilderWithActionOfT<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndFallback<TResult> IBuilderWithActionOfT<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        /// Deferreds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndDeferrer<TResult> IBuilderWithActionOfT<TResult>.Deferred() => this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IObserverBuilderSchedulerBase<IBuilderWithActionOfT<TResult>>.WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionOfT<TResult> IObserverBuilderSchedulerBase<IBuilderWithActionOfT<TResult>>.WithScheduler(
                TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}