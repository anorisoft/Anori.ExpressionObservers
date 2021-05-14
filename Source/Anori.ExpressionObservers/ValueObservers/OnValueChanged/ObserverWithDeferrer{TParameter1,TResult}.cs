// -----------------------------------------------------------------------
// <copyright file="ObserverWithDeferrer{TParameter1,TResult}.cs" company="AnoriSoft">
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
    /// <seealso cref="INotifyValuePropertyObserverWithDeferrer{TResult}" />
    internal sealed class ObserverWithDefer<TParameter1, TResult> :
        ObserverBase<INotifyValuePropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        INotifyValuePropertyObserverWithDeferrer<TResult>
        where TResult : struct
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The deferrer.
        /// </summary>
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The propertyChangedAction.
        /// </summary>
        [NotNull]
        private readonly Action propertyChangedAction;

        /// <summary>
        ///     The silent action.
        /// </summary>
        [NotNull]
        private readonly Action silentAction;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithDeferrer{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDefer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = getter());
            this.propertyChangedAction = () => this.deferrer.Update();
            this.silentAction = () => this.value = getter();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithDeferrer{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDefer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
            this.deferrer = new UpdateableMultipleDeferrer(
                () => new TaskFactory(taskScheduler).StartNew(() => this.Value = getter()).Wait());
            this.propertyChangedAction = () => this.deferrer.Update();
            this.silentAction = () => this.value = getter();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithDeferrer{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDefer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
            this.deferrer = new UpdateableMultipleDeferrer(
                () => synchronizationContext.Send(() => this.Value = getter()));
            this.propertyChangedAction = () => this.deferrer.Update();
            this.silentAction = () => this.value = getter();
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is defer.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is defer; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefer => this.deferrer.IsDeferred;

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