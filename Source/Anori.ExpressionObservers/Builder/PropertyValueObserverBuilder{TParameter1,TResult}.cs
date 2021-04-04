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
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ValueTypeObservers;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

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
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> Cached()
        {
            return this;
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
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!);
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
            IPropertyValueObserverWithGetter<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!);
            }

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
        protected override IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionAndGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback);
            }
            else
            {
                observer = new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.Fallback);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyGetterObserverWithFallback<TResult>
            CreatePropertyValueObserverBuilderWithActionOfTResultAndFallback()
        {
            IPropertyGetterObserverWithFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback);
            }
            else
            {
                observer = new PropertyObserverWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with action of t result nullable.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IPropertyValueObserver<TResult>
            CreatePropertyValueObserverBuilderWithActionOfTResultNullable()
        {
            IPropertyValueObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!);
            }

            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with notify propery changed and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverOnNotifyProperyChanged<TResult>
            CreatePropertyValueObserverBuilderWithNotifyProperyChanged()
        {
            IPropertyValueObserverOnNotifyProperyChanged<TResult> observer;

            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode);
            }
            else
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
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
        ///     Creates the property value observer builder with value changed and getter task scheduler.
        /// </summary>
        protected override IPropertyValueObserverOnValueChanged<TResult>
            CreatePropertyValueObserverBuilderWithValueChanged()
        {
            IPropertyValueObserverOnValueChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler);
            }
            else
            {
                observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression);
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
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IPropertyValueObserverOnNotifyProperyChanged<TResult>
            CreatePropertyValueObserverOnNotifyProperyChanged()
        {
            IPropertyValueObserverOnNotifyProperyChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode);
            }
            else
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
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
        ///     Properties the value observer builder with action and getter and fallback and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action and getter task scheduler fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            PropertyValueObserverBuilderWithActionAndGetterTaskSchedulerFallback() =>
            this;

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult>
            PropertyValueObserverBuilderWithActionAndGetterWithFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and fallback and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result and getter task scheduler fallback.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            PropertyValueObserverBuilderWithActionOfTResultAndGetterTaskSchedulerFallback() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result nullable and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with action of t result with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult>
            PropertyValueObserverBuilderWithActionOfTResultWithFallback() =>
            this;

        ///// <summary>
        /////     Properties the value observer builder with action of t result nullable with fallback.
        ///// </summary>
        ///// <param name="fallback">The fallback.</param>
        ///// <returns>
        /////     The Value Property Observer Builder.
        ///// </returns>
        //protected override PropertyValueObserverBuilder<TParameter1, TResult>
        //    PropertyValueObserverBuilderWithActionOfTResultNullableWithFallback(TResult fallback)
        //{
        //    this.Fallback = fallback;
        //    return this;
        //}

        /// <summary>
        ///     Properties the value observer builder with notify propery changed and getter task scheduler.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler<TResult>
            PropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler() =>
            this;

        /// <summary>
        ///     Properties the value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns></returns>
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
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithAction() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithActionOfTResult() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyValueObserverBuilder<TParameter1, TResult> WithActionOfTResultWithFallback() => this;

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