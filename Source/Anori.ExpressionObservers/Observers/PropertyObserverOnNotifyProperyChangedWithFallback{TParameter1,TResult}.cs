// -----------------------------------------------------------------------
// <copyright file="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TResult}.cs" company="AnoriSoft">
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
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.Interfaces.IPropertyObserverOnNotifyProperyChanged{TResult}, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="PropertyReferenceObserverOnNotifyProperyChanged{TParameter1,TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    internal sealed class PropertyObserverOnNotifyProperyChangedWithFallback<TParameter1, TResult> :
        PropertyObserverBase<IPropertyObserverOnNotifyProperyChanged<TResult>, TParameter1, TResult>,
        IPropertyObserverOnNotifyProperyChanged<TResult>
        where TParameter1 : INotifyPropertyChanged
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
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
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
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1), taskScheduler),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            TResult fallback,
            PropertyObserverFlag observerFlag)
            : this(
                parameter1,
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
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(
                    Getter(propertyExpression, this.Tree, fallback, parameter1),
                    synchronizationContext),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TResult fallback,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, propertyExpression, fallback, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="PropertyObserverOnNotifyProperyChangedWithFallback{TParameter1, TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal PropertyObserverOnNotifyProperyChangedWithFallback(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TResult fallback,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateCachedGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree, fallback, parameter1)),
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
        /// <returns>Getter.</returns>
        private static Func<TResult> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TResult fallback,
            TParameter1 parameter1)
        {
            var get = ExpressionGetter.CreateGetter<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree,
                fallback);
            return () => get(parameter1);
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