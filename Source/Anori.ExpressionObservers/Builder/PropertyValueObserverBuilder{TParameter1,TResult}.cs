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
    using Anori.ExpressionObservers.Interfaces.Builder;
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
    internal sealed class PropertyValueObserverBuilder<TParameter1, TResult> : PropertyValueObserverBuilderBase<
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
        protected override PropertyValueObserverBuilder<TParameter1, TResult> Cached() => this;

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
                observer = new PropertyObserverWithActionOfTResultAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTResultAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTResultAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!.Value,
                    this.ObserverFlag);
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
            var observer = new PropertyObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!,
                this.ObserverFlag);
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
                observer = new PropertyObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }


        /// <summary>
        /// Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns></returns>
        protected override IPropertyObserverWithGetterAndFallback<TResult> CreatePropertyObserverWithActionOfTResultAndGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!.Value,
                    this.ObserverFlag);
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
        protected override IPropertyValueObserver<TResult> CreatePropertyValueObserver()
        {
            IPropertyValueObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyValueObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.ObserverFlag);
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
        protected override IPropertyValueObserverOnValueChanged<TResult>
            CreatePropertyValueObserverBuilderWithValueChanged()
        {
            IPropertyValueObserverOnValueChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property value observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IPropertyValueObserverOnValueChangedWithDeferrer<TResult>
            CreatePropertyValueObserverBuilderWithValueChangedAndDeferrer()
        {
            IPropertyValueObserverOnValueChangedWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverOnValueChangedWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnValueChangedWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyValueObserverOnValueChangedWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ObserverFlag);
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
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
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
        protected override IPropertyValueObserverWithGetter<TResult> CreatePropertyValueObserverWithGetter()
        {
            IPropertyValueObserverWithGetter<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

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