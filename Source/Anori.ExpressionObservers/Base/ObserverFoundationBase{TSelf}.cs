// -----------------------------------------------------------------------
// <copyright file="ObserverFoundationBase{TSelf}.cs" company="AnoriSoft">
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
    ///     Property observer base for fluent API.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <seealso cref="ObserverFoundationBase" />
    internal abstract class ObserverFoundationBase<TSelf> : ObserverFoundationBase,
                                                            IPropertyObserverBase<TSelf>,
                                                            IEqualityComparer<TSelf>
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverFoundationBase{TSelf}" /> class.
        /// </summary>
        /// <param name="observerFlag">The observer flag.</param>
        protected ObserverFoundationBase(PropertyObserverFlag observerFlag)
            : base(observerFlag)
        {
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        public new TSelf Activate() => this.Activate(false);

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
        ///     Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        ///     true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(TSelf x, TSelf y) =>
            Equals(
                (ObserverFoundationBase)(IPropertyObserverBase<TSelf>)x,
                (ObserverFoundationBase)(IPropertyObserverBase<TSelf>)y);

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public int GetHashCode(TSelf obj) =>
            this.GetHashCode((ObserverFoundationBase)(IPropertyObserverBase<TSelf>)obj);

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
        ///     Creates the nullable cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="action">The action.</param>
        /// <returns>Value getter function.</returns>
        protected (Action, Func<TResult>) CreateCachedGetter<TResult>(
            Func<TResult> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            Action action)
        {
            Action returnAction;
            Func<TResult> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult>(get, safetyMode);
                returnAction = () =>
                    {
                        cache.Reset();
                        action.Raise();
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
                returnAction = () => action.Raise();
                getter = this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                             ? () =>
                                 {
                                     if (this.IsActive)
                                     {
                                         return get();
                                     }

                                     throw new NotActivatedException();
                                 }
                             : get;
            }

            return (returnAction, getter);
        }

        /// <summary>
        ///     Creates the cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="action">The action.</param>
        /// <returns>Value getter function.</returns>
        protected (Action, Func<TResult>) CreateCachedGetter<TResult>(
            Func<TResult> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            Action<TResult> action)
        {
            Action returnAction;
            Func<TResult> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult>(get, safetyMode);

                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    getter = () => this.IsActive ? cache.Value : throw new NotActivatedException();
                }
                else
                {
                    getter = () => cache.Value;
                }

                returnAction = () =>
                    {
                        cache.Reset();
                        action.Raise(getter());
                    };
            }
            else
            {
                getter = this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                             ? () =>
                                 {
                                     if (this.IsActive)
                                     {
                                         return get();
                                     }

                                     throw new NotActivatedException();
                                 }
                             : get;

                returnAction = () => action.Raise(getter());
            }

            return (returnAction, getter);
        }

        /// <summary>
        ///     Creates the cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>Value getter function.</returns>
        protected (Action, Func<TResult>) CreateCachedGetter<TResult>(
            Func<TResult> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode)
        {
            Action action;
            Func<TResult> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult>(get, safetyMode);
                action = () => { cache.Reset(); };
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
                action = () => { };
                getter = this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                             ? () =>
                                 {
                                     if (this.IsActive)
                                     {
                                         return get();
                                     }

                                     throw new NotActivatedException();
                                 }
                             : get;
            }

            return (action, getter);
        }

        /// <summary>
        ///     Creates the get property nullable value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Value getter function.</returns>
        protected Func<TValue> CreateGetProperty<TValue>(Func<TValue> value) =>
            this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                ? () =>
                    {
                        if (this.IsActive)
                        {
                            return value();
                        }

                        throw new NotActivatedException();
                    }
                : value;

        /// <summary>
        ///     Creates the get property nullable reference.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     Value getter function.
        /// </returns>
        protected Func<TValue?> CreateGetPropertyNullableReference<TValue>(Func<TValue?> value)
            where TValue : class =>
            this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                ? () =>
                    {
                        if (this.IsActive)
                        {
                            return value();
                        }

                        throw new NotActivatedException();
                    }
                : value;

        /// <summary>
        ///     Creates the get property nullable value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     Value getter function.
        /// </returns>
        protected Func<TValue?> CreateGetPropertyNullableValue<TValue>(Func<TValue?> value)
            where TValue : struct =>
            this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                ? () =>
                    {
                        if (this.IsActive)
                        {
                            return value();
                        }

                        throw new NotActivatedException();
                    }
                : value;

        /// <summary>
        ///     Creates the dispatcher getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        /// <returns>Value getter function.</returns>
        protected Func<TResult>
            CreateGetter<TResult>(Func<TResult> get, SynchronizationContext synchronizationContext) =>
            this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                ? () =>
                    {
                        if (this.IsActive)
                        {
                            return synchronizationContext.Send(get);
                        }

                        throw new NotActivatedException();
                    }
                : () => synchronizationContext.Send(get);

        /// <summary>
        ///     Creaters the getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        protected Func<TParameter1, TResult> CreateGetter<TParameter1, TResult>(Func<TParameter1, TResult> get)
        {
            return this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                       ? p1 =>
                           {
                               if (this.IsActive)
                               {
                                   return get(p1);
                               }

                               throw new NotActivatedException();
                           }
                       : get;
        }

        /// <summary>
        ///     Creates the getter.
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
        /// <returns>Value getter function.</returns>
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
                getter = this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                             ? () =>
                                 {
                                     if (this.IsActive)
                                     {
                                         return get();
                                     }

                                     throw new NotActivatedException();
                                 }
                             : get;
            }

            return (action, getter);
        }

        /// <summary>
        ///     Creates the nullable reference cached getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>Value getter function.</returns>
        protected (Action, Func<TResult?>) CreateNullableReferenceCachedGetter<TResult>(
            Func<TResult?> get,
            bool isCached,
            LazyThreadSafetyMode safetyMode)
            where TResult : class
        {
            Action action;
            Func<TResult?> getter;
            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(get, safetyMode);
                action = () => { cache.Reset(); };
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
                action = () => { };
                getter = this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                             ? () =>
                                 {
                                     if (this.IsActive)
                                     {
                                         return get();
                                     }

                                     throw new NotActivatedException();
                                 }
                             : get;
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
        /// <returns>Value getter function.</returns>
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
                getter = this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                             ? () =>
                                 {
                                     if (this.IsActive)
                                     {
                                         return get();
                                     }

                                     throw new NotActivatedException();
                                 }
                             : get;
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
            return this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                       ? () =>
                           {
                               if (this.IsActive)
                               {
                                   return synchronizationContext.Send(get);
                               }

                               throw new NotActivatedException();
                           }
                       : () => synchronizationContext.Send(get);
        }

        /// <summary>
        ///     Creates the nullable value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="get">The get.</param>
        /// <returns>Value getter function.</returns>
        protected Func<TResult?> CreateNullableValueGetter<TResult>(Func<TResult?> get)
            where TResult : struct
        {
            return this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated)
                       ? () =>
                           {
                               if (this.IsActive)
                               {
                                   return get();
                               }

                               throw new NotActivatedException();
                           }
                       : get;
        }

        /// <summary>
        ///     Creates the value resetter.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The resetter action.</returns>
        protected Action CreateValueResetter(Action action) =>
            this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated) ? () => { } : action;
    }
}