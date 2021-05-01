// -----------------------------------------------------------------------
// <copyright file="PropertyObserver{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Observer.
    /// </summary>
    public static partial class PropertyObserver
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
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        public static IGetterPropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged =>
            new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                fallback,
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
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        public static IGetterPropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
        {
            var observer = new ObserverWithActionAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                fallback,
                PropertyObserverFlag.None);
            if (autoSubscribe)
            {
                observer.Activate(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static IGetterPropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
        {
            var observer = new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                fallback,
                PropertyObserverFlag.None);
            if (autoSubscribe)
            {
                observer.Activate(true);
            }

            return observer;
        }

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
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static IGetterPropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged =>
            new ObserverWithActionOfTAndGetterAndFallback<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                fallback,
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
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static IPropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
        {
            var observer = new ObserverWithAction<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                PropertyObserverFlag.None);
            if (autoSubscribe)
            {
                observer.Activate(true);
            }

            return observer;
        }

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
        /// <returns>Property Observer.</returns>
        [NotNull]
        public static IPropertyObserver<TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged =>
            new ObserverWithAction<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action,
                PropertyObserverFlag.None);
    }
}