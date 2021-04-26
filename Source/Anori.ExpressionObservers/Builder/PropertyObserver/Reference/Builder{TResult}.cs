// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Builder.PropertyObserver.Reference.BuilderBase{TSelf,TResult}.ExpressionObservers.Builder.PropertyReferenceObserverBuilder{TResult}, TResult}" />
    internal sealed class Builder<TResult> : PropertyObserver.Reference.BuilderBase<
        Builder<TResult>, TResult>
        where TResult : class
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see
        ///         cref="PropertyReferenceObserverBuilderOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChangedOnNotifyProperyChanged{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public Builder(Expression<Func<TResult>> propertyExpression) =>
            this.propertyExpression = propertyExpression;

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> CreatePropertyGetterObserverWithFallback()
        {
            IGetterPropertyObserver<TResult> getterPropertyObserver;
            
                if (this.IsDispached)
                {
                    getterPropertyObserver = new Observers.OnPropertyChanged.ObserverWithActionOfTAndFallback<TResult>(
                        this.propertyExpression,
                        this.ActionOfTWithFallback!,
                        SynchronizationContext.Current,
                        this.Fallback!,
                        this.ObserverFlag);
                }
                else if (this.TaskScheduler != null)
                {
                    getterPropertyObserver = new Observers.OnPropertyChanged.ObserverWithActionOfTAndFallback<TResult>(
                        this.propertyExpression,
                        this.ActionOfTWithFallback!,
                        this.TaskScheduler,
                        this.Fallback!,
                        this.ObserverFlag);
                }
                else
                {
                    getterPropertyObserver = new Observers.OnPropertyChanged.ObserverWithActionOfTAndFallback<TResult>(
                        this.propertyExpression,
                        this.ActionOfTWithFallback!,
                        this.Fallback!,
                        this.ObserverFlag);
                }
            }
         

            if (this.IsAutoActivate)
            {
                getterPropertyObserver.Activate(this.IsSilentActivate);
            }

            return getterPropertyObserver;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserver()
        {
            var observer = new Observer<TResult>(this.propertyExpression, this.Action!, this.ObserverFlag);
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
            CreatePropertyObserverWithActionOfTAndGetterAndFallback()
        {
            IPropertyObserverWithGetterAndFallback<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
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
                observer = new GetterObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new GetterObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new GetterObserverWithActionAndGetterAndFallback<TResult>(
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
        protected override IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserver()
        {
            IGetterReferencePropertyObserver<TResult> propertyObserver;
            if (this.IsDispached)
            {
                propertyObserver = new GetterReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new GetterReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                propertyObserver = new GetterReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.ObserverFlag);
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
                propertyObserver = new NotifyReferenceObserver<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new NotifyReferenceObserver<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                propertyObserver = new NotifyReferenceObserver<TResult>(
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
                propertyObserver = new NotifyReferenceObserverWithDefer<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new NotifyReferenceObserverWithDefer<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                propertyObserver = new NotifyReferenceObserverWithDefer<TResult>(
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
                propertyObserver = new NotifyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                propertyObserver = new NotifyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                propertyObserver = new NotifyReferenceObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
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
            if (this.ObserverMode == ObserverMode.Default || this.ObserverMode == ObserverMode.OnNotifyPropertyChanged)
            {
                if (this.IsDispached)
                {
                    propertyObserver = new GetterReferenceObserverWithGetter<TResult>(
                        this.propertyExpression,
                        this.Action!,
                        SynchronizationContext.Current,
                        this.ObserverFlag);
                }
                else if (this.TaskScheduler != null)
                {
                    propertyObserver = new GetterReferenceObserverWithGetter<TResult>(
                        this.propertyExpression,
                        this.Action!,
                        this.TaskScheduler,
                        this.ObserverFlag);
                }
                else
                {
                    propertyObserver = new GetterReferenceObserverWithGetter<TResult>(
                        this.propertyExpression,
                        this.Action!,
                        this.ObserverFlag);
                }
            }
            else
            {
                if (this.IsDispached)
                {
                    propertyObserver = new NotifyReferenceObserverWithAction<TResult>(
                                                                                                     this.propertyExpression,
                                                                                                     this.Action!,
                                                                                                     SynchronizationContext.Current,
                                                                                                     this.ObserverFlag);
                }
                else if (this.TaskScheduler != null)
                {
                    propertyObserver = new NotifyReferenceObserverWithAction<TResult>(
                        this.propertyExpression,
                        this.Action!,
                        this.TaskScheduler,
                        this.ObserverFlag);
                }
                else
                {
                    propertyObserver = new NotifyReferenceObserverWithAction<TResult>(
                        this.propertyExpression,
                        this.Action!,
                        this.ObserverFlag);
                }
            }

            if (this.IsAutoActivate)
            {
                propertyObserver.Activate(this.IsSilentActivate);
            }

            return propertyObserver;
        }
    }
}