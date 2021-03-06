﻿// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilder{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
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
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ReferenceTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyReferenceObserverBuilder{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TParameter1,  TParameter2, TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1,  TParameter2, TResult}" />
    internal sealed class PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult> :
        PropertyReferenceObserverBuilderBase<PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult>,
            TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TResult : class
    {
        /// <summary>
        ///     The parameter1.
        /// </summary>
        private readonly TParameter1 parameter1;

        /// <summary>
        ///     The parameter2.
        /// </summary>
        private readonly TParameter2 parameter2;

        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyReferenceObserverBuilder{TParameter1,  TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyReferenceObserverBuilder(
            TParameter1 parameter1,
            TParameter2 parameter2,
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            this.propertyExpression = propertyExpression;
        }

        public PropertyObserverFlag PropertyObserverFlag { get; set; }

        /// <summary>
        ///     Cacheds this instance.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult> Cached() => this;

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
                observer = new PropertyObserverWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
            var observer = new PropertyObserver<TParameter1, TParameter2, TResult>(
                this.parameter1,
                this.parameter2,
                this.propertyExpression,
                this.Action!,
                this.PropertyObserverFlag);
            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
                observer = new PropertyObserverWithGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
                observer = new PropertyReferenceObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
                observer = new PropertyReferenceObserverOnValueChanged<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnValueChanged<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnValueChanged<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.IsCached,
                    this.SafetyMode,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
                observer = new PropertyReferenceObserverWithGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverWithGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverWithGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
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
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult>
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
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult>
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
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult> WithAction() => this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult> WithActionOfTResult() =>
            this;

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult>
            WithActionOfTResultWithFallback() =>
            this;

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult>
            WithNotifyProperyChanged() =>
            this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override PropertyReferenceObserverBuilder<TParameter1, TParameter2, TResult> WithValueChanged() =>
            this;
        protected override IPropertyReferenceObserverOnValueChangedWithDeferrer<TResult> CreatePropertyReferenceObserverBuilderWithValueChangedAndDeferrer()
        {
            throw new NotImplementedException();
        }
    }
}