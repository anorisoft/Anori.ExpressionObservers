// -----------------------------------------------------------------------
// <copyright file="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
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
    using Anori.Extensions;

    using JetBrains.Annotations;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    /// <summary>
    ///     The Property Observer On Notify Propery Changed With Fallback class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverOnNotifyProperyChanged{TResult}, TParameter1, TParameter2, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverOnNotifyProperyChanged{TResult}" />
    internal sealed class PropertyObserverOnNotifyProperyChangedWithFallback<TParameter1, TParameter2, TResult> :
        PropertyObserverBase<IPropertyObserverOnNotifyProperyChanged<TResult>, TParameter1, TParameter2, TResult>,
        IPropertyObserverOnNotifyProperyChanged<TResult>
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
        private readonly Func<TResult> getter;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                parameter2,
                propertyExpression,
                taskScheduler,
                fallback,
                false,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] TaskScheduler taskScheduler,
            [NotNull] TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(
                    Getter(propertyExpression, this.Tree, fallback, parameter1, parameter2),
                    taskScheduler),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            PropertyObserverFlag observerFlag)
            : this(
                parameter1,
                parameter2,
                propertyExpression,
                synchronizationContext,
                fallback,
                false,
                LazyThreadSafetyMode.None,
                observerFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] SynchronizationContext synchronizationContext,
            [NotNull] TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(
                    Getter(propertyExpression, this.Tree, fallback, parameter1, parameter2),
                    synchronizationContext),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                parameter2,
                propertyExpression,
                fallback,
                false,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1, TParameter2, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            [NotNull] TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, parameter2, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1, parameter2)),
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
        public TResult Value => this.getter();

        /// <summary>
        ///     On the action.
        /// </summary>
        protected override void OnAction() => this.action();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns>
        ///     Getter.
        /// </returns>
        private static Func<TResult> Getter(
            Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback,
            TParameter1 parameter1,
            TParameter2 parameter2)
        {
            var get = ExpressionGetter.CreateGetter<TParameter1, TParameter2, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback);
            return () => get(parameter1, parameter2);
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}