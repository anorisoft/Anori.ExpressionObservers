// -----------------------------------------------------------------------
// <copyright file="ObserverWithDeferrer{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Deferrers;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.Base;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="ObserverWithDeferrer{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class ObserverWithDeferrer<TResult> :
        ObserverOnValueChangedBase<INotifyReferencePropertyObserverWithDeferrer<TResult>, TResult>,
        INotifyReferencePropertyObserverWithDeferrer<TResult>
        where TResult : class
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
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateReferenceGetterByTree<TResult>(
                propertyExpression.Parameters,
                this.Tree);
            this.deferrer = new UpdateableMultipleDeferrer(() => this.Value = getter());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = getter();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);

        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateReferenceGetterByTree<TResult>(
                propertyExpression.Parameters,
                this.Tree);
            this.deferrer = new UpdateableMultipleDeferrer(
                () => new TaskFactory(taskScheduler).StartNew(() => this.Value = getter()).Wait());
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = getter();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);

        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithDeferrer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithDeferrer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var getter = ExpressionGetter.CreateReferenceGetterByTree<TResult>(
                propertyExpression.Parameters,
                this.Tree);
            this.deferrer = new UpdateableMultipleDeferrer(
                () => synchronizationContext.Send(() => this.Value = getter()));
            this.UpdateValueProperty = () => this.deferrer.Update();
            this.UpdateValueField = () => this.value = getter();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
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
    }
}