// -----------------------------------------------------------------------
// <copyright file="ObserverWithFallback{TResult}.cs" company="AnoriSoft">
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

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.ReferenceObservers.OnPropertyChanged;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="ObserverWithActionAndChachedGetter{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFundatinBase" />
    internal sealed class ObserverWithFallback<TResult> : ObserverBase<INotifyPropertyObserver<TResult>, TResult>,
                                                          INotifyPropertyObserver<TResult>
    {
        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult> getValue;

        /// <summary>
        ///     The propertyChangedAction.
        /// </summary>
        [NotNull]
        private readonly Action propertyChangedAction;

        /// <summary>
        ///     The silent action.
        /// </summary>
        private readonly Action silentAction;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithFallback{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            var taskFactory = new TaskFactory(taskScheduler);
            this.propertyChangedAction = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.silentAction = () => this.value = get();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithFallback{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.propertyChangedAction = () => synchronizationContext.Send(() => this.Value = get());
            this.getValue = this.CreateGetProperty(() => this.value);
            this.silentAction = () => this.value = get();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithFallback{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal ObserverWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.propertyChangedAction = () => this.Value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.silentAction = () => this.value = get();
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

                this.value = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     On the propertyChangedAction.
        /// </summary>
        protected override void OnAction() => this.propertyChangedAction.Raise();

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.silentAction.Raise();

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
            TResult fallback) =>
            ExpressionGetter.CreateGetterByTree(propertyExpression.Parameters, tree, fallback!);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}