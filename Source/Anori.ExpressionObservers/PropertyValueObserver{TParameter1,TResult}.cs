// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserver{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

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
        public static IGetterValuePropertyObserver<TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new ValueObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                action,
                PropertyObserverFlag.None);

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
        public static IGetterValuePropertyObserver<TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var observer = new ValueObservers.OnPropertyChanged.ObserverWithAction<TParameter1, TResult>(
                parameter1,
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static IGetterValuePropertyObserver<TResult> ObservesAndGet<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged =>
            new ObserverWithActionAndGetter<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                action,
                PropertyObserverFlag.None);

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
        public static IGetterValuePropertyObserver<TResult> ObservesAndGet<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isAutoActivate,
            [NotNull] Action action)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged
        {
            var observer = new ObserverWithActionAndGetter<TParameter1, TResult>(
                parameter1,
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
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new Observer<TParameter1, TResult>(parameter1, propertyExpression, PropertyObserverFlag.None);

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
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isAutoActivate)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var observer = new Observer<TParameter1, TResult>(
                parameter1,
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new Observer<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                taskScheduler,
                PropertyObserverFlag.None);

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
        public static INotifyValuePropertyObserver<TResult> ObservesOnValueChanged<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            bool isAutoActivate)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct
        {
            var observer = new Observer<TParameter1, TResult>(
                parameter1,
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