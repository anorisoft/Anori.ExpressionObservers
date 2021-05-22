// -----------------------------------------------------------------------
// <copyright file="Builder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;
    using Anori.ExpressionObservers.Observers.OnValueChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnValueChanged;

    /// <summary>
    ///     The value property observer builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class Builder<TResult> : BuilderBase<Builder<TResult>, TResult>
        where TResult : class
    {
        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TResult>> propertyExpression;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Builder{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        public Builder(Expression<Func<TResult>> propertyExpression) => this.propertyExpression = propertyExpression;

        /// <summary>
        ///     Creates the property observer with action of T result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithActionOfTAndFallback()
        {
            IGetterPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
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
        ///     Creates the getter property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            IGetterPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback()
        {
            IGetterPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallback<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithFallbackAndDeferrer()
        {
            IGetterPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TResult>(
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
        ///     Creates the property reference observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserver()
        {
            IGetterReferencePropertyObserver<TResult> observer;

            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetter<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserverWithDeferrer<TResult>
            CreateGetterReferencePropertyObserverAndDeferrer()
        {
            IGetterReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndGetterAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserverCached()
        {
            IGetterReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndCachedGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndCachedGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndCachedGetter<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TResult>(
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
        ///     Creates the notify property observer with action and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValueWithFallback!,
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
        ///     Creates the notify property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTNullAndDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithOldAndNewValue!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
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
                observer = new ObserverWithFallback<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallback<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Fallback!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Fallback!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallbackAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserver<TResult> CreateNotifyReferencePropertyObserver()
        {
            INotifyReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new Observer<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new Observer<TResult>(this.propertyExpression, this.TaskScheduler, this.ObserverFlag);
            }
            else
            {
                observer = new Observer<TResult>(this.propertyExpression, this.ObserverFlag);
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
        ///     The reference property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserver<TResult> CreateNotifyReferencePropertyObserverWithAction()
        {
            INotifyReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithAction<TResult>(
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
        ///     Creates the notify reference property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyReferencePropertyObserverWithActionAndDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ReferenceObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
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
        ///     Creates the property reference observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyReferencePropertyObserverWithDeferrer()
        {
            INotifyReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithDeferrer<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDeferrer<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDeferrer<TResult>(this.propertyExpression, this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the property reference observer builder with action.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithAction()
        {
            var observer = new Observers.OnPropertyChanged.ObserverWithAction<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionAndDeferrer()
        {
            var observer = new Observers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback()
        {
            IPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallback<TResult>(
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
        ///     Creates the property observer With Action Of T and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The reference property observer.
        /// </returns>
        protected override IPropertyObserverWithDeferrer<TResult>
            CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            IPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValueWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserver()
        {
            IGetterReferencePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValue!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValue!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TResult>(
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
        ///     The reference property observer.
        /// </returns>
        protected override IGetterReferencePropertyObserverWithDeferrer<TResult>
            CreatePropertyReferenceObserverWithDeferrer()
        {
            IGetterReferencePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ReferenceObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValue!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ReferenceObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionWithNewValue!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ReferenceObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
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