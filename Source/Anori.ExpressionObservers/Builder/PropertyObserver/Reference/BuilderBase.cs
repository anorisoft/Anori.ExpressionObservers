// -----------------------------------------------------------------------
// <copyright file="BuilderBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
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
        where TSelf : BuilderBase<TSelf, TResult>
        where TResult : class
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Reference.BuilderBase{TSelf,TResult}" /> class.
        /// </summary>
        protected BuilderBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Reference.BuilderBase{TSelf,TResult}" /> class.
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
        private protected Action<TResult>? ActionWithNewValueWithFallback { get; private set; }

        /// <summary>
        ///     Gets the action of tt with fallback.
        /// </summary>
        /// <value>
        ///     The action of tt with fallback.
        /// </value>
        private protected Action<TResult, TResult>? ActionWithOldAndNewValueWithFallback { get; private set; }

        /// <summary>
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the getter property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the getter property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult> CreateGetterPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the getter property observer with fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterPropertyObserverWithDeferrer<TResult>
            CreateGetterPropertyObserverWithFallbackAndDeferrer();

        /// <summary>
        ///     Creates the Property Reference observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserver();

        /// <summary>
        ///     Creates the getter reference property observer and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserverWithDeferrer<TResult>
            CreateGetterReferencePropertyObserverAndDeferrer();

        /// <summary>
        ///     Creates the getter value property observer cached.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserver<TResult> CreateGetterReferencePropertyObserverCached();

        /// <summary>
        ///     Creates the notify property observer with action and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the notify property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer with action of t null and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected abstract INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithActionOfTNullAndDeferrer();

        /// <summary>
        ///     Creates the notify value property observer with fallback.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyPropertyObserver<TResult> CreateNotifyPropertyObserverWithFallback();

        /// <summary>
        ///     Creates the notify property observer with fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyPropertyObserverWithDeferrer<TResult>
            CreateNotifyPropertyObserverWithFallbackAndDeferrer();

        /// <summary>
        ///     Creates the notify property observer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserver<TResult> CreateNotifyReferencePropertyObserver();

        /// <summary>
        ///     Creates the notify value property observer with action.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserver<TResult> CreateNotifyReferencePropertyObserverWithAction();

        /// <summary>
        ///     Creates the notify reference property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyReferencePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Creates the Property Reference observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreateNotifyReferencePropertyObserverWithDeferrer();

        /// <summary>
        ///     Creates the Property Reference observer builder with action.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithAction();

        /// <summary>
        ///     Creates the property observer with action and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IPropertyObserverWithDeferrer<TResult> CreatePropertyObserverWithActionAndDeferrer();

        /// <summary>
        ///     Creates the getter property observer with action of T and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserverWithActionOfTAndFallback();

        /// <summary>
        ///     Creates the property observer with action of t and fallback and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IPropertyObserverWithDeferrer<TResult>
            CreatePropertyObserverWithActionOfTAndFallbackAndDeferrer();

        /// <summary>
        ///     Creates the Property Reference observer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserver();

        /// <summary>
        ///     Creates the property reference observer with deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserverWithDeferrer<TResult>
            CreatePropertyReferenceObserverWithDeferrer();

        /// <summary>
        ///     Withes the notify Property changed.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected TSelf OnPropertyChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected TSelf OnValueChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the action of tt with fallback.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected TSelf WithActionWithOldAndNewValueWithFallback(Action<TResult, TResult> action)
        {
            this.ActionWithOldAndNewValueWithFallback = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the action of t result with fallback.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected TSelf WithActionWithNewValueWithFallback(Action<TResult> action)
        {
            this.ActionWithNewValueWithFallback = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the action of t result.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected TSelf WithNullableActionWitNewValue(Action<TResult?> action)
        {
            this.ActionWithNewValue = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the nullable action of tt.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        protected TSelf WithNullableActionWithOldAndNewValue(Action<TResult?, TResult?> action)
        {
            this.ActionWithOldAndNewValue = action;
            return (TSelf)this;
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Reference Observer Builder.
        /// </returns>
        /// <exception cref="Anori.ExpressionObservers.Exceptions.FallbackAlreadyDefineException">
        ///     Fallback Already Define
        ///     Exception.
        /// </exception>
        private TSelf WithFallback(TResult fallback)
        {
            if (this.Fallback != null)
            {
                throw new FallbackAlreadyDefineException();
            }

            this.Fallback = fallback;
            return (TSelf)this;
        }
    }
}