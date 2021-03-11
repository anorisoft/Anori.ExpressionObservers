// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserver.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.ReferenceObservers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer.
    /// </summary>
    public static class PropertyReferenceObserver
    {
        /// <summary>
        /// Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Reference Observer.
        /// </returns>
        [NotNull]
        public static PropertyReferenceObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : class =>
            new PropertyReferenceObserver<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static PropertyReferenceObserverWithGetter<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
            where TResult : class =>
            new PropertyReferenceObserverWithGetter<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the and get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        [NotNull]
        public static PropertyReferenceObserverWithGetterAndFallback<TResult> ObservesAndGet<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action,
            TResult fallback)
            where TResult : class =>
            new PropertyReferenceObserverWithGetterAndFallback<TResult>(propertyExpression, action, fallback);

        /// <summary>
        ///     Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static PropertyReferenceGetterObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult> action)
            where TResult : class =>
            new PropertyReferenceGetterObserver<TResult>(propertyExpression, action);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Property Reference Observer.
        /// </returns>
        [NotNull]
        public static PropertyReferenceObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : class =>
            new PropertyReferenceObserver<TParameter1, TResult>(parameter1, propertyExpression, action);

        /// <summary>
        ///     Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static PropertyReferenceGetterObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action)
            where TParameter1 : INotifyPropertyChanged
            where TResult : class =>
            new PropertyReferenceGetterObserver<TParameter1, TResult>(parameter1, propertyExpression, action);

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
        public static PropertyReferenceObserver<TParameter1, TParameter2, TResult>
            Observes<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class =>
            new PropertyReferenceObserver<TParameter1, TParameter2, TResult>(
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
        /// <returns>The Property Reference Observer.</returns>
        [NotNull]
        public static PropertyReferenceGetterObserver<TParameter1, TParameter2, TResult>
            Observes<TParameter1, TParameter2, TResult>(
                [NotNull] TParameter1 parameter1,
                [NotNull] TParameter2 parameter2,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
                [NotNull] Action<TResult> action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
            where TResult : class =>
            new PropertyReferenceGetterObserver<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action);
    }
}