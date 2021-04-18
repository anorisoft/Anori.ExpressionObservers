// -----------------------------------------------------------------------
// <copyright file="PropertyObserverFundatinBase{TSelf}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Observer Base for flurnent.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal abstract class PropertyObserverFundatinBase<TSelf> : PropertyObserverFundatinBase,
                                                                  IPropertyObserverBase<TSelf>,
                                                                  IEqualityComparer<TSelf>

        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverFundatinBase{TSelf}" /> class.
        /// </summary>
        /// <param name="observerFlag">PropertyObserverFlag.</param>
        protected PropertyObserverFundatinBase(PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        public new TSelf Activate()
        {
            return this.Activate(false);
        }

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>
        ///     Self object.
        /// </returns>
        public new TSelf Activate(bool silent)
        {
            base.Activate(silent);
            return (TSelf)(IPropertyObserverBase<TSelf>)this;
        }

        /// <summary>
        ///     Unsubscribes this instance.
        /// </summary>
        /// <returns>Self object.</returns>
        public new TSelf Deactivate()
        {
            base.Deactivate();
            return (TSelf)(IPropertyObserverBase<TSelf>)this;
        }

        /// <summary>
        ///     Creates the nullable cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="propertyChanged">The property changed.</param>
        /// <returns>Valeu getter function.</returns>
        protected (Action, Func<TResult>) CreateCachedGetter<TResult>(
            Func<TResult> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            Action propertyChanged)
        {
            Action action;
            Func<TResult> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult>(get, safetyMode);
                action = () =>
                    {
                        cache.Reset();
                        propertyChanged.Raise();
                    };
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? cache.Value : throw new NotActivatedException();
                }
                else
                {
                    getter = () => cache.Value;
                }
            }
            else
            {
                action = () => propertyChanged.Raise();
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? get() : throw new NotActivatedException();
                }
                else
                {
                    getter = get;
                }
            }

            return (action, getter);
        }

        /// <summary>
        ///     Creates the get property nullable value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Valeu getter function.</returns>
        protected Func<TValue> CreateGetProperty<TValue>(Func<TValue> value)
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? value() : throw new NotActivatedException();
            }

            return value;
        }

        /// <summary>
        ///     Creates the get property nullable reference.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     Valeu getter function.
        /// </returns>
        protected Func<TValue?> CreateGetPropertyNullableReference<TValue>(Func<TValue?> value)
            where TValue : class
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? value() : throw new NotActivatedException();
            }

            return value;
        }

        /// <summary>
        ///     Creates the get property nullable value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     Value getter function.
        /// </returns>
#pragma warning disable S4144 // Methods should not have identical implementations
        protected Func<TValue?> CreateGetPropertyNullableValue<TValue>(Func<TValue?> value)
