// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverOnValueChanged{TResult}.cs" company="AnoriSoft">
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
    using Anori.ExpressionObservers.Tree;
    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyValueObserverOnValueChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyValueObserverOnValueChanged<TResult> :
        PropertyObserverBase<PropertyValueObserverOnValueChanged<TResult>>,
        INotifyPropertyChanged
        where TResult : struct
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
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnValueChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyValueObserverOnValueChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler? taskScheduler = null)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            this.ExpressionString = propertyExpression.ToString();

            this.CreateChain(tree);
            var getter = ExpressionGetter.CreateValueGetter<TResult>(propertyExpression.Parameters, tree);

            if (taskScheduler == null)
            {
                this.action = () => this.Value = getter();
            }
            else
            {
                this.action = () => new TaskFactory(taskScheduler).StartNew(() => this.Value = getter()).Wait();
            }
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public override string ExpressionString { get; }

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
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}