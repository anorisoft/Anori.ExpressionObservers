// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

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
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndGetter{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTIPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> : Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback<TResult>
            IObserverBuilderBase<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IPropertyObserverWithGetterAndFallback<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback<TResult>.Build() =>
            this.CreatePropertyObserverWithActionOfTAndGetterAndFallback();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>
            .WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The target object.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>
            IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>
            .WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}