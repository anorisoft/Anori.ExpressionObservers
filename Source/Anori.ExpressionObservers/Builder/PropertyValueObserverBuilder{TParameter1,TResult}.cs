// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilder{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TParameter1, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1, TResult}" />
    public sealed class PropertyValueObserverBuilder<TParameter1, TResult> : PropertyValueObserverBuilderBase<
        PropertyValueObserverBuilder<TParameter1, TResult>, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        ///     The parameter1.
        /// </summary>
        private readonly TParameter1 parameter1;

        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverBuilder{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyValueObserverBuilder(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.propertyExpression = propertyExpression;
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> Cached(LazyThreadSafetyMode safetyMode)
        {
            this.IsCached = true;
            this.SafetyMode = safetyMode;
            return this;
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> Cached()
        {
            this.IsCached = true;
            this.SafetyMode = LazyThreadSafetyMode.None;
            return this;
        }

        /// <summary>
        ///     Creates the property getter observer with fallback.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyGetterObserverWithFallback<TResult> CreatePropertyGetterObserverWithFallback()
        {
            var observer = new PropertyObserverWithFallback<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.ActionOfTResultWithFallback!,
                this.Fallback);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        /// Creates the property value observer.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserver<TResult> CreatePropertyValueObserver()
        {
            var observer = new PropertyValueObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.ActionOfTResult!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyValueObserverBuilderWithAction()
        {
            var observer = new PropertyObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        protected override IPropertyValueObserverWithGetter<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetter()
        {
            var observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override IPropertyObserverWithAndFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback()
        {
            var observer = new PropertyObserverWithAndFallback<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!,
                this.Fallback);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        protected override IPropertyValueObserver<TResult> CreatePropertyValueObserverBuilderWithActionOfTResult()
        {
            var observer = new PropertyValueObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.ActionOfTResult!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyGetterObserverWithFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback()
        {
            var observer = new PropertyObserverWithFallback<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.ActionOfTResultWithFallback!,
                this.Fallback);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with value changed.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverOnValueChanged<TResult>
            CreatePropertyValueObserverBuilderWithValueChanged()
        {
            var observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.TaskScheduler);

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverOnNotifyProperyChanged<TResult>
            CreatePropertyValueObserverOnNotifyProperyChanged()
        {
            var observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.IsCached,
                this.SafetyMode,
                this.TaskScheduler);

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer on value changed.
        /// </summary>
        /// <returns>Create Property Value Observer OnValueChanged.</returns>
        protected override IPropertyValueObserverOnValueChanged<TResult> CreatePropertyValueObserverOnValueChanged()
        {
            var observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.TaskScheduler);

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult>
            PropertyValueObserverBuilderWithActionAndGetterWithFallback(TResult fallback)
        {
            this.Fallback = fallback;
            return this;
        }

        /// <summary>
        /// Properties the value observer builder with action of t result nullable with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>
            PropertyValueObserverBuilderWithActionOfTResultNullableWithFallback(TResult fallback)
        {
            this.Fallback = fallback;
            return this;
        }

        /// <summary>
        ///     Properties the value observer builder with action of t result with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult>
            PropertyValueObserverBuilderWithActionOfTResultWithFallback(TResult fallback)
        {
            this.Fallback = fallback;
            return this;
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithAction(Action<TResult?> action)
        {
            this.ActionOfTResult = action;
            return this;
        }

        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithAction(Action<TResult> action)
        {
            this.ActionOfTResultWithFallback = action;
            return this;
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithAction(Action action)
        {
            this.Action = action;
            return this;
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithGetterTaskScheduler(
            TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this;
        }

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithNotifyProperyChanged() => this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithValueChanged() => this;
    }
}