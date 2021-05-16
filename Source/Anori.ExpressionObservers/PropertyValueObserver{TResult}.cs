// -----------------------------------------------------------------------
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
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.ValueObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ValueObservers.OnValueChanged;

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
        public static IGetterValuePropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TResult : struct =>
            new ValueObservers.OnPropertyChanged.ObserverWithAction<TResult>(
                propertyExpression,
                action,
                PropertyObserverFlag.None);

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
        public static IGetterValuePropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action<TResult?> action)
            where TResult : struct
        {
            var observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TResult>(
                propertyExpression,
                action,
                PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
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
        public static IGetterValuePropertyObserver<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : struct =>
            new ObserverWithActionAndGetter<TResult>(propertyExpression, action, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static IGetterValuePropertyObserver<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action action)
            where TResult : struct
        {
            var observer = new ObserverWithActionAndGetter<TResult>(propertyExpression, action, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <returns>
        /////     The Property Value Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyValuePropertyObserver<TResult> ObservesOnNotifyPropertyChanged<TResult>(
        //    [NotNull] Expression<Func<TResult>> propertyExpression)
        //    where TResult : struct =>
        //    new CachedObserver<TResult>(propertyExpression, PropertyObserverFlag.None);

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <returns>
        /////     The Property Value Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyValuePropertyObserver<TResult> ObservesOnNotifyPropertyChanged<TResult>(
        //    [NotNull] Expression<Func<TResult>> propertyExpression,
        //    bool isCached,
        //    LazyThreadSafetyMode safetyMode)
        //    where TResult : struct =>
        //    new CachedObserver<TResult>(
        //        propertyExpression,
        //        isCached,
        //        safetyMode,
        //        PropertyObserverFlag.None);

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <param name="taskScheduler">The task scheduler.</param>
        ///// <returns>
        /////     The Property Value Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyValuePropertyObserver<TResult> ObservesOnNotifyPropertyChanged<TResult>(
        //    [NotNull] Expression<Func<TResult>> propertyExpression,
        //    bool isCached,
        //    LazyThreadSafetyMode safetyMode,
        //    TaskScheduler taskScheduler)
        //    where TResult : struct =>
        //    new CachedObserver<TResult>(
        //        propertyExpression,
        //        taskScheduler,
        //        isCached,
        //        safetyMode,
        //        PropertyObserverFlag.None);

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <param name="taskScheduler">The task scheduler.</param>
        ///// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        ///// <returns>
        /////     The Property Value Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyValuePropertyObserver<TResult> ObservesOnNotifyPropertyChanged<TResult>(
        //    [NotNull] Expression<Func<TResult>> propertyExpression,
        //    bool isCached,
        //    LazyThreadSafetyMode safetyMode,
        //    TaskScheduler taskScheduler,
        //    bool isAutoActivate)
        //    where TResult : struct
        //{
        //    var observer = new CachedObserver<TResult>(
        //        propertyExpression,
        //        taskScheduler,
        //        isCached,
        //        safetyMode,
        //        PropertyObserverFlag.None);
        //    if (isAutoActivate)
        //    {
        //        observer.Activate(true);
        //    }

        //    return observer;
        //}

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        ///// <returns>
        /////     The Property Value Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyValuePropertyObserver<TResult> ObservesOnNotifyPropertyChanged<TResult>(
        //    [NotNull] Expression<Func<TResult>> propertyExpression,
        //    bool isCached,
        //    LazyThreadSafetyMode safetyMode,
        //    bool isAutoActivate)
        //    where TResult : struct
        //{
        //    var observer = new CachedObserver<TResult>(
        //        propertyExpression,
        //        isCached,
        //        safetyMode,
        //        PropertyObserverFlag.None);
        //    if (isAutoActivate)
        //    {
        //        observer.Activate(true);
        //    }

        //    return observer;
        //}

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        ///// <returns>
        /////     The Property Value Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyValuePropertyObserver<TResult> ObservesOnNotifyPropertyChanged<TResult>(
        //    [NotNull] Expression<Func<TResult>> propertyExpression,
        //    bool isAutoActivate)
        //    where TResult : struct
        //{
        //    var observer = new CachedObserver<TResult>(
        //        propertyExpression,
        //        PropertyObserverFlag.None);
        //    if (isAutoActivate)
        //    {
        //        observer.Activate(true);
        //    }

        //    return observer;
        //}

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression)
            where TResult : struct =>
            new Observer<TResult>(propertyExpression, PropertyObserverFlag.None);

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
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new Observer<TResult>(propertyExpression, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
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
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler)
            where TResult : struct =>
            new Observer<TResult>(propertyExpression, taskScheduler, PropertyObserverFlag.None);

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
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            bool isAutoActivate)
            where TResult : struct
        {
            var observer = new Observer<TResult>(propertyExpression, taskScheduler, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }
    }
}