#pragma warning restore S4144 // Methods should not have identical implementations
            where TValue : struct
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? value() : throw new NotActivatedException();
            }

            return value;
        }

        /// <summary>
        ///     Creates the dispatcher getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        /// <returns>Valeu getter function.</returns>
        protected Func<TResult> CreateGetter<TResult>(Func<TResult> get, SynchronizationContext synchronizationContext)
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? synchronizationContext.Send(get) : throw new NotActivatedException();
            }

            return () => synchronizationContext.Send(get);
        }

        /// <summary>
        ///     Creaters the getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        protected Func<TResult> CreateGetter<TResult>(Func<TResult> get)
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? get() : throw new NotActivatedException();
            }

            return get;
        }

        /// <summary>
        ///     Creates the task factory getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        protected Func<TResult> CreateGetter<TResult>(Func<TResult> get, TaskScheduler taskScheduler)
        {
            var taskFactory = new TaskFactory(taskScheduler);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? taskFactory.StartNew(get).Result : throw new NotActivatedException();
            }

            return () => taskFactory.StartNew(get).Result;
        }

        /// <summary>
        ///     Creates the nullable reference cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="propertyChanged">The property changed.</param>
        /// <returns>Valeu getter function.</returns>
        protected (Action, Func<TResult?>) CreateNullableReferenceCachedGetter<TResult>(
            Func<TResult?> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            Action propertyChanged)
            where TResult : class
        {
            Action action;
            Func<TResult?> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(get, safetyMode);
                action = () =>
                    {
                        cache.Reset();
                        propertyChanged.Raise();
                    };
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? cache.Value : throw new NotActivatedException();
                }
                else
                {
                    getter = () => cache.Value;
                }
            }
            else
            {
                action = () => propertyChanged.Raise();
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? get() : throw new NotActivatedException();
                }
                else
                {
                    getter = get;
                }
            }

            return (action, getter);
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>The Getter.</returns>
        protected Func<TResult?> CreateNullableReferenceGetter<TResult>(Func<TResult?> get, TaskScheduler taskScheduler)
            where TResult : class
        {
            var taskFactory = new TaskFactory(taskScheduler);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? taskFactory.StartNew(get).Result : throw new NotActivatedException();
            }

            return () => taskFactory.StartNew(get).Result;
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <returns>The Getter.</returns>
        protected Func<TResult?> CreateNullableReferenceGetter<TResult>(
            Func<TResult?> get,
            SynchronizationContext synchronizationContext)
            where TResult : class
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? synchronizationContext.Send(get) : throw new NotActivatedException();
            }

            return () => synchronizationContext.Send(get);
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <returns>The Getter.</returns>
        protected Func<TResult?> CreateNullableReferenceGetter<TResult>(Func<TResult?> get)
            where TResult : class
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? get() : throw new NotActivatedException();
            }

            return get;
        }

        /// <summary>
        ///     Creates the nullable value cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="propertyChanged">The property changed.</param>
        /// <returns>Valeu getter function.</returns>
#pragma warning disable S4144 // Methods should not have identical implementations
        protected (Action, Func<TResult?>) CreateNullableValueCachedGetter<TResult>(
            Func<TResult?> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            Action propertyChanged)
#pragma warning restore S4144 // Methods should not have identical implementations
            where TResult : struct
        {
            Action action;
            Func<TResult?> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(get, safetyMode);
                action = () =>
                    {
                        cache.Reset();
                        propertyChanged.Raise();
                    };
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? cache.Value : throw new NotActivatedException();
                }
                else
                {
                    getter = () => cache.Value;
                }
            }
            else
            {
                action = () => propertyChanged.Raise();
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? get() : throw new NotActivatedException();
                }
                else
                {
                    getter = get;
                }
            }

            return (action, getter);
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>Valeu getter function.</returns>
#pragma warning disable S4144 // Methods should not have identical implementations
        protected Func<TResult?> CreateNullableValueGetter<TResult>(Func<TResult?> get, TaskScheduler taskScheduler)
#pragma warning restore S4144 // Methods should not have identical implementations
            where TResult : struct
        {
            var taskFactory = new TaskFactory(taskScheduler);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? taskFactory.StartNew(get).Result : throw new NotActivatedException();
            }

            return () => taskFactory.StartNew(get).Result;
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <returns>Valeu getter function.</returns>
#pragma warning disable S4144 // Methods should not have identical implementations
        protected Func<TResult?> CreateNullableValueGetter<TResult>(
            Func<TResult?> get,
            SynchronizationContext synchronizationContext)
#pragma warning restore S4144 // Methods should not have identical implementations
            where TResult : struct
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? synchronizationContext.Send(get) : throw new NotActivatedException();
            }

            return () => synchronizationContext.Send(get);
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <returns>Valeu getter function.</returns>
#pragma warning disable S4144 // Methods should not have identical implementations
        protected Func<TResult?> CreateNullableValueGetter<TResult>(Func<TResult?> get)
#pragma warning restore S4144 // Methods should not have identical implementations
            where TResult : struct
        {
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? get() : throw new NotActivatedException();
            }

            return get;
        }
        public bool Equals(TSelf x, TSelf y)
        {
            return Equals((PropertyObserverFundatinBase)(IPropertyObserverBase<TSelf>)x, (PropertyObserverFundatinBase)(IPropertyObserverBase<TSelf>)y);
        }

        public int GetHashCode(TSelf obj)
        {
            return GetHashCode((PropertyObserverFundatinBase)(IPropertyObserverBase<TSelf>)obj);
        }
    }
}