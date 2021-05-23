// -----------------------------------------------------------------------
// <copyright file="ObserverWithAction{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionGetters;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.Base;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithAction<TResult> :
        ObserverOnValueChangedBase<INotifyValuePropertyObserver<TResult>, TResult>,
        INotifyValuePropertyObserver<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The get value.
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
        ///     Initializes a new instance of the <see cref="ObserverWithAction{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithAction(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            var taskFactory = new TaskFactory(taskScheduler);
            this.UpdateValueProperty = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.UpdateValueField = () => taskFactory.StartNew(() => this.value = get()).Wait();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
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
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.UpdateValueProperty = () => synchronizationContext.Send(() => this.Value = get());
            this.UpdateValueField = () => synchronizationContext.Send(() => this.value = get());
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
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
            [NotNull] Action<TResult?, TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.UpdateValueProperty = () => this.Value = get();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

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
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] IExpressionTree tree) =>
            ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, tree);
    }
}