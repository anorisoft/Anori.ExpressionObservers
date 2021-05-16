// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserver{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.ReferenceObservers.OnValueChanged;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer.
    /// </summary>
    public static partial class PropertyReferenceObserver
    {
        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static IGetterReferencePropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class =>
            new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static IGetterReferencePropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class
        {
            var observer =
                new ReferenceObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TParameter2, TResult>(
                    parameter1,
                    parameter2,
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
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static IGetterReferencePropertyObserver<TResult> ObservesAndGet<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : class
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged =>
            new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static IGetterReferencePropertyObserver<TResult> ObservesAndGet<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action action)
            where TResult : class
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
        {
            var observer = new ObserverWithActionAndGetter<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        ///// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="parameter2">The parameter2.</param>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <returns>
        /////     The Property Reference Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyReferencePropertyObserver<TResult>
        //    ObservesOnNotifyPropertyChanged<TParameter1, TParameter2, TResult>(
        //        [NotNull] TParameter1 parameter1,
        //        [NotNull] TParameter2 parameter2,
        //        [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
        //    where TParameter1 : INotifyPropertyChanged
        //    where TParameter2 : INotifyPropertyChanged
        //    where TResult : class =>
        //    new CachedObserver<TParameter1, TParameter2, TResult>(
        //        parameter1,
        //        parameter2,
        //        propertyExpression,
        //        PropertyObserverFlag.None);

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        ///// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="parameter2">The parameter2.</param>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <returns>
        /////     The Property Reference Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyReferencePropertyObserver<TResult>
        //    ObservesOnNotifyPropertyChanged<TParameter1, TParameter2, TResult>(
        //        [NotNull] TParameter1 parameter1,
        //        [NotNull] TParameter2 parameter2,
        //        [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
        //        bool isCached,
        //        LazyThreadSafetyMode safetyMode)
        //    where TResult : class
        //    where TParameter1 : INotifyPropertyChanged
        //    where TParameter2 : INotifyPropertyChanged =>
        //    new CachedObserver<TParameter1, TParameter2, TResult>(
        //        parameter1,
        //        parameter2,
        //        propertyExpression,
        //        isCached,
        //        safetyMode,
        //        PropertyObserverFlag.None);

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        ///// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="parameter2">The parameter2.</param>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <param name="taskScheduler">The task scheduler.</param>
        ///// <returns>
        /////     The Property Reference Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyReferencePropertyObserver<TResult>
        //    ObservesOnNotifyPropertyChanged<TParameter1, TParameter2, TResult>(
        //        [NotNull] TParameter1 parameter1,
        //        [NotNull] TParameter2 parameter2,
        //        [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
        //        bool isCached,
        //        LazyThreadSafetyMode safetyMode,
        //        TaskScheduler taskScheduler)
        //    where TResult : class
        //    where TParameter1 : INotifyPropertyChanged
        //    where TParameter2 : INotifyPropertyChanged =>
        //    new CachedObserver<TParameter1, TParameter2, TResult>(
        //        parameter1,
        //        parameter2,
        //        propertyExpression,
        //        taskScheduler,
        //        isCached,
        //        safetyMode,
        //        PropertyObserverFlag.None);

        ///// <summary>
        /////     Observeses the on notify Property changed.
        ///// </summary>
        ///// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        ///// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="parameter2">The parameter2.</param>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <param name="taskScheduler">The task scheduler.</param>
        ///// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        ///// <returns>
        /////     The Property Reference Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyReferencePropertyObserver<TResult>
        //    ObservesOnNotifyPropertyChanged<TParameter1, TParameter2, TResult>(
        //        [NotNull] TParameter1 parameter1,
        //        [NotNull] TParameter2 parameter2,
        //        [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
        //        bool isCached,
        //        LazyThreadSafetyMode safetyMode,
        //        TaskScheduler taskScheduler,
        //        bool isAutoActivate)
        //    where TResult : class
        //    where TParameter1 : INotifyPropertyChanged
        //    where TParameter2 : INotifyPropertyChanged
        //{
        //    var observer = new CachedObserver<TParameter1, TParameter2, TResult>(
        //        parameter1,
        //        parameter2,
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
        ///// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        ///// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="parameter2">The parameter2.</param>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isCached">if set to <c>true</c> [is cached].</param>
        ///// <param name="safetyMode">The safety mode.</param>
        ///// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        ///// <returns>The Property Reference Observer.</returns>
        //[NotNull]
        //public static INotifyReferencePropertyObserver<TResult>
        //    ObservesOnNotifyPropertyChanged<TParameter1, TParameter2, TResult>(
        //        [NotNull] TParameter1 parameter1,
        //        [NotNull] TParameter2 parameter2,
        //        [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
        //        bool isCached,
        //        LazyThreadSafetyMode safetyMode,
        //        bool isAutoActivate)
        //    where TResult : class
        //    where TParameter1 : INotifyPropertyChanged
        //    where TParameter2 : INotifyPropertyChanged
        //{
        //    var observer = new CachedObserver<TParameter1, TParameter2, TResult>(
        //        parameter1,
        //        parameter2,
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
        ///// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        ///// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="parameter1">The parameter1.</param>
        ///// <param name="parameter2">The parameter2.</param>
        ///// <param name="propertyExpression">The property expression.</param>
        ///// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        ///// <returns>
        /////     The Property Reference Observer.
        ///// </returns>
        //[NotNull]
        //public static INotifyReferencePropertyObserver<TResult>
        //    ObservesOnNotifyPropertyChanged<TParameter1, TParameter2, TResult>(
        //        [NotNull] TParameter1 parameter1,
        //        [NotNull] TParameter2 parameter2,
        //        [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
        //        bool isAutoActivate)
        //    where TResult : class
        //    where TParameter1 : INotifyPropertyChanged
        //    where TParameter2 : INotifyPropertyChanged
        //{
        //    var observer = new CachedObserver<TParameter1, TParameter2, TResult>(
        //        parameter1,
        //        parameter2,
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
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        [NotNull]
        public static INotifyReferencePropertyObserver<TResult>
            ObservesOnValueChanged<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class =>
            new Observer<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        [NotNull]
        public static INotifyReferencePropertyObserver<TResult>
            ObservesOnValueChanged<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                bool isAutoActivate)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class
        {
            var observer = new Observer<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static INotifyReferencePropertyObserver<TResult>
            ObservesOnValueChanged<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                [NotNull] TaskScheduler taskScheduler)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class =>
            new Observer<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                taskScheduler,
                PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        [NotNull]
        public static INotifyReferencePropertyObserver<TResult>
            ObservesOnValueChanged<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                [NotNull] TaskScheduler taskScheduler,
                bool isAutoActivate)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class
        {
            var observer = new Observer<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                taskScheduler,
                PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }
    }
}