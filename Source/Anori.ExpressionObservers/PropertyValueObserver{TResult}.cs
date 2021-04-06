﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.ValueTypeObservers;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Property Value Observer class.
    /// </summary>
    public static partial class PropertyValueObserver
    {
        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TResult : struct =>
            new PropertyValueObserver<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action<TResult?> action)
            where TResult : struct
        {
            var observer = new PropertyValueObserver<TResult>(propertyExpression, action);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static IPropertyValueObserverWithGetter<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : struct =>
            new PropertyValueObserverWithGetter<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static IPropertyValueObserverWithGetter<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action action)
            where TResult : struct
        {
            var observer = new PropertyValueObserverWithGetter<TResult>(propertyExpression, action);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult> ObservesOnNotifyProperyChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression)
            where TResult : struct =>
            new PropertyValueObserverOnNotifyProperyChanged<TResult>(propertyExpression);

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult> ObservesOnNotifyProperyChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode)
            where TResult : struct =>
            new PropertyValueObserverOnNotifyProperyChanged<TResult>(propertyExpression, isCached, safetyMode);

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult> ObservesOnNotifyProperyChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            TaskScheduler taskScheduler)
            where TResult : struct =>
            new PropertyValueObserverOnNotifyProperyChanged<TResult>(
                propertyExpression,
                taskScheduler,
                isCached,
                safetyMode);

        /// <summary>
        /// Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        /// The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult> ObservesOnNotifyProperyChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            TaskScheduler taskScheduler,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new PropertyValueObserverOnNotifyProperyChanged<TResult>(
                propertyExpression,
                taskScheduler,
                isCached,
                safetyMode);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult> ObservesOnNotifyProperyChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new PropertyValueObserverOnNotifyProperyChanged<TResult>(
                propertyExpression,
                isCached,
                safetyMode);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult> ObservesOnNotifyProperyChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new PropertyValueObserverOnNotifyProperyChanged<TResult>(propertyExpression);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression)
            where TResult : struct =>
            new PropertyValueObserverOnValueChanged<TResult>(propertyExpression);

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new PropertyValueObserverOnValueChanged<TResult>(propertyExpression);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler)
            where TResult : struct =>
            new PropertyValueObserverOnValueChanged<TResult>(propertyExpression, taskScheduler);

        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new PropertyValueObserverOnValueChanged<TResult>(propertyExpression, taskScheduler);
            if (isAutoActivate)
            {
                observer.Subscribe(true);
            }

            return observer;
        }
    }
}