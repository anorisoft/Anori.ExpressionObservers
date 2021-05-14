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

    /// <summary>
    ///     The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract partial class BuilderBase<TSelf, TResult> : BuilderBase<TSelf>
        where TResult : struct where TSelf : BuilderBase<TSelf, TResult>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderBase{TSelf, TResult}" /> class.
        /// </summary>
        protected BuilderBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuilderBase{TSelf, TResult}" /> class.
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
        ///     Gets the action of tt.
        /// </summary>
        /// <value>
        ///     The action of tt.
        /// </value>
        private protected Action<TResult?, TResult?>? ActionOfTT { get; private set; }

        /// <summary>
        ///     Gets the action of t result with fallback.
        /// </summary>
        /// <value>
        ///     The action of t result with fallback.
        /// </value>
        private protected Action<TResult>? ActionOfTWithFallback { get; private set; }

        /// <summary>
        ///     Gets the action of tt with fallback.
        /// </summary>
        /// <value>
        ///     The action of tt with fallback.
        /// </value>
        private protected Action<TResult, TResult>? ActionOfTTWithFallback { get; private set; }

        /// <summary>
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the getter property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the getter property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the getter property observer with fallback with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithFallbackAndDeferrer();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserver();

        /// <summary>
        ///     Creates the getter value property observer cached.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserverCached();

        /// <summary>
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserver();

        /// <summary>
        ///     Creates the notify value property observer with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserverWithAction();

        /// <summary>
        ///     Creates the notify property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action of null t.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfNullT();

        /// <summary>
        ///     Creates the notify property observer with action of null t and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfNullTAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the property value observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult> CreateNotifyPropertyObserverWithDeferrer();

        /// <summary>
        ///     Creates the notify value property observer with fallback.
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
        ///     Creates the property value observer builder with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithAction();

        /// <summary>
        ///     Creates the property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Creates the getter property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the property observer with action of t and fallback with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserverWithDeferrer<TResult>
            CreatePropertyObserverWithActionOfTAndFallbackWithDeferrer();

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreatePropertyValueObserver();

        /// <summary>
        ///     Creates the property observer on notify property changed with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserverWithDeferrer<TResult> CreatePropertyValueObserverWithDeferrer();

        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf OnPropertyChanged() => (TSelf)this;

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
        ///     Withes the action of tt.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf WithActionOfTT(Action<TResult?, TResult?> action)
        {
            this.ActionOfTT = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the action of tt with fallback.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf WithActionOfTTWithFallback(Action<TResult, TResult> action)
        {
            this.ActionOfTTWithFallback = action;
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
        protected abstract IGetterValuePropertyObserverWithDeferrer<TResult> CreateGetterValuePropertyObserverAndDeferrer();
        protected abstract IGetterValuePropertyObserverWithDeferrer<TResult> CreateGetterValuePropertyObserverCachedAndDeferrer();
    }
}