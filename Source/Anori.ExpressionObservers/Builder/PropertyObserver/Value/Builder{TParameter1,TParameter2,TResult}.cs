// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilder{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Builder.PropertyObserver;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;
    using Anori.ExpressionObservers.Observers.OnValueChanged;
    using Anori.ExpressionObservers.ValueObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ValueObservers.OnValueChanged;
    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="BuilderBase{TSelf}.ExpressionObservers.Builder.PropertyValueObserverBuilder{TParameter1, TParameter2, TResult}, TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfT{TParameter1,  TParameter2, TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1,  TParameter2, TResult}" />
    internal sealed class Builder<TParameter1, TParameter2, TResult> : PropertyObserver.Value.BuilderBase<Builder<TParameter1, TParameter2, TResult>, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
        where TResult : struct
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
        ///     Initializes a new instance of the <see cref="Builder{TParameter1,TParameter2,TResult}" />
        ///     class.
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
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new PropertyObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new PropertyObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
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
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithAction()
        {
            var observer = new ValueObservers.OnPropertyChanged.Observer<TParameter1, TParameter2, TResult>(
                this.parameter1,
                this.parameter2,
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
                        this.Fallback!.Value,
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
                        this.Fallback!.Value,
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
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IGetterValuePropertyObserver<TResult> CreatePropertyValueObserver()
        {
            IGetterValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnPropertyChanged.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnPropertyChanged.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnPropertyChanged.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionOfT!,
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
            CreatePropertyValueObserverBuilderOnValueChanged()
        {
            IPropertyValueObserverOnValueChanged<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueTypeObservers.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueTypeObservers.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueTypeObservers.Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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
        protected override INotifyValuePropertyObserverWithDeferrer<TResult>
            CreatePropertyValueObserverBuilderOnValueChangedAndDeferrer()
        {
            INotifyValuePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithDefer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDefer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDefer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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
        /// Creates the property value observer builder with value changed and fallback and deferrer.
        /// </summary>
        /// <returns>
        /// The Property Value Observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreatePropertyValueObserverBuilderOnValueChangedAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithDeferWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Fallback!.Value,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDeferWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Fallback!.Value,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDeferWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
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
                observer = new CachedObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new CachedObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new CachedObserver<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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
        protected override IGetterValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithGetter()
        {
            IGetterValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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