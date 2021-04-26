// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using System;

    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;

    internal abstract partial class BuilderBase<TSelf, TResult> : BuilderBase<TSelf>
        where TResult : struct
        where TSelf : BuilderBase<TSelf, TResult>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderBase{TSelf,TResult}" /> class.
        /// </summary>
        protected BuilderBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderBase{TSelf,TResult}" /> class.
        /// </summary>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="isSilentActivate">if set to <c>true</c> [is silent activate].</param>
        protected BuilderBase(bool isAutoActivate, bool isSilentActivate)
            : base(isAutoActivate, isSilentActivate)
        {
        }

        /// <summary>
        ///     Gets the fallback.
        /// </summary>
        /// <value>
        ///     The fallback.
        /// </value>
        private protected TResult? Fallback { get; private set; }

        /// <summary>
        ///     Gets the action of t result.
        /// </summary>
        /// <value>
        ///     The action of t result.
        /// </value>
        private protected Action<TResult?>? ActionOfT { get; private set; }

        /// <summary>
        ///     Gets the action of t result with fallback.
        /// </summary>
        /// <value>
        ///     The action of t result with fallback.
        /// </value>
        private protected Action<TResult>? ActionOfTWithFallback { get; private set; }

        /// <summary>
        ///     Creates the getter property observer with action of t and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult>
            CreateGetterPropertyObserverWithActionOfTAndGetterAndFallback();

        /// <summary>
        ///     Creates the getter property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserver();

        /// <summary>
        ///     Creates the getter value property observer with action and getter and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult>
            CreateGetterValuePropertyObserverWithActionAndGetterAndScheduler();

        /// <summary>
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserver();

        /// <summary>
        ///     Creates the notify property observer with action and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action of t and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the notify property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the notify property observer with fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with fallback and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallbackAndScheduler();

        /// <summary>
        ///     Creates the notify value property observer with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithAction();

        /// <summary>
        ///     Creates the notify value property observer with action and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult>
            CreateNotifyValuePropertyObserverWithActionAndScheduler();

        /// <summary>
        ///     Creates the notify value property observer with deferrer and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithDeferrerAndScheduler();

        /// <summary>
        ///     Creates the notify value property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithFallback();

        /// <summary>
        ///     Creates the notify value property observer with fallback and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult>
            CreateNotifyValuePropertyObserverWithFallbackAndScheduler();

        /// <summary>
        ///     Creates the notify value property observer with scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithScheduler();

        /// <summary>
        ///     Creates the on property changed with action of t and getter and fallback and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult>
            CreateOnPropertyChangedWithActionOfTAndGetterAndFallbackAndScheduler();

        /// <summary>
        ///     Creates the property value observer builder with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithAction();

        /// <summary>
        ///     Creates the property observer with action of t and getter and fallback and scheduler.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult>
            CreatePropertyObserverWithActionOfTAndGetterAndFallbackAndScheduler();

        /// <summary>
        ///     Creates the property value observer builder with action and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> GetterPropertyObserverWithActionAndGetterAndFallback();

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreatePropertyValueObserver();

        /// <summary>
        ///     Creates the property value observer builder with value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreatePropertyValueObserverBuilderOnValueChanged();

        /// <summary>
        ///     Creates the property value observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreatePropertyValueObserverBuilderOnValueChangedAndDeferrer();

        /// <summary>
        ///     Creates the property value observer builder with value changed and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreatePropertyValueObserverBuilderOnValueChangedAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreatePropertyValueObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf OnProperyChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf OnValueChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the action of t result.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf WithActionOfT(Action<TResult?> action)
        {
            this.ActionOfT = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the action of t result with fallback.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf WithActionOfTWithFallback(Action<TResult> action)
        {
            this.ActionOfTWithFallback = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        /// <exception cref="Anori.ExpressionObservers.Exceptions.FallbackAlreadyDefineException">
        ///     Fallback Already Define
        ///     Exception.
        /// </exception>
        private TSelf WithFallback(TResult fallback)
        {
            if (this.Fallback.HasValue)
            {
                throw new FallbackAlreadyDefineException();
            }

            this.Fallback = fallback;
            return (TSelf)this;
        }
    }
}