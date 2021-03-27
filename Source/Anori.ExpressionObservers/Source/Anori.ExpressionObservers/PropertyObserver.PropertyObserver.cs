﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserver.PropertyObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    public static partial class PropertyObserver
    {
        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserverWithGetterAndFallback<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action,
            [NotNull] TResult fallback)
        {
            var observer = new PropertyObserverWithGetterAndFallback<TResult>(propertyExpression, action, fallback);
            if (autoSubscribe)
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
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserverWithGetterAndFallback<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TResult fallback) =>
            new PropertyObserverWithGetterAndFallback<TResult>(propertyExpression, action, fallback);
        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyGetterObserverWithFallback<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback)
        {
            var observer = new PropertyGetterObserverWithFallback<TResult>(propertyExpression, action, fallback);
            if (autoSubscribe)
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
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyGetterObserverWithFallback<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback) =>
            new PropertyGetterObserverWithFallback<TResult>(propertyExpression, action, fallback);
    }
}