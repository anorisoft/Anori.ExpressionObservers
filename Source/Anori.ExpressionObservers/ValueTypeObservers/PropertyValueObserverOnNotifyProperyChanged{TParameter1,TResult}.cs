// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverOnNotifyProperyChanged{TParameter1,TResult}.cs" company="AnoriSoft">
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
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="PropertyObserverBase{TSelf}" />
    /// <seealso
    ///     cref="PropertyObserverBase{TSelf}.ExpressionObservers.ValueTypeObservers.PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}}" />
    /// <seealso cref="INotifyPropertyChanged" />
    internal sealed class PropertyValueObserverOnNotifyProperyChanged<TParameter1, TResult> :
        PropertyObserverBase<IPropertyValueObserverOnNotifyProperyChanged<TResult>, TParameter1, TResult>,
        IPropertyValueObserverOnNotifyProperyChanged<TResult>
        where TResult : struct
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
        private readonly Func<TResult?> getter;


        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, propertyExpression, taskScheduler, false, LazyThreadSafetyMode.None, propertyObserverFlag)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}" />
        /// class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
        /// <exception cref="ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            TaskScheduler taskScheduler,
            bool isCached,
            LazyThreadSafetyMode safetyMode, PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            TResult? Get() =>
                new TaskFactory<TResult?>(taskScheduler).StartNew(Getter(propertyExpression, this.Tree, parameter1))
                    .Result;

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
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, propertyExpression, synchronizationContext, false, LazyThreadSafetyMode.None,  propertyObserverFlag)
        {
        }

        /// <summary>
            /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}" />
            /// class.
            /// </summary>
            /// <param name="parameter1">The parameter1.</param>
            /// <param name="propertyExpression">The property expression.</param>
            /// <param name="synchronizationContext">The synchronization context.</param>
            /// <param name="isCached">if set to <c>true</c> [is cached].</param>
            /// <param name="safetyMode">The safety mode.</param>
            /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
            internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            SynchronizationContext synchronizationContext,
            bool isCached,
            LazyThreadSafetyMode safetyMode, PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            TResult? Get() => synchronizationContext.Send(Getter(propertyExpression, this.Tree, parameter1));

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
        /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="propertyObserverFlagag">if set to <c>true</c> [is fail fast].</param>
        internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag propertyObserverFlag)
            : this(parameter1, propertyExpression, false,LazyThreadSafetyMode.None, propertyObserverFlag)
        {
        }

        /// <summary>
            /// Initializes a new instance of the <see cref="PropertyValueObserverOnNotifyProperyChanged{TParameter1, TResult}" />
            /// class.
            /// </summary>
            /// <param name="parameter1">The parameter1.</param>
            /// <param name="propertyExpression">The property expression.</param>
            /// <param name="isCached">if set to <c>true</c> [is cached].</param>
            /// <param name="safetyMode">The safety mode.</param>
            /// <param name="observerFlagag">if set to <c>true</c> [is fail fast].</param>
            internal PropertyValueObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            bool isCached,
            LazyThreadSafetyMode safetyMode, PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
            Func<TResult?> get = Getter(propertyExpression, this.Tree, parameter1);

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
        /// <param name="parameter1">The parameter1.</param>
        /// <returns>Getter.</returns>
        private static Func<TResult?> Getter(
            Expression<Func<TParameter1, TResult>> propertyExpression,
            IExpressionTree tree,
            TParameter1 parameter1) =>
            () => ExpressionGetter.CreateValueGetter<TParameter1, TResult>(propertyExpression.Parameters, tree)(
                parameter1);

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}