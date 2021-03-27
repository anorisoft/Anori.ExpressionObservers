// -----------------------------------------------------------------------
// <copyright file="PropertyObserver{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Property Observer class.
    /// </summary>
    public static partial class PropertyObserver
    {
        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        public static PropertyObserverWithGetterAndFallback<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                action,
                fallback);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        public static PropertyObserverWithGetterAndFallback<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged
        {
            var observer = new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                action,
                fallback);
            if (autoSubscribe)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyObserver<TParameter1, TResult>(parameter1, propertyExpression, action);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyGetterObserverWithFallback<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged
        {
            var observer = new PropertyGetterObserverWithFallback<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                action,
                fallback);
            if (autoSubscribe)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyGetterObserverWithFallback<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback)
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyGetterObserverWithFallback<TParameter1, TResult>(
                parameter1,
                propertyExpression,
                action,
                fallback);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] this TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
        {
            var observer = new PropertyObserver<TParameter1, TResult>(parameter1, propertyExpression, action);
            if (autoSubscribe)
            {
                observer.Subscribe(true);
            }

            return observer;
        }
    }
}