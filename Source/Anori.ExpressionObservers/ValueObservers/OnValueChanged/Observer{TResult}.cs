// -----------------------------------------------------------------------
// <copyright file="Observer{TResult}.cs" company="AnoriSoft">
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
    ///     cref="Observer{TParameter1,TParameter2,TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ObserverFoundationBase" />
    internal sealed class Observer<TResult> :
        ObserverOnValueChangedBase<INotifyValuePropertyObserver<TResult>, TResult>,
        INotifyValuePropertyObserver<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult?> getter;

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
        internal Observer(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            var taskFactory = new TaskFactory(taskScheduler);
            this.UpdateValueProperty = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.UpdateValueField = () => this.value = get();
            this.getter = this.CreateGetPropertyNullableValue(() => this.value);
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
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.UpdateValueProperty = () => synchronizationContext.Send(() => this.Value = get());
            this.UpdateValueField = () => this.value = get();
            this.getter = this.CreateGetPropertyNullableValue(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Observer{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal Observer([NotNull] Expression<Func<TResult>> propertyExpression, PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree));
            this.UpdateValueProperty = () => this.Value = get();
            this.UpdateValueField = () => this.value = get();
            this.getter = this.CreateGetPropertyNullableValue(() => this.value);
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
            get => this.getter();
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
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateValueGetterByTree<TResult>(propertyExpression.Parameters, tree);
    }
}