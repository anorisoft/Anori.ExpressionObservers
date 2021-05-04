// -----------------------------------------------------------------------
// <copyright file="CachedObserver{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceObservers.OnValueChanged
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
    ///     cref="INotifyPropertyChanged" />
    /// <seealso cref="ComponentModel" />
    /// <seealso cref="System" />
    /// <seealso cref="CachedObserver{TResult}" />
    internal sealed class CachedObserver<TParameter1, TResult> :
        ObserverBase<INotifyReferencePropertyObserver<TResult>, TParameter1, TResult>,
        INotifyReferencePropertyObserver<TResult>
        where TParameter1 : INotifyPropertyChanged
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
        ///     Initializes a new instance of the
        ///     <see cref="CachedObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="taskScheduler">The property expression.</param>
        /// <param name="propertyObserverFlag">The task scheduler.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal CachedObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                propertyExpression,
                taskScheduler,
                false,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="CachedObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="taskScheduler">The property expression.</param>
        /// <param name="isCached">The task scheduler.</param>
        /// <param name="safetyMode">if set to <c>true</c> [is cached].</param>
        /// <param name="observerFlag">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="System">propertyExpression is null.</exception>
        internal CachedObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree, parameter1), taskScheduler),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        /// The silent action.
        /// </summary>
        [NotNull] private readonly Action silentAction;

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.silentAction.Raise();

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="CachedObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="synchronizationContext">The property expression.</param>
        /// <param name="propertyObserverFlag">The synchronization context.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal CachedObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag propertyObserverFlag)
            : this(
                parameter1,
                propertyExpression,
                synchronizationContext,
                true,
                LazyThreadSafetyMode.None,
                propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="CachedObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="synchronizationContext">The property expression.</param>
        /// <param name="isCached">The synchronization context.</param>
        /// <param name="safetyMode">if set to <c>true</c> [is cached].</param>
        /// <param name="observerFlag">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal CachedObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(
                    Getter(propertyExpression, this.Tree, parameter1),
                    synchronizationContext),
                isCached,
                safetyMode,
                () => this.OnPropertyChanged(nameof(this.Value)));
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="CachedObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="propertyObserverFlag">The property expression.</param>
        /// <param name="propertyObserverFlag">The property observer flag.</param>
        internal CachedObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, propertyExpression, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="CachedObserver{TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The parameter1.</param>
        /// <param name="isCached">The property expression.</param>
        /// <param name="safetyMode">if set to <c>true</c> [is cached].</param>
        /// <param name="observerFlag">The safety mode.</param>
        /// <param name="observerFlag">The observer flag.</param>
        internal CachedObserver(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            (this.action, this.getter) = this.CreateNullableReferenceCachedGetter(
                this.CreateNullableReferenceGetter(Getter(propertyExpression, this.Tree, parameter1)),
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
        /// <returns>The Getter.</returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1) =>
            () => ExpressionGetter.CreateReferenceGetterByTree<TParameter1, TResult>(
                propertyExpression.Parameters,
                tree)(parameter1);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}