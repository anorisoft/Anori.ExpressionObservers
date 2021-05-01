// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Builder.PropertyObserver;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Reference Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndGetter{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChanged{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTIPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilder<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilder<TResult> IObserverBuilderBase<
            IBuilder<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        INotifyReferencePropertyObserver<TResult> IBuilder<TResult>.
            Build() =>
            this.CreatePropertyReferenceObserverBuilderOnValueChanged();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilder<TResult>
            IBuilder<TResult>.Cached() =>
            this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilder<TResult>
            IBuilder<TResult>.Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithDeferrer<TResult>
            IBuilder<TResult>.Deferred() =>
            this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfT<TResult>
            IBuilder<TResult>.WithAction(Action<TResult> action)
        {
            this.ObserverMode = ObserverMode.OnValueCahnged;
            return this.WithActionOfTWithFallback(action);
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithAction<TResult> IBuilder<TResult>.
            WithAction(Action action)
        {
            this.ObserverMode = ObserverMode.OnValueCahnged;
            return this.WithAction(action);
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);

        /// <summary>
        ///     Withes the nullable action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfNullableT<TResult>
            IBuilder<TResult>.WithNullableAction(Action<TResult?> action)
        {
            this.ObserverMode = ObserverMode.OnValueCahnged;
            return this.WithActionOfT(action);
        }
    }
}