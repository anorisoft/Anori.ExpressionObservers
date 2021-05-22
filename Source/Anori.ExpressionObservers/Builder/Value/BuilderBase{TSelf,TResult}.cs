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
        where TResult : struct
        where TSelf : BuilderBase<TSelf, TResult>
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
        private protected Action<TResult?>? ActionWithNewValue { get; private set; }

        /// <summary>
        ///     Gets the action of tt.
        /// </summary>
        /// <value>
        ///     The action of tt.
        /// </value>
        private protected Action<TResult?, TResult?>? ActionWithOldAndNewValue { get; private set; }

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
        private protected Action<TResult, TResult>? ActionWitOldAndNewValueWithFallback { get; private set; }

        /// <summary>
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the getter property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the getter property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the getter property observer with fallback with deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithFallbackAndDeferrer();

        /// <summary>
        ///     Creates the value property observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserver();

        /// <summary>
        ///     Creates the getter value property observer and deferrer.
        /// </summary>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        protected abstract IGetterValuePropertyObserverWithDeferrer<TResult>
            CreateGetterValuePropertyObserverAndDeferrer();

        /// <summary>
        ///     Creates the getter value property observer cached.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreateGetterValuePropertyObserverCached();

        /// <summary>
        ///     Creates the getter value property observer cached and deferrer.
        /// </summary>
        /// <returns>
        ///     The property reference observer builder.
        /// </returns>
        protected abstract IGetterValuePropertyObserverWithDeferrer<TResult>
            CreateGetterValuePropertyObserverCachedAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify value property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the notify property observer with fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserver();

        /// <summary>
        ///     Creates the notify value property observer with action.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithAction();

        /// <summary>
        ///     Creates the notify property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action of null t.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserver<TResult> CreateNotifyValuePropertyObserverWithActionOfNullT();

        /// <summary>
        ///     Creates the notify property observer with action of null t and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithActionOfNullTAndDeferrer();

        /// <summary>
        ///     Creates the value property observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract INotifyValuePropertyObserverWithDeferrer<TResult>
            CreateNotifyValuePropertyObserverWithDeferrer();

        /// <summary>
        ///     Creates the value property observer builder with action.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithAction();

        /// <summary>
        ///     Creates the property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Creates the getter property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the property observer with action of t and fallback with deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IPropertyObserverWithDeferrer<TResult>
            CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the value property observer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserver<TResult> CreatePropertyValueObserver();

        /// <summary>
        ///     Creates the property observer on notify property changed with deferrer.
        /// </summary>
        /// <returns>
        ///     The value property observer.
        /// </returns>
        protected abstract IGetterValuePropertyObserverWithDeferrer<TResult> CreatePropertyValueObserverWithDeferrer();

        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        private TSelf OnPropertyChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        private TSelf OnValueChanged() => (TSelf)this;

        /// <summary>
        ///     Builder with action with new value.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        private TSelf WithActionWithNewValue(Action<TResult?> action)
        {
            this.ActionWithNewValue = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Builder with action with old and new value.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        private TSelf WithActionWithOldAndNewValue(Action<TResult?, TResult?> action)
        {
            this.ActionWithOldAndNewValue = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Builder with action of tt with fallback.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        private TSelf WithActionWithOldAndNewValueWithFallback(Action<TResult, TResult> action)
        {
            this.ActionWitOldAndNewValueWithFallback = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Builder with action of t result with fallback.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The value property observer builder.
        /// </returns>
        private TSelf WithActionOfTWithFallback(Action<TResult> action)
        {
            this.ActionOfTWithFallback = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Builder with fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The value property observer builder.
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