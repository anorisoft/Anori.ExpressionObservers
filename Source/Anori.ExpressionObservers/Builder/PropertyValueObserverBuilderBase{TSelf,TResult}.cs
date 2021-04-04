// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilder{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    public abstract class PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilder<TResult>,
                                                                             IPropertyValueObserverBuilderWithActionOfTResult
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithAction<
                                                                                 TResult>,
                                                                             IPropertyValueObserverBuilderWithActionAndGetter
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionAndGetterAndFallback
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithNotifyProperyChanged
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithValueChanged
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionOfTResultAndFallback
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionOfTResultNullable
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler
                                                                             <TResult>,
                                                                             IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler
                                                                             <TResult>
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
        {
            this.IsAutoActivate = isAutoActivate;
            this.IsSilentActivate = isSilentActivate;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is automatic activate.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is automatic activate; otherwise, <c>false</c>.
        /// </value>
        protected internal bool IsAutoActivate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is silent activate.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is silent activate; otherwise, <c>false</c>.
        /// </value>
        protected internal bool IsSilentActivate { get; set; }

        /// <summary>
        ///     Gets the task scheduler.
        /// </summary>
        /// <value>
        ///     The task scheduler.
        /// </value>
        private protected TaskScheduler? TaskScheduler { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsCached { get; private set; }

        /// <summary>
        ///     Gets or sets the safety mode.
        /// </summary>
        /// <value>
        ///     The safety mode.
        /// </value>
        private protected LazyThreadSafetyMode SafetyMode { get; private set; }

        /// <summary>
        ///     Gets the fallback.
        /// </summary>
        /// <value>
        ///     The fallback.
        /// </value>
        private protected TResult Fallback { get; private set; }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        private protected Action? Action { get; private set; }

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
        ///     Gets a value indicating whether this instance is dispached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is dispached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsDispached { get; private set; }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        public TSelf AutoActivate()
        {
            this.IsAutoActivate = true;
            return (TSelf)this;
        }

       
        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf Cached();

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserver<TResult> CreatePropertyValueObserver();

        /// <summary>
        ///     Creates the property value observer builder with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyValueObserverBuilderWithAction();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserverWithGetter<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetter();

        /// <summary>
        ///     Creates the property value observer builder with action and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback();

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyGetterObserverWithFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback();

        /// <summary>
        ///     Creates the property value observer builder with action of t result nullable.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserver<TResult>
            CreatePropertyValueObserverBuilderWithActionOfTResultNullable();

        /// <summary>
        ///     Creates the property value observer builder with notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyValueObserverOnNotifyProperyChanged<TResult>
            CreatePropertyValueObserverBuilderWithNotifyProperyChanged();

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
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskSchedulerFallback();

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

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilder<TResult> IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilder<TResult>>
            .AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionOfTResult<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithAction<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithAction<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionAndGetter<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>
            IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithValueChanged<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Cached(
                LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            SafetyMode = safetyMode;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Cached()
        {
            this.IsCached = true;
            SafetyMode = LazyThreadSafetyMode.None;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>.Cached()
        {
            this.IsCached = true;
            SafetyMode = LazyThreadSafetyMode.None;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>.Cached(
                LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            SafetyMode = safetyMode;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.
            Cached()
        {
            this.IsCached = true;
            SafetyMode = LazyThreadSafetyMode.None;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Cached()
        {
            this.IsCached = true;
            SafetyMode = LazyThreadSafetyMode.None;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Cached(LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            SafetyMode = safetyMode;
            return this.Cached();
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.
            Cached(LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            SafetyMode = safetyMode;
            return this.Cached();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserverWithGetter<TResult> IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            .Create() =>
            this.CreatePropertyValueObserverBuilderWithActionAndGetter();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Create()
        {
            return this.CreatePropertyValueObserverBuilderWithValueChanged();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>.Create()
        {
            return this.CreatePropertyValueObserverBuilderWithNotifyProperyChanged();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Create() =>
            this.CreatePropertyValueObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserverWithGetter<TResult> IPropertyValueObserverBuilderWithActionAndGetter<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionAndGetter();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TResult> IPropertyValueObserverBuilderWithAction<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithAction();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IPropertyObserverWithGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyGetterObserverWithFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithValueChanged();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserver<TResult> IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>.Create() =>
            this.CreatePropertyValueObserver();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IPropertyObserverWithGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserver<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionOfTResultNullable();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyGetterObserverWithFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Observer With Getter And Fallback.
        /// </returns>
        IPropertyObserverWithGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithAction<TResult> IPropertyValueObserverBuilder<TResult>.WithAction(
            Action action)
        {
            this.Action = action;
            return this.WithAction();
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult> IPropertyValueObserverBuilder<TResult>.
            WithAction(Action<TResult?> action)
        {
            this.ActionOfTResult = action;

            return this.WithActionOfTResult();
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult> IPropertyValueObserverBuilder<TResult>.WithAction(
            Action<TResult> action)
        {
            this.ActionOfTResultWithFallback = action;
            return this.WithActionOfTResultWithFallback();
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>.WithFallback(TResult fallback)
        {
            this.Fallback = fallback;
            return this.PropertyValueObserverBuilderWithActionAndGetterTaskSchedulerFallback();
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResult<TResult>.WithFallback(TResult fallback)
        {
            this.Fallback = fallback;
            return this.PropertyValueObserverBuilderWithActionOfTResultWithFallback();
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TResult>.WithFallback(TResult fallback)
        {
            this.Fallback = fallback;
            return this.PropertyValueObserverBuilderWithActionAndGetterWithFallback();
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>.WithFallback(
                TResult fallback)
        {
            this.Fallback = fallback;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskSchedulerFallback();
        }

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult> IPropertyValueObserverBuilderWithAction<TResult>.
            WithGetter() =>
            this;

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            >.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<
                TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> IGetterTaskScheduler<
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult> IGetterTaskScheduler<
            IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<
                TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>.
            WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult> IGetterTaskScheduler<
            IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<
                TResult>>.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<
                TResult>>.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            >.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult> IPropertyValueObserverBuilder<TResult>.
            WithNotifyProperyChanged() =>
            this.WithNotifyProperyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilder<TResult>.
            WithValueChanged() =>
            this.WithValueChanged();
    }
}