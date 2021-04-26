// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnValueChangedAndDefferer.cs" company="AnoriSoft">
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
    ///     The Property Reference Observer Builder Base class.
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
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfNullableTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithIPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderOnIPropertyReferenceObserverBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> :
            IBuilderWithDeferrer<TResult>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        public INotifyReferencePropertyObserverWithDeferrer<TResult> Build() =>
            this.CreatePropertyReferenceObserverBuilderOnValueChangedAndDeferrer();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> IObserverBuilderBase<
            IBuilderWithDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();
    }
}