// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverOnValueChangedWithDefer{TParameter1,TResult}.cs" company="AnoriSoft">
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
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="INotifyReferencePropertyObserverWithDeferrer{TResult}" />
    /// <seealso cref="INotifyReferencePropertyObserverWithDeferrer{TResult}" />
    /// <seealso cref="ObserverWithDefer{TParameter1,TParameter2,TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFundatinBase" />
    internal sealed class ObserverWithDefer<TParameter1, TResult> :
        ObserverBase<INotifyReferencePropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        INotifyReferencePropertyObserverWithDeferrer<TResult>
        where TResult : class
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The deferrer.
        /// </summary>
        private readonly UpdateableMultibleDeferrer deferrer;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithDefer{TParameter1,TParameter2,TResult}" /> class.
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
            var getter = ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
            this.deferrer = new UpdateableMultibleDeferrer(() => this.Value = getter());
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithDefer{TParameter1,TParameter2,TResult}" /> class.
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
            var getter = ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
            this.deferrer = new UpdateableMultibleDeferrer(
                () => new TaskFactory(taskScheduler).StartNew(() => this.Value = getter()).Wait());
            this.action = () => this.deferrer.Update();
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithDefer{TParameter1,TParameter2,TResult}" /> class.
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
            var getter = ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, this.Tree);
            this.deferrer = new UpdateableMultibleDeferrer(
                () => synchronizationContext.Send(() => this.Value = getter()));
            this.action = () => this.deferrer.Update();
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
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}