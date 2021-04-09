﻿// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverOnNotifyProperyChanged{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.Extensions.Threading;

    using JetBrains.Annotations;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverBase" />
    internal sealed class PropertyReferenceObserverOnNotifyProperyChanged<TResult> :
        PropertyObserverBase<IPropertyReferenceObserverOnNotifyProperyChanged<TResult>, TResult>,
        IPropertyReferenceObserverOnNotifyProperyChanged<TResult>
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
        [NotNull]
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyReferenceObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            bool isCached = false,
            LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None)
            : base(propertyExpression)
        {
            TResult? Get() =>
                new TaskFactory<TResult?>(taskScheduler).StartNew(Getter(propertyExpression, this.Tree)).Result;

            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(Get, safetyMode);
                this.action = () =>
                    {
                        cache.Reset();
                        this.OnPropertyChanged(nameof(this.Value));
                    };
                this.getter = () => cache.Value;
            }
            else
            {
                this.action = () => this.OnPropertyChanged(nameof(this.Value));
                this.getter = Get;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        internal PropertyReferenceObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            bool isCached = false,
            LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None)
            : base(propertyExpression)
        {
            TResult? Get() => synchronizationContext.Send(Getter(propertyExpression, this.Tree));

            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(Get, safetyMode);
                this.action = () =>
                    {
                        cache.Reset();
                        this.OnPropertyChanged(nameof(this.Value));
                    };
                this.getter = () => cache.Value;
            }
            else
            {
                this.action = () => this.OnPropertyChanged(nameof(this.Value));
                this.getter = Get;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        internal PropertyReferenceObserverOnNotifyProperyChanged(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            bool isCached = false,
            LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None)
            : base(propertyExpression)
        {
            Func<TResult?> get = Getter(propertyExpression, this.Tree);

            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(get, safetyMode);
                this.action = () =>
                    {
                        cache.Reset();
                        this.OnPropertyChanged(nameof(this.Value));
                    };
                this.getter = () => cache.Value;
            }
            else
            {
                this.action = () => this.OnPropertyChanged(nameof(this.Value));
                this.getter = get;
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
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}