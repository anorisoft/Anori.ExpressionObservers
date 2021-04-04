// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverOnValueChanged{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
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

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyValueObserverOnValueChanged{TResult}" />
    /// <seealso cref="PropertyValueObserverOnValueChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyValueObserverOnValueChanged<TParameter1, TResult> :
        PropertyObserverBase<PropertyValueObserverOnValueChanged<TParameter1, TResult>, TParameter1, TResult>,
        IPropertyValueObserverOnValueChanged<TResult>
        where TResult : struct
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverOnValueChanged{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyValueObserverOnValueChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler)
            : base(parameter1, propertyExpression)
        {
            TResult? Getter() =>
                ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, this.Tree)(
                    parameter1);

            this.action = () => new TaskFactory(taskScheduler).StartNew(() => this.Value = Getter()).Wait();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverOnValueChanged{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        internal PropertyValueObserverOnValueChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext)
            : base(parameter1, propertyExpression)
        {
            TResult? Getter() =>
                ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, this.Tree)(
                    parameter1);

            this.action = () => synchronizationContext.Send(() => this.Value = Getter());
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverOnValueChanged{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        internal PropertyValueObserverOnValueChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression)
            : base(parameter1, propertyExpression)
        {
            TResult? Getter() =>
                ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, this.Tree)(
                    parameter1);

            this.action = () => this.Value = Getter();
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
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        TResult? IPropertyValueObserverOnValueChanged<TResult>.Value => this.Value;

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

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult>
            IPropertyObserverBase<IPropertyValueObserverOnValueChanged<TResult>>.Subscribe() =>
            this.Subscribe();

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        /// <returns>
        ///     Self object.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult>
            IPropertyObserverBase<IPropertyValueObserverOnValueChanged<TResult>>.Subscribe(bool silent) =>
            this.Subscribe(silent);

        /// <summary>
        ///     Unsubscribes this instance.
        /// </summary>
        /// <returns>
        ///     Self object.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult>
            IPropertyObserverBase<IPropertyValueObserverOnValueChanged<TResult>>.Unsubscribe() =>
            this.Unsubscribe();
    }
}