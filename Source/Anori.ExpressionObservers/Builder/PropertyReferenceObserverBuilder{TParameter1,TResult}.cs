// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilder{TParameter1,TResult}.cs" company="AnoriSoft">
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
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyReferenceObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TParameter1, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1, TResult}" />
    internal sealed class PropertyReferenceObserverBuilder<TParameter1, TResult> : PropertyReferenceObserverBuilderBase<
        PropertyReferenceObserverBuilder<TParameter1, TResult>, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : class
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
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverBuilder{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyReferenceObserverBuilder(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.propertyExpression = propertyExpression;
        }

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
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTResultAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTResultAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!,
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
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        protected override IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyObserverWithActionOfTResultAndGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.Fallback!,
                    this.ObserverFlag);
            }

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
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.Fallback!,
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
        protected override IPropertyReferenceObserver<TResult> CreatePropertyReferenceObserver()
        {
            IPropertyReferenceObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserver<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserver<TParameter1, TResult>(
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
        protected override IPropertyReferenceObserverOnValueChanged<TResult>
            CreatePropertyReferenceObserverBuilderWithValueChanged()
        {
            IPropertyReferenceObserverOnValueChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnValueChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnValueChanged<TParameter1, TResult>(
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
        ///     Creates the property reference observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IPropertyReferenceObserverOnValueChangedWithDeferrer<TResult>
            CreatePropertyReferenceObserverBuilderWithValueChangedAndDeferrer()
        {
            IPropertyReferenceObserverOnValueChangedWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverOnValueChangedWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnValueChangedWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnValueChangedWithDefer<TParameter1, TResult>(
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
        protected override IPropertyReferenceObserverOnNotifyProperyChanged<TResult>
            CreatePropertyReferenceObserverOnNotifyProperyChanged()
        {
            IPropertyReferenceObserverOnNotifyProperyChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TResult>(
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
        protected override IPropertyReferenceObserverWithGetter<TResult> CreatePropertyReferenceObserverWithGetter()
        {
            IPropertyReferenceObserverWithGetter<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyReferenceObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverWithGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverWithGetter<TParameter1, TResult>(
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
    }
}