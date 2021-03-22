// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverOnValueChanged{TResult} - Copy.cs" company="AnoriSoft">
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
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    /// Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.ValueTypeObservers.PropertyValueObserverOnValueChanged{TParameter1, TParameter2, TResult}, TParameter1, TParameter2, TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyValueObserverOnValueChanged<TParameter1, TParameter2, TResult> :
        PropertyObserverBase<PropertyValueObserverOnValueChanged<TParameter1, TParameter2, TResult>, TParameter1, TParameter2, TResult>,
        INotifyPropertyChanged
        where TResult : struct
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
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
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnValueChanged{TParameter1,TParameter2,  TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyValueObserverOnValueChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            TaskScheduler? taskScheduler = null)
            : base(parameter1, parameter2, propertyExpression)
        {
            TResult? Getter() => ExpressionGetter.CreateValueGetter<TParameter1, TParameter2, TResult>(propertyExpression.Parameters, this.Tree)(parameter1, parameter2);

            if (taskScheduler == null)
            {
                this.action = () => this.Value = Getter();
            }
            else
            {
                this.action = () => new TaskFactory(taskScheduler).StartNew(() => this.Value = Getter()).Wait();
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