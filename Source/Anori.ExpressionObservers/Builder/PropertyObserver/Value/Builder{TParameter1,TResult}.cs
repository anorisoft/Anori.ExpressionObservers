// -----------------------------------------------------------------------
// <copyright file="Builder{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;
    using System.ComponentModel;
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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class Builder<TParameter1, TResult> : BuilderBase<Builder<TParameter1, TResult>, TResult>
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
        ///     Initializes a new instance of the <see cref="Builder{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public Builder(TParameter1 parameter1, Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.propertyExpression = propertyExpression;
        }

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
                observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
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
        protected override IGetterPropertyObserverWithDeferrer<TResult> CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TResult>(
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
        protected override IGetterPropertyObserverWithDeferrer<TResult> CreateGetterPropertyObserverWithFallbackAndDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithActionAndGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndGetter<TParameter1, TResult>(
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
                observer = new ObserverWithActionAndCachedGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndCachedGetter<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndCachedGetter<TParameter1, TResult>(
                    this.parameter1,
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
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserver()
        {
            INotifyValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new Observer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new Observer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new Observer<TParameter1, TResult>(
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
        protected override INotifyValuePropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithActionAndDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithActionAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    _ => this.Action!(),
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    _ => this.Action!(),
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    _ => this.Action!(),
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }
        protected override INotifyPropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfNullT()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithActionOfNullTAndDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithActionAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionAndFallback<TParameter1, TResult>(
                    this.parameter1,
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
        protected override INotifyPropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithFallback<TParameter1, TResult>(
                    this.parameter1,
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
                observer = new ObserverWithDeferWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Fallback!.Value,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDeferWithFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.Fallback!.Value,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDeferWithFallback<TParameter1, TResult>(
                    this.parameter1,
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
        ///     Creates the notify value property observer with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserverWithAction()
        {
            INotifyValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    _ => this.Action!(),
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    _ => this.Action!(),
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnValueChanged.ObserverWithAction<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    _ => this.Action!(),
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
            CreateNotifyPropertyObserverWithDeferrer()
        {
            INotifyValuePropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDefer<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDefer<TParameter1, TResult>(
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
        protected override IGetterValuePropertyObserverWithDeferrer<TResult> CreatePropertyValueObserverWithDeferrer()
        {
            throw new NotImplementedException();
        }
        protected override IGetterValuePropertyObserverWithDeferrer<TResult> CreateGetterValuePropertyObserverAndDeferrer()
        {
            throw new NotImplementedException();
        }
        protected override IGetterValuePropertyObserverWithDeferrer<TResult> CreateGetterValuePropertyObserverCachedAndDeferrer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        protected override IPropertyObserver<TResult> CreatePropertyObserverWithAction()
        {
            var observer = new Observers.OnPropertyChanged.ObserverWithAction<TParameter1, TResult>(
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
        protected override IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionAndDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfTWithFallback!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TResult>(
                    this.parameter1,
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
        protected override IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionOfTAndFallbackWithDeferrer()
        {
            throw new NotImplementedException();
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
                observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TResult>(
                    this.parameter1,
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TResult>(
                    this.parameter1,
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