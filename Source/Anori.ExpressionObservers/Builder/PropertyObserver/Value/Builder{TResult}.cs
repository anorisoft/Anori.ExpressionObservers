// -----------------------------------------------------------------------
// <copyright file="Builder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;
    using Anori.ExpressionObservers.Observers.OnValueChanged;
    using Anori.ExpressionObservers.ValueObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ValueObservers.OnValueChanged;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class Builder<TResult> : BuilderBase<Builder<TResult>, TResult>
        where TResult : struct
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
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithActionOfTAndFallback()
        {
            IGetterPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
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
        ///     Creates the getter property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            IGetterPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallbackAndDeferrer<TResult>(
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
        ///     Creates the getter property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
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
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallback<TResult>(
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
        ///     Creates the getter property observer with fallback with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
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
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallbackAndDeferrer<TResult>(
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
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserver()
        {
            IGetterValuePropertyObserver<TResult> observer;

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
        ///     Creates the getter value property observer and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterValuePropertyObserverWithDeferrer<TResult>
            CreateGetterValuePropertyObserverAndDeferrer()
        {
            IGetterValuePropertyObserverWithDeferrer<TResult> observer;
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
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserverCached()
        {
            IGetterValuePropertyObserver<TResult> observer;

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
        ///     Creates the getter value property observer cached and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterValuePropertyObserverWithDeferrer<TResult>
            CreateGetterValuePropertyObserverCachedAndDeferrer()
        {
            IGetterValuePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndCachedGetterAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndCachedGetterAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndCachedGetterAndDeferrer<TResult>(
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
        ///     The Property Value Observer.
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
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
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
        ///     Creates the notify property observer with action and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
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
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
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
        ///     Creates the notify property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTTWithFallback!,
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
        ///     Creates the notify property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTTWithFallback!,
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
        ///     Creates the notify property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallback()
        {
            INotifyPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithFallback<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallback<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallback<TResult>(
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
        ///     Creates the property value observer builder with value changed and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Fallback!.Value,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.Fallback!.Value,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallbackAndDeferrer<TResult>(
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
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserver()
        {
            INotifyValuePropertyObserver<TResult> observer;
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
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithAction()
        {
            INotifyValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TResult>(
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
        ///     Creates the notify property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithActionAndDeferrer()
        {
            INotifyValuePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    (_, _) => this.Action!(),
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
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
        ///     Creates the notify property observer with action of null t.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithActionOfNullT()
        {
            INotifyValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionOfTT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionOfTT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionOfTT!,
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates the notify property observer with action of null t and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithActionOfNullTAndDeferrer()
        {
            INotifyValuePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTT!,
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
            CreateNotifyValuePropertyObserverWithDeferrer()
        {
            INotifyValuePropertyObserverWithDeferrer<TResult> observer;
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
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
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
        ///     The Property Value Observer.
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
        ///     The Property Value Observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback()
        {
            IPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallback<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallback<TResult>(
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
        ///     Creates the property observer with action of t and fallback with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IPropertyObserverWithDeferrer<TResult>
            CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            IPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallbackAndDeferrer<TResult>(
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
                observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TResult>(
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
        ///     Creates the property observer on notify property changed with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterValuePropertyObserverWithDeferrer<TResult> CreatePropertyValueObserverWithDeferrer()
        {
            IGetterValuePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithActionAndDeferrer<TResult>(
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
    }
}