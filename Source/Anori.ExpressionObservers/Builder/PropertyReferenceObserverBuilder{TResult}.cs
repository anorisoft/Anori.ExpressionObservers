// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilder{TResult}.cs" company="AnoriSoft">
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
    using Anori.ExpressionObservers.ReferenceTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyReferenceObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TResult}" />
    public sealed class PropertyReferenceObserverBuilder<TResult> : PropertyReferenceObserverBuilderBase<
        PropertyReferenceObserverBuilder<TResult>, TResult>
        where TResult : class
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverBuilder{TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyReferenceObserverBuilder(Expression<Func<TResult>> propertyExpression)
        {
            this.propertyExpression = propertyExpression;
        }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TResult> Cached() => this;

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
                    this.Fallback!);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!);
            }
            else
            {
                observer = new PropertyObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!);
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
                    this.Fallback!);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!);
            }
            else
            {
                observer = new PropertyObserverWithGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.Fallback!);
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
        protected override IPropertyReferenceObserver<TResult> CreatePropertyReferenceObserver()
        {
            IPropertyReferenceObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyReferenceObserver<TResult>(this.propertyExpression, this.ActionOfTResult!);
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
        protected override IPropertyReferenceObserverOnValueChanged<TResult>
            CreatePropertyReferenceObserverBuilderWithValueChanged()
        {
            IPropertyReferenceObserverOnValueChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverOnValueChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnValueChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyReferenceObserverOnValueChanged<TResult>(this.propertyExpression);
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
        protected override IPropertyReferenceObserverOnNotifyProperyChanged<TResult>
            CreatePropertyReferenceObserverOnNotifyProperyChanged()
        {
            IPropertyReferenceObserverOnNotifyProperyChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode);
            }
            else
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TResult>(
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
        protected override IPropertyReferenceObserverWithGetter<TResult> CreatePropertyReferenceObserverWithGetter()
        {
            IPropertyReferenceObserverWithGetter<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyReferenceObserverWithGetter<TResult>(this.propertyExpression, this.Action!);
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
        protected override
            IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterTaskSchedulerFallback() =>
            this;

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyReferenceObserverBuilder<TResult>
            PropertyReferenceObserverBuilderWithActionAndGetterWithFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and fallback and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override
            IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler fallback.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskSchedulerAndFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result nullable and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected override PropertyReferenceObserverBuilder<TResult>
            PropertyReferenceObserverBuilderWithActionOfTResultWithFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with notify propery changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            PropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyReferenceObserverBuilder<TResult> WithAction() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TResult> WithActionOfTResult() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyReferenceObserverBuilder<TResult> WithActionOfTResultWithFallback() => this;

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TResult> WithNotifyProperyChanged() => this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TResult> WithValueChanged() => this;
    }
}