// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Builder.PropertyObserver;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso
    ///     cref="IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class
        BuilderBase<TSelf, TResult> : Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult> IObserverBuilderBase<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult>.Build() =>
            this.CreatePropertyObserver();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndGetter<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult>.WithGetter() =>
            this;
    }
}