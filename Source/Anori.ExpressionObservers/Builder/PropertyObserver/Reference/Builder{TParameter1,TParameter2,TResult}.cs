// -----------------------------------------------------------------------
// <copyright file="Builder{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
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
    /// The Builder class.
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
        ///     The Property Value Observer.
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
                    this.ActionOfTWithFallback!,
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
                    this.ActionOfTWithFallback!,
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
        protected override IGetterReferencePropertyObserverWithDeferrer<TResult> CreateGetterReferencePropertyObserverAndDeferrer()
        {
            throw new NotImplementedException();
        }
        protected override IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserverCached()
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
        protected override INotifyPropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer()
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
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
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
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
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
                observer = new ObserverWithActionAndFallback<TParameter1, TParameter2, TResult>(
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
        ///     The Property Value Observer.
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
        ///     The Property Value Observer.
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
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult> CreateNotifyReferencePropertyObserverWithActionAndDeferrer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the property value observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
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
        ///     The Property Observer.
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
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
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
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
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
                observer = new ObserverWithActionOfTAndFallback<TParameter1, TParameter2, TResult>(
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
        protected override IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
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
                        this.ActionOfT!,
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
                        this.ActionOfT!,
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
                        this.ActionOfT!,
                        this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }
        protected override IGetterReferencePropertyObserverWithDeferrer<TResult> CreatePropertyReferenceObserverWithDeferrer()
        {
            throw new NotImplementedException();
        }
        protected override INotifyReferencePropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithActionOfTNullAndDeferrer()
        {
            throw new NotImplementedException();
        }
    }
}