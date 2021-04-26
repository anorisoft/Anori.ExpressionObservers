// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Builder.PropertyObserver;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    /// The Property Reference Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTIPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetter{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChanged{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfT{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndGetter{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> : Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetter<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetter<TResult>
            IObserverBuilderBase<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetter<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetter<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);
    }
}