// -----------------------------------------------------------------------
// <copyright file="ObserverWithAction{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers.OnValueChanged
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
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Observer{TParameter1,TParameter2,TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFundatinBase" />
    internal sealed class ObserverWithAction<TResult> : ObserverBase<INotifyValuePropertyObserver<TResult>, TResult>,
                                                        INotifyValuePropertyObserver<TResult>
        where TResult : struct
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
        /// The silent action.
        /// </summary>
        [NotNull] private readonly Action silentAction;

        /// <summary>
        ///     The value changed action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult?> valueChangedAction;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            var taskFactory = new TaskFactory(taskScheduler);
            this.propertyChangedAction = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.silentAction = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.propertyChangedAction = () => synchronizationContext.Send(() => this.Value = get());
            this.silentAction = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.propertyChangedAction = () => this.Value = get();
            this.silentAction = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public TResult? Value
        {
#pragma warning disable S4275 // Getters and setters should access the expected fields
            get => this.getValue();
#pragma warning restore S4275 // Getters and setters should access the expected fields
            set
            {
                if (EqualityComparer<TResult?>.Default.Equals(value, this.value))
                {
                    return;
                }

                this.value = value;
                this.valueChangedAction.Raise(value);
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult? INotifyValuePropertyObserver<TResult>.Value => this.Value;

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.propertyChangedAction.Raise();

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.silentAction.Raise();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, tree);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}