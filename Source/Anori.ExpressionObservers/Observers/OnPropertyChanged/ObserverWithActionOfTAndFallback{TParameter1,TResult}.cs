// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionOfTAndFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnPropertyChanged
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionGetters;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionOfTAndFallback<TParameter1, TResult> :
        ObserverBase<IPropertyObserver<TResult>, TParameter1, TResult>,
        IPropertyObserver<TResult>
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionOfTAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action or propertyExpression is null.</exception>
        internal ObserverWithActionOfTAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionOfTAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionOfTAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1), taskScheduler);
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionOfTAndFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionOfTAndFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateGetter(
                Getter(propertyExpression, this.Tree, fallback, parameter1),
                synchronizationContext);
        }

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>The Getter.</returns>
        private static Func<TResult> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback,
            TParameter1 parameter1)
        {
            var get = ExpressionGetter.CreateGetterByTree<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback!);
            return () => get(parameter1);
        }
    }
}