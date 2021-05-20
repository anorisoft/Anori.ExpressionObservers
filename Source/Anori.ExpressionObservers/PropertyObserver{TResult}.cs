// -----------------------------------------------------------------------
// <copyright file="PropertyObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.OnPropertyChanged;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Property Observer class.
    /// </summary>
    public static partial class PropertyObserver
    {
        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        [NotNull]
        public static IPropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action) =>
            new ObserverWithAction<TResult>(propertyExpression, action, PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        [NotNull]
        public static IPropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action)
        {
            var observer = new ObserverWithAction<TResult>(propertyExpression, action, PropertyObserverFlag.None);
            if (autoSubscribe)
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
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        [NotNull]
        public static IGetterPropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action,
            [NotNull] TResult fallback)
        {
            var observer = new ObserverWithActionAndGetterAndFallback<TResult>(
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
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        [NotNull]
        public static IGetterPropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TResult fallback) =>
            new ObserverWithActionAndGetterAndFallback<TResult>(
                propertyExpression,
                action,
                fallback,
                PropertyObserverFlag.None);

        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        [NotNull]
        public static IGetterPropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback)
        {
            var observer = new ObserverWithActionOfTAndGetterAndFallback<TResult>(
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
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The property observer.
        /// </returns>
        [NotNull]
        public static IGetterPropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback) =>
            new ObserverWithActionOfTAndGetterAndFallback<TResult>(
                propertyExpression,
                action,
                fallback,
                PropertyObserverFlag.None);
    }
}