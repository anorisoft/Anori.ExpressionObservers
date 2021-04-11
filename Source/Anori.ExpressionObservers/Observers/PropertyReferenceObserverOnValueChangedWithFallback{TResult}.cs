// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverOnValueChangedWithFallback{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
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
    using Anori.ExpressionObservers.ReferenceTypeObservers;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal sealed class PropertyReferenceObserverOnValueChangedWithFallback<TResult> :
        PropertyObserverBase<IPropertyReferenceObserverOnValueChanged<TResult>, TResult>,
        IPropertyReferenceObserverOnValueChanged<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private readonly Action action;

        /// <summary>
        ///     The getter.
        /// </summary>
        private readonly Func<TResult?> getValue;

        /// <summary>
        ///     The value.
        /// </summary>
        private TResult? value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverOnValueChangedWithFallback{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyReferenceObserverOnValueChangedWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree, fallback));
            var taskFactory = new TaskFactory(taskScheduler);
            this.action = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverOnValueChangedWithFallback{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyReferenceObserverOnValueChangedWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree, fallback));
            this.action = () => synchronizationContext.Send(() => this.Value = get());
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverOnValueChangedWithFallback{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyReferenceObserverOnValueChangedWithFallback(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            var get = this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree, fallback));
            this.action = () => this.Value = get();
            this.getValue = this.CreateGetPropertyNullableReference(() => this.value);
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
        public TResult? Value
        {
            get => this.getValue();
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
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>
        ///     The Getter.
        /// </returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree, TResult fallback) =>
            ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree, fallback);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}