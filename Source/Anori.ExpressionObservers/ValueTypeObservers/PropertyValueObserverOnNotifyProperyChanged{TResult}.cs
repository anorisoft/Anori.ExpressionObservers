// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverOnNotifyProperyChanged{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using Anori.Common;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions.Threading;
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    internal sealed class PropertyValueObserverOnNotifyProperyChanged<TResult> :
        PropertyObserverBase<IPropertyValueObserverOnNotifyProperyChanged<TResult>, TResult>,
        IPropertyValueObserverOnNotifyProperyChanged<TResult>
        where TResult : struct
    {
        /// <summary>
        ///     The action.
        /// </summary>
        [NotNull]
        private Action action;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private Func<TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, taskScheduler, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" />
        ///     class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            TResult? Get() =>
                new TaskFactory<TResult?>(taskScheduler).StartNew(this.Getter(propertyExpression, this.Tree)).Result;

            this.SetGetterFunctions(isCached, safetyMode, Get);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, synchronizationContext, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            TResult? Get() => synchronizationContext.Send(this.Getter(propertyExpression, this.Tree));
            this.SetGetterFunctions(isCached, safetyMode, Get);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag propertyObserverFlag)
            : this(propertyExpression, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            Func<TResult?> get = this.Getter(propertyExpression, this.Tree);
            this.SetGetterFunctions(isCached, safetyMode, get);
        }

        private void SetGetterFunctions(bool isCached, LazyThreadSafetyMode safetyMode, Func<TResult?> get)
        {
            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(get, safetyMode);
                this.action = () =>
                    {
                        cache.Reset();
                        this.OnPropertyChanged(nameof(this.Value));
                    };
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    this.getter = () => this.IsActive ? cache.Value : throw new NotActivatedException();
                }
                else
                {
                    this.getter = () => cache.Value;
                }
            }
            else
            {
                this.action = () => this.OnPropertyChanged(nameof(this.Value));
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    this.getter = () => this.IsActive ? get() : throw new NotActivatedException();
                }
                else
                {
                    this.getter = get;
                }
            }
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <returns>The result value.</returns>
        public TResult? Value => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>Getter.</returns>
        private Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree)
        {
            var get = ExpressionGetter.CreateValueGetter<TResult>(propertyExpression.Parameters, tree);
            if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
            {
                return () => this.IsActive ? get() : throw new NotActivatedException();
            }

            return get;
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}