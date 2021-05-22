// -----------------------------------------------------------------------
// <copyright file="ObserverWithFallback{TResult}.cs" company="AnoriSoft">
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

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers.Base;
        using Anori.ExpressionGetters;using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithFallback<TResult> :
        ObserverOnValueChangedBase<INotifyPropertyObserver<TResult>, TResult>,
        INotifyPropertyObserver<TResult>
    {
        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult> getValue;

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
            this.UpdateValueProperty = () => taskFactory.StartNew(() => this.Value = get()).Wait();
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
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
            this.UpdateValueProperty = () => synchronizationContext.Send(() => this.Value = get());
            this.UpdateValueField = () => this.value = get();
            this.getValue = this.CreateGetProperty(() => this.value);
            this.ResetValueProperty = this.CreateValueResetter(() => this.Value = fallback);
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
            this.UpdateValueProperty = () => this.Value = get();
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