﻿// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IBuilderOnProperyChanged{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> :
            IPropertyReferenceObserverBuilderWithActionOfTAndFallback<TResult>
    {
        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        public Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfTAndFallback<TResult> WithGetter() => this;

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTAndFallback<TResult>
            IObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithFallback<TResult> IPropertyReferenceObserverBuilderWithActionOfTAndFallback<TResult>.
            Build() =>
            this.CreatePropertyGetterObserverWithFallback();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}