// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndDeferrer{TResult}.cs" company="AnoriSoft">
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

    using Anori.Deferrers;
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
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class ObserverWithActionAndDeferrer<TResult> :
        ObserverOnValueChangedBase<INotifyValuePropertyObserverWithDeferrer<TResult>, TResult>,
        INotifyValuePropertyObserverWithDeferrer<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The deferrer.
        /// </summary>
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult?> getter;

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
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrerrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            var taskFactory = new TaskFactory(taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(() => taskFactory.StartNew(() => this.Value = get()).Wait());
            this.UpdateValueAction = () => this.deferrer.Update();
            this.SilentUpdateValueAction = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.getter = this.CreateGetPropertyNullableValue(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrerrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.deferrer = new UpdateableMultipleDeferrer(() => synchronizationContext.Send(() => this.Value = get()));
            this.UpdateValueAction = () => this.deferrer.Update();
            this.SilentUpdateValueAction = () => synchronizationContext.Send(() => this.value = get());
            this.getter = this.CreateGetPropertyNullableValue(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionAndDeferrerrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = get());
            this.UpdateValueAction = () => this.deferrer.Update();
            this.SilentUpdateValueAction = () => this.value = get();
            this.getter = this.CreateGetPropertyNullableValue(() => this.value);
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
            get => this.getter();
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
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, tree);
    }
}