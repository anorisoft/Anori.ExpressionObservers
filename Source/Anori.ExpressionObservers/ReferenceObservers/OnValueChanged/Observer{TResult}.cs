﻿// -----------------------------------------------------------------------
// <copyright file="Observer{TResult}.cs" company="AnoriSoft">
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

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="CachedObserver{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class Observer<TResult> :
        ObserverOnValueChangedBase<INotifyReferencePropertyObserver<TResult>, TResult>,
        INotifyReferencePropertyObserver<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Observer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal Observer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
            var taskFactory = new TaskFactory(taskScheduler);
            this.UpdateValueProperty = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Observer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal Observer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
            this.UpdateValueProperty = () => synchronizationContext.Send(() => this.Value = get());
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Observer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal Observer([NotNull] Expression<Func<TResult>> propertyExpression, PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree));
            this.UpdateValueProperty = () => this.Value = get();
            this.UpdateValueField = () => this.value = get();
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
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, tree);
    }
}