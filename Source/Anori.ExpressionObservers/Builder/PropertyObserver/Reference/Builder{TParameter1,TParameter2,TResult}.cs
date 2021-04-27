// -----------------------------------------------------------------------
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
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnValueChanged;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyReferenceObserverBuilderOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfT{TParameter1,  TParameter2, TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1,  TParameter2, TResult}" />
    internal sealed class Builder<TParameter1, TParameter2, TResult> : PropertyObserver.Reference.BuilderBase<Builder<TParameter1, TParameter2, TResult>,
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
        /// Initializes a new instance of the <see cref="Builder{TParameter1,TParameter2,TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public Builder(
            TParameter1 parameter1,
            TParameter2 parameter2,
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            this.propertyExpression = propertyExpression;
        }

        /// <summary>
        ///     Gets or sets the property observer flag.
        /// </summary>
        /// <value>
        ///     The property observer flag.
        /// </value>
        public PropertyObserverFlag PropertyObserverFlag { get; set; }

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
                observer = new PropertyObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.PropertyObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
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
            var observer = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
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
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        protected override IPropertyObserverWithGetterAndFallback<TResult>
            CreatePropertyObserverWithActionOfTAndGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer =
                    new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionOfTWithFallback!,
                        SynchronizationContext.Current,
                        this.Fallback!,
                        this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer =
                    new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionOfTWithFallback!,
                        this.TaskScheduler,
                        this.Fallback!,
                        this.ObserverFlag);
            }
            else
            {
                observer =
                    new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionOfTWithFallback!,
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
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
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
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
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
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
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
        protected override IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserver()
        {
            IGetterReferencePropertyObserver<TResult> propertyObserver;
            if (this.IsDispached)
            {
                propertyObserver = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.PropertyObserverFlag);
            }
            else
            {
                propertyObserver = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                propertyObserver.Activate(this.IsSilentActivate);
            }

            return propertyObserver;
        }

        /// <summary>
        ///     Creates the property value observer builder with value changed and getter task scheduler.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer.
        /// </returns>
        protected override INotifyReferencePropertyObserver<TResult>
            CreatePropertyReferenceObserverBuilderOnValueChanged()
        {
            INotifyReferencePropertyObserver<TResult> propertyObserver;
            if (this.IsDispached)
            {
                propertyObserver = new ReferenceObservers.OnValueChanged.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new ReferenceObservers.OnValueChanged.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.PropertyObserverFlag);
            }
            else
            {
                propertyObserver = new ReferenceObservers.OnValueChanged.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                propertyObserver.Activate(this.IsSilentActivate);
            }

            return propertyObserver;
        }

        /// <summary>
        ///     Creates the property reference observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreatePropertyReferenceObserverBuilderOnValueChangedAndDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> propertyObserver;
            if (this.IsDispached)
            {
                propertyObserver = new ObserverWithDefer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new ObserverWithDefer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                propertyObserver = new ObserverWithDefer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                propertyObserver.Activate(this.IsSilentActivate);
            }

            return propertyObserver;
        }

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer.
        /// </returns>
        protected override INotifyReferencePropertyObserver<TResult>
            CreatePropertyReferenceObserverOnNotifyProperyChanged()
        {
            INotifyReferencePropertyObserver<TResult> propertyObserver;
            if (this.IsDispached)
            {
                propertyObserver = new CachedObserver<TParameter1, TParameter2, TResult>(
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
                propertyObserver = new CachedObserver<TParameter1, TParameter2, TResult>(
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
                propertyObserver = new CachedObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.IsCached,
                    this.SafetyMode,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                propertyObserver.Activate(this.IsSilentActivate);
            }

            return propertyObserver;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserverWithGetter()
        {
            IGetterReferencePropertyObserver<TResult> propertyObserver;
            if (this.IsDispached)
            {
                propertyObserver = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.PropertyObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.PropertyObserverFlag);
            }
            else
            {
                propertyObserver = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.PropertyObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                propertyObserver.Activate(this.IsSilentActivate);
            }

            return propertyObserver;
        }
    }
}