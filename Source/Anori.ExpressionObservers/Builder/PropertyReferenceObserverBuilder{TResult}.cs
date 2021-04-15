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
    /// <seealso cref="PropertyReferenceObserverBuilder{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilder{TParameter1,TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TResult}" />
    internal sealed class PropertyReferenceObserverBuilder<TResult> : PropertyReferenceObserverBuilderBase<
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
                observer = new PropertyObserverWithActionOfTResultAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTResultAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTResultAndFallback<TResult>(
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
            var observer = new PropertyObserver<TResult>(this.propertyExpression, this.Action!, this.ObserverFlag);
            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        protected override IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyObserverWithActionOfTResultAndGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResultWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTResultAndGetterAndFallback<TResult>(
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
                observer = new PropertyObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionAndGetterAndFallback<TResult>(
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
                observer = new PropertyReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfTResult!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserver<TResult>(
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
                observer = new PropertyReferenceObserverOnValueChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnValueChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnValueChanged<TResult>(
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
                observer = new PropertyReferenceObserverOnValueChangedWithDefer<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnValueChangedWithDefer<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnValueChangedWithDefer<TResult>(
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
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverOnNotifyProperyChanged<TResult>(
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
                observer = new PropertyReferenceObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyReferenceObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyReferenceObserverWithGetter<TResult>(
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