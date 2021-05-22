// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndFallbackAndDeferrer{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.Base;
        using Anori.ExpressionGetters;using Anori.ExpressionGetters.Tree.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Value Getter Observer.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionAndFallbackAndDeferrer<TParameter1, TResult> :
        ObserverOnValueChangedBase<INotifyPropertyObserverWithDeferrer<TResult>, TParameter1, TResult>,
        INotifyPropertyObserverWithDeferrer<TResult>
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The deferrer.
        /// </summary>
        [NotNull]
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getValue;

        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action<TResult, TResult> valueChangedAction;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult value;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndFallbackAndDeferrer{TParameter1,TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action or propertyExpression is null.</exception>
        internal ObserverWithActionAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult, TResult> action,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.value = fallback;
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1));
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = get());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndFallbackAndDeferrer{TParameter1,TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult, TResult> action,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.value = fallback;
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1));
            var taskFactory = new TaskFactory(taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(() => taskFactory.StartNew(() => this.Value = get()).Wait());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndFallbackAndDeferrer{TParameter1,TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndFallbackAndDeferrer(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            [NotNull] Action<TResult, TResult> action,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            this.value = fallback;
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1));
            this.deferrer = new UpdateableMultipleDeferrer(() => synchronizationContext.Send(() => this.Value = get()));
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public TResult Value
        {
#pragma warning disable S4275 // Getters and setters should access the expected fields
            get => this.getValue();
#pragma warning restore S4275 // Getters and setters should access the expected fields
            private set
            {
                if (EqualityComparer<TResult>.Default.Equals(value, this.value))
                {
                    return;
                }

                var old = this.value;
                this.value = value;
                this.valueChangedAction(old, value);
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
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>The Getter.</returns>
        private static Func<TResult> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback,
            TParameter1 parameter1)
        {
            var get = ExpressionGetter.CreateGetterByTree<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback!);
            return () => get(parameter1);
        }
    }
}