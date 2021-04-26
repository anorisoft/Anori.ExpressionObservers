// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System;

    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;

    internal abstract partial class
      BuilderBase<TSelf, TResult> : BuilderBase<TSelf>
      where TSelf : BuilderBase<TSelf, TResult>
      where TResult : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderBase{TSelf,TResult}"/> class.
        /// </summary>
        protected BuilderBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverBuilderOnNotifyProperyChangedBaseOnNotifyProperyChangedBase{TSelf,TResult}" /> class.
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
        ///     Creates the property value observer builder with action of t result and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyGetterObserverWithFallback();

        /// <summary>
        ///     Creates the property value observer builder with action.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IPropertyObserver<TResult> CreatePropertyObserver();

        /// <summary>
        ///     Creates the property observer with action of t result and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult>
            CreatePropertyObserverWithActionOfTAndGetterAndFallback();

        /// <summary>
        ///     Creates the property value observer builder with action and getter and fallback.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterPropertyObserver<TResult>
            CreatePropertyObserverWithGetterAndFallback();

        /// <summary>
        ///     Creates the property value observer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserver();

        /// <summary>
        ///     Creates the property value observer builder with value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserver<TResult>
            CreatePropertyReferenceObserverBuilderOnValueChanged();

        /// <summary>
        ///     Creates the property reference observer builder with value changed and deferrer.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserverWithDeferrer<TResult>
            CreatePropertyReferenceObserverBuilderOnValueChangedAndDeferrer();

        /// <summary>
        ///     Creates the property value observer on notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract INotifyReferencePropertyObserver<TResult>
            CreatePropertyReferenceObserverOnNotifyProperyChanged();

        /// <summary>
        ///     Creates the property value observer builder with action and getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        protected abstract IGetterReferencePropertyObserver<TResult> CreatePropertyReferenceObserverWithGetter();

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
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf OnNotifyProperyChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        protected TSelf OnValueChanged() => (TSelf)this;

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer.
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