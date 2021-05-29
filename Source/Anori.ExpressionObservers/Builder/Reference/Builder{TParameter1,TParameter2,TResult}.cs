﻿// -----------------------------------------------------------------------
// <copyright file="Builder{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.Reference
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;
    using Anori.ExpressionObservers.Observers.OnValueChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnValueChanged;

    /// <summary>
    ///     The reference property observer builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class
        Builder<TParameter1, TParameter2, TResult> : BuilderBase<Builder<TParameter1, TParameter2, TResult>, TResult>
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
        ///     Initializes a new instance of the <see cref="Builder{TParameter1,TParameter2,TResult}" /> class.
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
        ///     Creates the property observer with action of T result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithActionOfTAndFallback()
        {
            IGetterPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
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
        ///     Creates the getter property observer With Action Of T and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            IGetterPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
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
        ///     Creates the getter property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback()
        {
            IGetterPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
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
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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
        ///     Creates the getter property observer with fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithFallbackAndDeferrer()
        {
            IGetterPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
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
        ///     Creates the value property observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserver()
        {
            IGetterReferencePropertyObserver<TResult> observer;

            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
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

        /// <summary>
        ///     Creates the getter reference property observer and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override IGetterReferencePropertyObserverWithDeferrer<TResult>
            CreateGetterReferencePropertyObserverAndDeferrer()
        {
            IGetterReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetterAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndDeferrer<TParameter1, TParameter2, TResult>(
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

        /// <summary>
        ///     Creates the getter value property observer cached.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserverCached()
        {
            IGetterReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndCachedGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndCachedGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndCachedGetter<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Action!,
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
        ///     Creates the notify property observer with action and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    _ => this.Action!(),
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    _ => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    _ => this.Action!(),
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
        ///     Creates the notify property observer with action and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    (_, _) => this.Action!(),
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
        ///     Creates the notify property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
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
        ///     Creates the notify property observer With Action Of T and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
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
        ///     Creates the notify property observer with action of t null and deferrer.
        /// </summary>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTNullAndDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer =
                    new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithOldAndNewValue!,
                        SynchronizationContext.Current,
                        this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer =
                    new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithOldAndNewValue!,
                        this.TaskScheduler,
                        this.ObserverFlag);
            }
            else
            {
                observer =
                    new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithOldAndNewValue!,
                        this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the notify property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
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
        ///     Creates the value property observer builder with value changed and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Fallback!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.Fallback!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
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
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserver<TResult> CreateNotifyReferencePropertyObserver()
        {
            INotifyReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new Observer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new Observer<TParameter1, TParameter2, TResult>(
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
        ///     Creates the notify value property observer with action.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserver<TResult> CreateNotifyReferencePropertyObserverWithAction()
        {
            INotifyReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    () => this.Action!(),
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    () => this.Action!(),
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    () => this.Action!(),
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the notify reference property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyReferencePropertyObserverWithActionAndDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer =
                    new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        (_, _) => this.Action!(),
                        SynchronizationContext.Current,
                        this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer =
                    new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        (_, _) => this.Action!(),
                        this.TaskScheduler,
                        this.ObserverFlag);
            }
            else
            {
                observer =
                    new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        (_, _) => this.Action!(),
                        this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the value property observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyReferencePropertyObserverWithDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDeferrer<TParameter1, TParameter2, TResult>(
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
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithAction()
        {
            var observer = new Observers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
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
        ///     Creates the property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionAndDeferrer()
        {
            var observer =
                new Observers.OnPropertyChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2, TResult>(
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
        ///     Creates the getter property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback()
        {
            IPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
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
        ///     Creates the property observer With Action Of T and fallback anddeferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override IPropertyObserverWithDeferrer<TResult>
            CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            IPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TParameter1, TParameter2, TResult>(
                    this.parameter1,
                    this.parameter2,
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
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
        ///     Creates the value property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserver()
        {
            IGetterReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer =
                    new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithNewValue!,
                        SynchronizationContext.Current,
                        this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer =
                    new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithNewValue!,
                        this.TaskScheduler,
                        this.ObserverFlag);
            }
            else
            {
                observer =
                    new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithNewValue!,
                        this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property reference observer with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected override IGetterReferencePropertyObserverWithDeferrer<TResult>
            CreatePropertyReferenceObserverWithDeferrer()
        {
            IGetterReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer =
                    new ReferenceObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithNewValue!,
                        SynchronizationContext.Current,
                        this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer =
                    new ReferenceObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithNewValue!,
                        this.TaskScheduler,
                        this.ObserverFlag);
            }
            else
            {
                observer =
                    new ReferenceObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TParameter1, TParameter2,
                        TResult>(
                        this.parameter1,
                        this.parameter2,
                        this.propertyExpression,
                        this.ActionWithNewValue!,
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