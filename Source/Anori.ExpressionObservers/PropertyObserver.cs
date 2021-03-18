// -----------------------------------------------------------------------
// <copyright file="PropertyObserver.cs" company="AnoriSoft">
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
    ///     Property Observer.
    /// </summary>
    public static class PropertyObserver
    {
        /// <summary>
        /// Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TResult> Observes<TResult>(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action action)
        => new PropertyObserver<TResult>(propertyExpression, action);

        /// <summary>
        /// Observeses the specified property expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TResult> Observes<TResult>(
           [NotNull] Expression<Func<TResult>> propertyExpression,
           bool autoSubscribe,
           [NotNull] Action action)
        {
            var observer = new PropertyObserver<TResult>(propertyExpression, action);
            if (autoSubscribe)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        /// Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="autoSubscribe">if set to <c>true</c> [automatic subscribe].</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
            [NotNull] TParameter1 parameter1,
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

        /// <summary>
        /// Observeses the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TParameter1, TResult> Observes<TParameter1, TResult>(
           [NotNull] TParameter1 parameter1,
           [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
           [NotNull] Action action)
           where TParameter1 : INotifyPropertyChanged => new PropertyObserver<TParameter1, TResult>(parameter1, propertyExpression, action);

        /// <summary>
        /// Observeses the specified parameter1.
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
        /// The Property Observer.
        /// </returns>
        [NotNull]
        public static PropertyObserver<TParameter1, TParameter2, TResult> Observes<TParameter1, TParameter2, TResult>(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool autoSubscribe,
            [NotNull] Action action)
            where TParameter1 : INotifyPropertyChanged
            where TParameter2 : INotifyPropertyChanged
        {
            var observer = new PropertyObserver<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action);
            if (autoSubscribe)
            {
                observer.Subscribe(true);
            }

            return observer;
        }

        /// <summary>
        /// Observeses the specified parameter1.
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
        public static PropertyObserver<TParameter1, TParameter2, TResult> Observes<TParameter1, TParameter2, TResult>(
         [NotNull] TParameter1 parameter1,
         [NotNull] TParameter2 parameter2,
         [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
         [NotNull] Action action)
         where TParameter1 : INotifyPropertyChanged
         where TParameter2 : INotifyPropertyChanged => new PropertyObserver<TParameter1, TParameter2, TResult>(
                parameter1,
                parameter2,
                propertyExpression,
                action);
    }
}