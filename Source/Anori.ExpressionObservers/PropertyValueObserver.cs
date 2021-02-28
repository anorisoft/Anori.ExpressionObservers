// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserver.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.ValueObservers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Observer.
    /// </summary>
    public static class PropertyValueObserver
    {
        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static PropertyValueObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : struct =>
            new PropertyValueObserver<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static PropertyValueObserverWithGetter<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : struct =>
            new PropertyValueObserverWithGetter<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static PropertyValueObserverWithGetterAndFallback<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            TResult fallback)
            where TResult : struct =>
            new PropertyValueObserverWithGetterAndFallback<TResult>(propertyExpression, action, fallback);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static PropertyValueObserverWithGetterAndFallback<TParameter1, TResult>
            ObservesAndGet<TParameter1, TResult>(
                [NotNull] TParameter1 parameter,
                [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
                [NotNull] Action action,
                TResult fallback)
            where TResult : struct
            where TParameter1 : INotifyPropertyChanged =>
            new PropertyValueObserverWithGetterAndFallback<TParameter1, TResult>(
                parameter,
                propertyExpression,
                action,
                fallback);

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
        public static PropertyValueGetterObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TResult : struct =>
            new PropertyValueGetterObserver<TResult>(propertyExpression, action);

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
        public static PropertyValueObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueObserver<TParameter1, TResult>(parameter1, propertyExpression, action);

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
        public static PropertyValueGetterObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueGetterObserver<TParameter1, TResult>(parameter1, propertyExpression, action);

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
        /// <returns>
        ///     The Property Value Observer.
        /// </returns>
        [NotNull]
        public static PropertyValueObserver<TParameter1, TParameter2, TResult>
            Observes<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueObserver<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action);

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
        /// <returns>The Property Value Observer.</returns>
        [NotNull]
        public static PropertyValueGetterObserver<TParameter1, TParameter2, TResult>
            Observes<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                [NotNull] Action<TResult?> action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : struct =>
            new PropertyValueGetterObserver<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action);
    }
}