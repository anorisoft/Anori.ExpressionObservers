﻿// -----------------------------------------------------------------------
// <copyright file="ObserverWithFallbackAndDeferrer{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.Base;
        using Anori.ExpressionGetters;using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithFallbackAndDeferrer<TResult> :
        ObserverOnValueChangedBase<INotifyPropertyObserverWithDeferrer<TResult>, TResult>,
        INotifyPropertyObserverWithDeferrer<TResult>
    {
        /// <summary>
        ///     The deferrer.
        /// </summary>
        [NotNull]
        private readonly UpdateableMultipleDeferrer deferrer;

        /// <summary>
        ///     The get value.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getValue;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithFallbackAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression if null.</exception>
        internal ObserverWithFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = get());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithFallbackAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TResult fallback,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
            this.deferrer = new UpdateableMultipleDeferrer(
                () => new TaskFactory(taskScheduler).StartNew(() => this.Value = get()).Wait());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithFallbackAndDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithFallbackAndDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TResult fallback,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.value = fallback;
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var get = this.CreateGetter(Getter(propertyExpression, this.Tree, fallback));
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
        ///     Defers this instance.
        /// </summary>
        /// <returns>The deferrer.</returns>
        public IDisposable Defer() => this.deferrer.Create();

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
    }
}