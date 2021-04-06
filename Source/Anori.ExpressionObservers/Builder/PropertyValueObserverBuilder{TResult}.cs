// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TResult}" />
    public sealed class PropertyValueObserverBuilder<TResult> : PropertyValueObserverBuilderBase<
        PropertyValueObserverBuilder<TResult>, TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverBuilder{TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyValueObserverBuilder(Expression<Func<TResult>> propertyExpression)
        {
            this.propertyExpression = propertyExpression;
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TResult> Cached() => this;

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyObserverWithFallback<TResult> CreatePropertyGetterObserverWithFallback()
        {
            IPropertyObserverWithFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value);
            }
            else
            {
                observer = new PropertyObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!.Value);
            }

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
        protected override IPropertyObserver<TResult> CreatePropertyObserver()
        {
            var observer = new PropertyObserver<TResult>(this.propertyExpression, this.Action!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with action and dispatcher getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IPropertyObserverWithGetterAndFallback<TResult> CreatePropertyObserverWithGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value);
            }
            else
            {
                observer = new PropertyObserverWithGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.Fallback!.Value);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserver<TResult> CreatePropertyValueObserver()
        {
            IPropertyValueObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserver<TResult>(this.propertyExpression, this.ActionOfTResult!);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer.
        /// </returns>
        protected override IPropertyValueObserverOnValueChanged<TResult>
            CreatePropertyValueObserverBuilderWithValueChanged()
        {
            IPropertyValueObserverOnValueChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnValueChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnValueChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserverOnValueChanged<TResult>(this.propertyExpression);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer.
        /// </returns>
        protected override IPropertyValueObserverOnNotifyProperyChanged<TResult>
            CreatePropertyValueObserverOnNotifyProperyChanged()
        {
            IPropertyValueObserverOnNotifyProperyChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode);
            }
            else
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.IsCached,
                    this.SafetyMode);
            }

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
        protected override IPropertyValueObserverWithGetter<TResult> CreatePropertyValueObserverWithGetter()
        {
            IPropertyValueObserverWithGetter<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserverWithGetter<TResult>(this.propertyExpression, this.Action!);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Properties the value observer builder with action and getter and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            PropertyValueObserverBuilderWithActionAndGetterTaskSchedulerFallback() =>
            this;

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TResult>
            PropertyValueObserverBuilderWithActionAndGetterWithFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler fallback.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskSchedulerAndFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result nullable and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TResult>
            PropertyValueObserverBuilderWithActionOfTResultWithFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with notify propery changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TResult> WithAction() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TResult> WithActionOfTResult() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TResult> WithActionOfTResultWithFallback() => this;

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TResult> WithNotifyProperyChanged() => this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TResult> WithValueChanged() => this;
    }
}