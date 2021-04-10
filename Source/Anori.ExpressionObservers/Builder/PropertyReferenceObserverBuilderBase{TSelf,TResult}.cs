// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    /// The Property Reference Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyReferenceObserverBuilder{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    internal abstract partial class PropertyReferenceObserverBuilderBase<TSelf, TResult> : PropertyObserverBuilderBase<TSelf>
        where TSelf : PropertyReferenceObserverBuilderBase<TSelf, TResult>
        where TResult : class
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverBuilderBase{TSelf, TResult}" /> class.
        /// </summary>
        protected PropertyReferenceObserverBuilderBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverBuilderBase{TSelf, TResult}" /> class.
        /// </summary>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="isSilentActivate">if set to <c>true</c> [is silent activate].</param>
        protected PropertyReferenceObserverBuilderBase(bool isAutoActivate, bool isSilentActivate) : base(isAutoActivate, isSilentActivate)
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
        protected abstract IPropertyReferenceObserver<TResult> CreatePropertyReferenceObserver();

        /// <summary>
        ///     Creates the property value observer builder with value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyReferenceObserverOnValueChanged<TResult>
            CreatePropertyReferenceObserverBuilderWithValueChanged();

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyReferenceObserverOnNotifyProperyChanged<TResult>
            CreatePropertyReferenceObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyReferenceObserverWithGetter<TResult> CreatePropertyReferenceObserverWithGetter();

        /// <summary>
        ///     Properties the value observer builder with action and getter and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterTaskSchedulerFallback();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf PropertyReferenceObserverBuilderWithActionAndGetterWithFallback();

        /// <summary>
        ///     Properties the value observer builder with action of t result and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskSchedulerAndFallback();

        /// <summary>
        ///     Properties the value observer builder with action of t result nullable and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with action of t result with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf PropertyReferenceObserverBuilderWithActionOfTResultWithFallback();

        /// <summary>
        ///     Properties the value observer builder with notify propery changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler();

        /// <summary>
        ///     Properties the value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler();

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