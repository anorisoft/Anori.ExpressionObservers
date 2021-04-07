// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceGetterObserver{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase{TSelf,TResult}" />
    internal sealed class PropertyReferenceObserver<TParameter1, TResult> : PropertyObserverBase<
        IPropertyReferenceObserver<TResult>, TParameter1, TResult>, IPropertyReferenceObserver<TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult?> action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="System.ArgumentNullException">The action is null.</exception>
        internal PropertyReferenceObserver(
          [NotNull] TParameter1 parameter1,
          [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
          [NotNull] Action<TResult?> action)
          : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = Getter(propertyExpression, this.Tree, parameter1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceObserver{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="ArgumentNullException">action</exception>
        internal PropertyReferenceObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            TaskScheduler taskScheduler)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, parameter1);
            var taskFactory = new TaskFactory(taskScheduler);
            this.getter = () => taskFactory.StartNew(get).Result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceObserver{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <exception cref="ArgumentNullException">action</exception>
        internal PropertyReferenceObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            SynchronizationContext synchronizationContext)
            : base(parameter1, propertyExpression)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            var get = Getter(propertyExpression, this.Tree, parameter1);
            this.getter = () => synchronizationContext.Send(get);
        }

        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1) =>
            () => ExpressionGetter.CreateReferenceGetter<TParameter1, TResult>(propertyExpression.Parameters, tree)(
                parameter1);

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? Value => this.getter();

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.action(this.getter());
    }
}