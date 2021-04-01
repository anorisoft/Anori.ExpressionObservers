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
        ///     Gets or sets the task scheduler.
        /// </summary>
        /// <value>
        ///     The task scheduler.
        /// </value>
        private protected TaskScheduler? TaskScheduler { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        private protected bool IsCached { get; set; }

        /// <summary>
        ///     Gets or sets the safety mode.
        /// </summary>
        /// <value>
        ///     The safety mode.
        /// </value>
        private protected LazyThreadSafetyMode SafetyMode { get; set; }

        /// <summary>
        ///     Gets or sets the fallback.
        /// </summary>
        /// <value>
        ///     The fallback.
        /// </value>
        private protected TResult Fallback { get; set; }

        /// <summary>
        ///     Gets or sets the action.
        /// </summary>
        /// <value>
        ///     The action.
        /// </value>
        private protected Action? Action { get; set; }

        /// <summary>
        ///     Gets or sets the action of t result.
        /// </summary>
        /// <value>
        ///     The action of t result.
        /// </value>
        private protected Action<TResult?>? ActionOfTResult { get; set; }

        private protected Action<TResult>? ActionOfTResultWithFallback { get; set; }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns></returns>
        public TSelf AutoActivate()
        {
            this.IsAutoActivate = true;
            return (TSelf)this;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        public IPropertyGetterObserverWithFallback<TResult> Create() => this.CreatePropertyGetterObserverWithFallback();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected abstract TSelf Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns></returns>
        protected abstract TSelf Cached();

        /// <summary>
        ///     Creates the property getter observer with fallback.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyGetterObserverWithFallback<TResult> CreatePropertyGetterObserverWithFallback();

        /// <summary>
        ///     Creates the property value observer builder with action.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyValueObserverBuilderWithAction();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyValueObserverWithGetter<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetter();

        /// <summary>
        ///     Creates the property value observer builder with action and getter and fallback.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback();

        /// <summary>
        ///     Creates the property value observer builder with action of t result.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyValueGetterObserver<TResult>
            CreatePropertyValueObserverBuilderWithActionOfTResult();

        /// <summary>
        ///     Creates the property value observer on value changed.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyValueObserverOnValueChanged<TResult> CreatePropertyValueObserverOnValueChanged();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        protected abstract TSelf PropertyValueObserverBuilderWithActionAndGetterWithFallback(TResult fallback);

        protected abstract TSelf PropertyValueObserverBuilderWithActionOfTResultWithFallback(TResult fallback);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        protected abstract TSelf WithAction(Action action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        protected abstract TSelf WithAction(Action<TResult?> action);

        protected abstract TSelf WithAction(Action<TResult> action);

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        protected abstract TSelf WithGetterTaskScheduler(TaskScheduler taskScheduler);

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns></returns>
        protected abstract TSelf WithNotifyProperyChanged();

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns></returns>
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

        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult> IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>>.AutoActivate()
            =>
                this.AutoActivate();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.
            Cached() =>
            this.Cached();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult> IPropertyValueObserverBuilderWithValueChanged<TResult>.
            Cached(LazyThreadSafetyMode safetyMode) =>
            this.Cached(safetyMode);

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult> IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>.
            Create() =>
            this.CreatePropertyValueObserverOnValueChanged();

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
        ///     The Property Observer.
        /// </returns>
        IPropertyValueGetterObserver<TResult> IPropertyValueObserverBuilderWithActionOfTResult<TResult>.Create() =>
            this.CreatePropertyValueObserverBuilderWithActionOfTResult();

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
        /// Creates this instance.
        /// </summary>
        /// <returns>
        /// The Property Observer.
        /// </returns>
        IPropertyGetterObserverWithFallback<TResult> IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>.Create()
            =>
                this.CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback();
        /// <summary>
        /// Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns></returns>
        protected abstract IPropertyGetterObserverWithFallback<TResult> CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithAction<TResult> IPropertyValueObserverBuilder<TResult>.WithAction(
            Action action) =>
            this.WithAction(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult> IPropertyValueObserverBuilder<TResult>.WithAction(
            Action<TResult?> action) =>
            this.WithAction(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult> IPropertyValueObserverBuilder<TResult>.WithAction(
            Action<TResult> action) =>
            this.WithAction(action);

        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResult<TResult>.WithFallback(TResult fallback)
        {
            return this.PropertyValueObserverBuilderWithActionOfTResultWithFallback(fallback);
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TResult>.WithFallback(TResult fallback) =>
            this.PropertyValueObserverBuilderWithActionAndGetterWithFallback(fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult> IPropertyValueObserverBuilderWithAction<TResult>.
            WithGetter() =>
            this;

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetter<TResult>>.WithGetterTaskScheduler(
                TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChanged<TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChanged<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithValueChanged<TResult>>.WithGetterTaskScheduler(
                TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResult<TResult>>.WithGetterTaskScheduler(
                TaskScheduler taskScheduler) =>
            this.WithGetterTaskScheduler(taskScheduler);

        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult> IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>>.WithGetterTaskScheduler(TaskScheduler taskScheduler)
            =>
                this.WithGetterTaskScheduler(taskScheduler);


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