// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionOfTAndFallbackAndDeferrer{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
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

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionOfTAndFallbackAndDeferrer<TParameter1, TParameter2, TResult> :
        ObserverBase<IPropertyObserverWithDeferrer<TResult>, TParameter1, TParameter2, TResult>,
        IPropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The deferrer.
        /// </summary>
        [NotNull]
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The getValue.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getValue;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionOfTAndFallbackAndDeferrer{TParameter1,TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action or propertyExpression is null.</exception>
        internal ObserverWithActionOfTAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            this.getValue = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1, parameter2));
            this.deferrer = new UpdateableMultipleDeferrer(() => action(this.getValue()));
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionOfTAndFallbackAndDeferrer{TParameter1, TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionOfTAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            this.getValue = this.CreateGetter(
                Getter(propertyExpression, this.Tree, fallback, parameter1, parameter2),
                taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(() => action(this.getValue()));
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionOfTAndFallbackAndDeferrer{TParameter1,TParameter2,  TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionOfTAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] Action<TResult> action,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            this.getValue = this.CreateGetter(
                Getter(propertyExpression, this.Tree, fallback, parameter1, parameter2),
                synchronizationContext);
            this.deferrer = new UpdateableMultipleDeferrer(() => action(this.getValue()));
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeferred => this.deferrer.IsDeferred;

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        private static Func<TResult> Getter(
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback,
            TParameter1 parameter1,
            TParameter2 parameter2)
        {
            var get = ExpressionGetter.CreateGetterByTree<TParameter1, TParameter2, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback!);
            return () => get(parameter1, parameter2);
        }
    }
}