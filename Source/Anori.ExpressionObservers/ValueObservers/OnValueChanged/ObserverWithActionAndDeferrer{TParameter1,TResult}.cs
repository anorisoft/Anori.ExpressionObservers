﻿// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndDeferrer{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionAndDeferrer<TParameter1, TResult> :
        ObserverOnValueChangedBase<INotifyValuePropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        INotifyValuePropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        ///     The deferrer.
        /// </summary>
        [NotNull]
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The getValue.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     The value changed action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult?, TResult?> valueChangedAction;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1));
            var taskFactory = new TaskFactory(taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(() => taskFactory.StartNew(() => this.Value = get()).Wait());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1));
            this.deferrer = new UpdateableMultipleDeferrer(() => synchronizationContext.Send(() => this.Value = get()));
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => synchronizationContext.Send(() => this.value = get());
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrer{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1));
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = get());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is defer.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is defer; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeferred => this.deferrer.IsDeferred;

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

                var old = this.value;
                this.value = value;
                this.valueChangedAction.Raise(old, value);
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1) =>
            () => ExpressionGetter.CreateValueGetterByTree<TParameter1, TResult>(propertyExpression.Parameters, tree)(
                parameter1);
    }
}