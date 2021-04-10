// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : PropertyObserverBuilderBase<TSelf>
        where TSelf : PropertyValueObserverBuilderBase<TSelf, TResult>
        where TResult : struct
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverBuilderBase{TSelf, TResult}" /> class.
        /// </summary>
        protected PropertyValueObserverBuilderBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverBuilderBase{TSelf, TResult}" /> class.
        /// </summary>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="isSilentActivate">if set to <c>true</c> [is silent activate].</param>
        protected PropertyValueObserverBuilderBase(bool isAutoActivate, bool isSilentActivate)
            : base(isAutoActivate, isSilentActivate)
        {
        }

        /// <summary>
        ///     Gets the fallback.
        /// </summary>
        /// <value>
        ///     The fallback.
        /// </value>
        private protected TResult? Fallback { get; private set; }

        /// <summary>
        ///     Gets the action of t result.
        /// </summary>
        /// <value>
        ///     The action of t result.
        /// </value>
        private protected Action<TResult?>? ActionOfTResult { get; private set; }

        /// <summary>
        ///     Gets the action of t result with fallback.
        /// </summary>
        /// <value>
        ///     The action of t result with fallback.
        /// </value>
        private protected Action<TResult>? ActionOfTResultWithFallback { get; private set; }

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserverWithFallback<TResult> CreatePropertyGetterObserverWithFallback();

        /// <summary>
        ///     Creates the property value observer builder with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserver();

        /// <summary>
        ///     Creates the property value observer builder with action and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyObserverWithGetterAndFallback();

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserver<TResult> CreatePropertyValueObserver();

        /// <summary>
        ///     Creates the property value observer builder with value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserverOnValueChanged<TResult>
            CreatePropertyValueObserverBuilderWithValueChanged();

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserverOnNotifyProperyChanged<TResult>
            CreatePropertyValueObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserverWithGetter<TResult> CreatePropertyValueObserverWithGetter();

        /// <summary>
        ///     Properties the value observer builder with action and getter and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            PropertyValueObserverBuilderWithActionAndGetterTaskSchedulerFallback();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf PropertyValueObserverBuilderWithActionAndGetterWithFallback();

        /// <summary>
        ///     Properties the value observer builder with action of t result and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskSchedulerAndFallback();

        /// <summary>
        ///     Properties the value observer builder with action of t result nullable and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action of t result with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf PropertyValueObserverBuilderWithActionOfTResultWithFallback();

        /// <summary>
        ///     Properties the value observer builder with notify propery changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf WithAction();

        /// <summary>
        ///     Withes the action of t result.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf WithActionOfTResult();

        /// <summary>
        ///     Withes the action of t result with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf WithActionOfTResultWithFallback();

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf WithNotifyProperyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf WithValueChanged();
    }
}