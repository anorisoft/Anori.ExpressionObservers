﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserver{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using Anori.Common;
    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.ValueTypeObservers;
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// The Property Value Observer class.
    /// </summary>
    public static partial class PropertyValueObserver
    {
        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserver<TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueObserver<TParameter1, TResult>(parameter1, propertyExpression, action, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserver<TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var observer =
                new PropertyValueObserver<TParameter1, TResult>(parameter1, propertyExpression, action, PropertyObserverFlag.None);
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static IPropertyValueObserverWithGetter<TResult> ObservesAndGet<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyValueObserverWithGetter<TParameter1, TResult>(parameter1, propertyExpression, action, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverWithGetter<TResult> ObservesAndGet<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action action)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged
        {
            var observer =
                new PropertyValueObserverWithGetter<TParameter1, TResult>(parameter1, propertyExpression, action, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult>
            ObservesOnNotifyProperyChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(parameter1, propertyExpression, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult>
            ObservesOnNotifyProperyChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                bool isCached,
                LazyThreadSafetyMode safetyMode)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                isCached,
                safetyMode, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult>
            ObservesOnNotifyProperyChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                bool isCached,
                LazyThreadSafetyMode safetyMode,
                TaskScheduler taskScheduler)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                taskScheduler,
                isCached,
                safetyMode, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult>
            ObservesOnNotifyProperyChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                bool isCached,
                LazyThreadSafetyMode safetyMode,
                TaskScheduler taskScheduler,
                bool isAutoActivate)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged
        {
            var observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                taskScheduler,
                isCached,
                safetyMode, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult>
            ObservesOnNotifyProperyChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                bool isCached,
                LazyThreadSafetyMode safetyMode,
                bool isAutoActivate)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged
        {
            var observer = new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                isCached,
                safetyMode, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the on notify propery changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnNotifyProperyChanged<TResult>
            ObservesOnNotifyProperyChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                bool isAutoActivate)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged
        {
            var observer =
                new PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult>(parameter1, propertyExpression, PropertyObserverFlag.None);
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult>
            ObservesOnValueChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueObserverOnValueChanged<TParameter1, TResult>(parameter1, propertyExpression, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult>
            ObservesOnValueChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                bool isAutoActivate)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var observer =
                new PropertyValueObserverOnValueChanged<TParameter1, TResult>(parameter1, propertyExpression, PropertyObserverFlag.None);
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult>
            ObservesOnValueChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                [NotNull] TaskScheduler taskScheduler)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                taskScheduler, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the on value changed.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isAutoActivate">if set to <c>true</c> [is automatic activate].</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static IPropertyValueObserverOnValueChanged<TResult>
            ObservesOnValueChanged<TParameter1, TResult>(
                [NotNull] this TParameter1 parameter1,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                [NotNull] TaskScheduler taskScheduler,
                bool isAutoActivate)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var observer = new PropertyValueObserverOnValueChanged<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                taskScheduler, PropertyObserverFlag.None);
            if (isAutoActivate)
            {
                observer.Activate(true);
            }

            return observer;
        }
    }
}