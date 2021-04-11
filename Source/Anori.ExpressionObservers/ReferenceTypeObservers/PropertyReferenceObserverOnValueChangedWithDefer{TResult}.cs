// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverOnValueChangedWithDefer{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyReferenceObserverOnValueChangedWithDefer{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal sealed class PropertyReferenceObserverOnValueChangedWithDefer<TResult> :
        PropertyObserverBase<PropertyReferenceObserverOnValueChangedWithDefer<TResult>, TResult>,
        INotifyPropertyChanged
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     The defer state.
        /// </summary>
        private DeferState deferState;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyReferenceObserverOnValueChangedWithDefer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyReferenceObserverOnValueChangedWithDefer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            this.getter = ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, this.Tree);

            if (taskScheduler == null)
            {
                this.action = () =>
                    {
                        switch (this.deferState)
                        {
                            case DeferState.Update:
                                return;

                            case DeferState.Deferred:
                                this.deferState = DeferState.Update;
                                return;

                            default:
                                this.Value = this.getter();
                                break;
                        }
                    };
            }
            else
            {
                this.action = () =>
                    {
                        switch (this.deferState)
                        {
                            case DeferState.Update:
                                return;

                            case DeferState.Deferred:
                                this.deferState = DeferState.Update;
                                return;

                            default:
                                new TaskFactory(taskScheduler).StartNew(() => { return this.Value = this.getter(); })
                                    .Wait();
                                break;
                        }
                    };
            }
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
        ///     Gets a value indicating whether this instance is defer.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is defer; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefer => this.deferState != DeferState.NotDeferred;

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>The deferrer.</returns>
        public IDisposable Defer() =>
            new Deferrer(
                () => this.deferState = DeferState.Deferred,
                () =>
                    {
                        if (this.deferState == DeferState.Update)
                        {
                            this.Value = this.getter();
                        }

                        this.deferState = DeferState.NotDeferred;
                    });

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
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}