// -----------------------------------------------------------------------
// <copyright file="Observer{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueObservers.OnValueChanged
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionGetters;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.Base;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class Observer<TParameter1, TParameter2, TResult> :
        ObserverOnValueChangedBase<INotifyValuePropertyObserver<TResult>, TParameter1, TParameter2, TResult>,
        INotifyValuePropertyObserver<TResult>
        where TResult : struct
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
    {
        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="Observer{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal Observer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1, parameter2));
            var taskFactory = new TaskFactory(taskScheduler);
            this.UpdateValueProperty = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.UpdateValueField = () => this.value = get();
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="Observer{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal Observer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1, parameter2));
            this.UpdateValueProperty = () => synchronizationContext.Send(() => this.Value = get());
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.UpdateValueField = () => this.value = get();
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = null);
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="Observer{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal Observer(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            var get = this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1, parameter2));
            this.UpdateValueProperty = () => this.Value = get();
            this.getValue = this.CreateGetPropertyNullableValue(() => this.value);
            this.UpdateValueField = () => this.value = get();
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
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1,
            TParameter2 parameter2) =>
            () => ExpressionGetter.CreateValueGetterByTree<TParameter1, TParameter2, TResult>(
                propertyExpression.Parameters,
                tree)(parameter1, parameter2);
    }
}