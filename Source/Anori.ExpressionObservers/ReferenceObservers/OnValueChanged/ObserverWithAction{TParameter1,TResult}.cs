// -----------------------------------------------------------------------
// <copyright file="ObserverWithAction{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.ObserverBase{Anori.ExpressionObservers.Interfaces.INotifyReferencePropertyObserver{TResult}, TParameter1, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.INotifyReferencePropertyObserver{TResult}" />
    /// <seealso cref="ObserverWithActionAndChachedGetter{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFundatinBase" />
    internal sealed class ObserverWithAction<TParameter1, TResult> :
        ObserverBase<INotifyReferencePropertyObserver<TResult>, TParameter1, TResult>,
        INotifyReferencePropertyObserver<TResult>
        where TResult : class
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action propertyChangedAction;

        /// <summary>
        ///     The value changed action.
        /// </summary>
        [NotNull]
        private readonly Action valueChangedAction;

        /// <summary>
        /// The silent action.
        /// </summary>
        [NotNull] private readonly Action silentAction;

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.silentAction.Raise();

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithAction(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
            var taskFactory = new TaskFactory(taskScheduler);
            this.propertyChangedAction = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
            this.propertyChangedAction = () => synchronizationContext.Send(() => this.Value = get());
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
            this.propertyChangedAction = () => this.Value = get();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public TResult? Value
        {
#pragma warning disable S4275 // Getters and setters should access the expected fields
            get => this.getValue();
#pragma warning restore S4275 // Getters and setters should access the expected fields
            private set
            {
                if (EqualityComparer<TResult?>.Default.Equals(value, this.value))
                {
                    return;
                }

                this.value = value;
                this.valueChangedAction.Raise();
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.propertyChangedAction();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree) =>
            ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, tree);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}