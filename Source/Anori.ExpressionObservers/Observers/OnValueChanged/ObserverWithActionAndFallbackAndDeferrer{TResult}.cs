// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionAndFallbackAndDeferrer{TResult}.cs" company="AnoriSoft">
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
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Observer With Action And Fallback class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="ObserverBase{ObserverWithActionAndFallbackAndDeferrer{TResult}, TResult}" />
    /// <seealso cref="INotifyPropertyObserver{TResult}" />
    internal sealed class ObserverWithActionAndFallbackAndDeferrer<TResult> :
        ObserverBase<INotifyPropertyObserverWithDeferrer<TResult>, TResult>,
        INotifyPropertyObserverWithDeferrer<TResult>
    {
        /// <summary>
        ///     The deferrer.
        /// </summary>
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult> getValue;

        /// <summary>
        ///     The reset value property.
        /// </summary>
        private readonly Action resetValueProperty;

        /// <summary>
        ///     The silent action.
        /// </summary>
        private readonly Action updateValueField;

        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action updateValueProperty;

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
        ///     <see cref="ObserverWithActionAndFallbackAndDeferrer{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithActionAndFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult, TResult> action,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            var taskFactory = new TaskFactory(taskScheduler);
            this.deferrer = new UpdateableMultipleDeferrer(() => taskFactory.StartNew(() => this.Value = get()).Wait());
            this.updateValueProperty = () => this.deferrer.Update();
            this.updateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.resetValueProperty = () => this.Value = fallback;
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndFallbackAndDeferrer{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult, TResult> action,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.deferrer = new UpdateableMultipleDeferrer(() => synchronizationContext.Send(() => this.Value = get()));
            this.updateValueProperty = () => this.deferrer.Update();
            this.updateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.resetValueProperty = () => this.Value = fallback;
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ObserverWithActionAndFallbackAndDeferrer{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The action.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">action is null.</exception>
        internal ObserverWithActionAndFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult, TResult> action,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = get());
            this.updateValueProperty = () => this.deferrer.Update();
            this.updateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.resetValueProperty = () => this.Value = fallback;
        }

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     Disposable deferrer.
        /// </returns>
        public IDisposable Defer() => this.deferrer.Create();

        /// <summary>
        ///     Gets a value indicating whether this instance is deferred.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deferred; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeferred => this.deferrer.IsDeferred;

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
        ///     On the action.
        /// </summary>
        protected override void OnAction()
        {
            if (!this.IsActive)
            {
                return;
            }

            this.updateValueProperty.Raise();
        }

        /// <summary>
        ///     Called when [activate].
        /// </summary>
        /// <param name="silent"></param>
        protected override void OnActivate(bool silent)
        {
            if (!silent)
            {
                this.updateValueProperty.Raise();
            }
            else
            {
                this.updateValueField.Raise();
            }
        }

        /// <summary>
        ///     Called when [deactivate].
        /// </summary>
        protected override void OnDeactivate() => this.resetValueProperty.Raise();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        private static Func<TResult> Getter(
            Expression<Func<TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback)
        {
            var get = ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, tree, fallback!);
            return () => get();
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}