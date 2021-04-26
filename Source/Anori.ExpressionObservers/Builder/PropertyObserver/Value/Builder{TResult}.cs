// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilder{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;
    using Anori.ExpressionObservers.ValueObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ValueObservers.OnValueChanged;
    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="BuilderBuilderBase{TSelf,TResult}.ExpressionObservers.Builder.PropertyValueObserverBuilder{TResult}, TResult}" />
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
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public Builder(Expression<Func<TResult>> propertyExpression) => this.propertyExpression = propertyExpression;

        /// <summary>
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
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

        protected override IGetterPropertyObserver<TResult>
            CreateGetterPropertyObserverWithActionOfTAndGetterAndFallback()
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
        protected override IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback()
        {
            throw new NotImplementedException();
        }
        protected override IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserver()
        {
            IGetterValuePropertyObserver<TResult> observer;


            if (this.IsDispached)
            {
                observer = new ObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithGetter<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.ObserverFlag);
            }
        }
        protected override IGetterValuePropertyObserver<TResult>
            CreateGetterValuePropertyObserverWithActionAndGetterAndScheduler()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserver()
        {
            INotifyValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueTypeObservers.Observer<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueTypeObservers.Observer<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueTypeObservers.Observer<TResult>(this.propertyExpression, this.ObserverFlag);
            }

            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback()
        {
            throw new NotImplementedException();
        }
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback()
        {
            throw new NotImplementedException();
        }
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallback()
        {
            throw new NotImplementedException();
        }
        protected override INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer()
        {
            throw new NotImplementedException();
        }
        protected override INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallbackAndScheduler()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithAction()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult>
            CreateNotifyValuePropertyObserverWithActionAndScheduler()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithDeferrerAndScheduler()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithFallback()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult>
            CreateNotifyValuePropertyObserverWithFallbackAndScheduler()
        {
            throw new NotImplementedException();
        }
        protected override INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithScheduler()
        {
            throw new NotImplementedException();
        }
        protected override IGetterPropertyObserver<TResult>
            CreateOnPropertyChangedWithActionOfTAndGetterAndFallbackAndScheduler()
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
            var observer = new ValueObservers.OnPropertyChanged.Observer<TResult>(this.propertyExpression, this.Action!, this.ObserverFlag);
            if (this.IsAutoActivate)
            {
                observer.Activate(this.IsSilentActivate);
            }

            return observer;
        }

        protected override IGetterPropertyObserver<TResult>
            CreatePropertyObserverWithActionOfTAndGetterAndFallbackAndScheduler()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Creates the property value observer builder with action and dispatcher getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected override IGetterPropertyObserver<TResult> GetterPropertyObserverWithActionAndGetterAndFallback()
        {
            IGetterPropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new GetterObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new GetterObserverWithActionAndGetterAndFallback<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.Fallback!.Value,
                    this.ObserverFlag);
            }
            else
            {
                observer = new GetterObserverWithActionAndGetterAndFallback<TResult>(
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
                observer = new ValueObservers.OnPropertyChanged.Observer<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObservers.OnPropertyChanged.Observer<TResult>(
                    this.propertyExpression,
                    this.ActionOfT!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObservers.OnPropertyChanged.Observer<TResult>(
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
        protected override IGetterPropertyObserver<TResult> CreatePropertyValueObserverBuilderOnValueChanged()
        {
            throw new NotImplementedException();
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
                observer = new ObserverWithDefer<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDefer<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDefer<TResult>(this.propertyExpression, this.ObserverFlag);
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
            CreatePropertyValueObserverBuilderOnValueChangedAndFallbackAndDeferrer()
        {
            INotifyPropertyObserverWithDeferrer<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ObserverWithDeferWithFallback<TResult>(
                    this.propertyExpression,
                    this.Fallback!.Value,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ObserverWithDeferWithFallback<TResult>(
                    this.propertyExpression,
                    this.Fallback!.Value,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ObserverWithDeferWithFallback<TResult>(
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
                observer = new ValueObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    SynchronizationContext.Current,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueObserverOnNotifyProperyChanged<TResult>(
                    this.propertyExpression,
                    this.TaskScheduler,
                    this.IsCached,
                    this.SafetyMode,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueObserverOnNotifyProperyChanged<TResult>(
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









        protected override IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserverWithGetter()
        {
            IGetterValuePropertyObserver<TResult> observer;
            if (this.IsDispached)
            {
                observer = new ValueTypeObservers.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    SynchronizationContext.Current,
                    this.ObserverFlag);
            }
            else if (this.TaskScheduler != null)
            {
                observer = new ValueTypeObservers.ObserverWithAction<TResult>(
                    this.propertyExpression,
                    this.Action!,
                    this.TaskScheduler,
                    this.ObserverFlag);
            }
            else
            {
                observer = new ValueTypeObservers.ObserverWithAction<TResult>(
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