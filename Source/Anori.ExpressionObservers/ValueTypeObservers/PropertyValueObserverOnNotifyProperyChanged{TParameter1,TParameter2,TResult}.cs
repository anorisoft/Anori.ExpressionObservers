﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverOnNotifyProperyChanged{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ValueTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyValueObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="INotifyPropertyChanged" />
    internal sealed class PropertyValueObserverOnNotifyProperyChanged<TParameter1, TParameter2, TResult> :
        PropertyObserverBase<IPropertyValueObserverOnNotifyProperyChanged<TResult>, TParameter1, TParameter2, TResult>,
        IPropertyValueObserverOnNotifyProperyChanged<TResult>
        where TResult : struct
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
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
        ///     Initializes a new instance of the
        ///     <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                parameter2,
                propertyExpression,
                taskScheduler,
                true,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableValueCachedGetter(
                this.CreateNullableValueGetter(
                    Getter(propertyExpression, this.Tree, parameter1, parameter2),
                    taskScheduler),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                parameter2,
                propertyExpression,
                synchronizationContext,
                true,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableValueCachedGetter(
                this.CreateNullableValueGetter(
                    Getter(propertyExpression, this.Tree, parameter1, parameter2),
                    synchronizationContext),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, parameter2, propertyExpression, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}" />
        ///     class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableValueCachedGetter(
                this.CreateNullableValueGetter(Getter(propertyExpression, this.Tree, parameter1, parameter2)),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
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
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1,
            TParameter2 parameter2)
        {
            var get = ExpressionGetter.CreateValueGetter<TParameter1, TParameter2, TResult>(
                propertyExpression.Parameters,
                tree);
            return () => get(parameter1, parameter2);
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