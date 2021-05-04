﻿// -----------------------------------------------------------------------
// <copyright file="ObserverWithDeferWithFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="INotifyPropertyObserverWithDeferrer{TResult}" />
    /// <seealso cref="INotifyPropertyObserverWithDeferrer{TResult}" />
    internal sealed class ObserverWithDeferWithFallback<TParameter1, TResult> :
        ObserverBase<INotifyPropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        INotifyPropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The propertyChangedAction.
        /// </summary>
        [NotNull]
        private readonly Action propertyChangedAction;

        /// <summary>
        ///     The deferrer.
        /// </summary>
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The silent action.
        /// </summary>
        private readonly Action silentAction;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult value;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithDeferWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDeferWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.value = fallback;
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, this.Tree, fallback);
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = getter());
            this.propertyChangedAction = () => this.deferrer.Update();
            this.silentAction = () => this.value = getter();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithDeferWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDeferWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] TResult fallback,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.value = fallback;
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, this.Tree, fallback);
            this.deferrer = new UpdateableMultipleDeferrer(
                () => new TaskFactory(taskScheduler).StartNew(() => this.Value = getter()).Wait());
            this.propertyChangedAction = () => this.deferrer.Update();
            this.silentAction = () => this.value = getter();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithDeferWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDeferWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] TResult fallback,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.value = fallback;
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, this.Tree, fallback);
            this.deferrer = new UpdateableMultipleDeferrer(
                () => synchronizationContext.Send(() => this.Value = getter()));
            this.propertyChangedAction = () => this.deferrer.Update();
            this.silentAction = () => this.value = getter();
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
        public TResult Value
        {
            get => this.value;
            private set
            {
                if (EqualityComparer<TResult?>.Default.Equals(value, this.value))
                {
                    return;
                }

                this.value = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeferred => this.deferrer.IsDeferred;

        /// <summary>
        ///     Gets a value indicating whether this instance is defer.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is defer; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefer => this.deferrer.IsDeferred;

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>The deferrer.</returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     On the propertyChangedAction.
        /// </summary>
        protected override void OnAction() => this.propertyChangedAction.Raise();

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.silentAction.Raise();

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}