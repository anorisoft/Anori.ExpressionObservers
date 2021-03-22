// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverOnNotifyProperyChanged{TParameter1,TParameter2,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ReferenceTypeObservers
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Base;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Base.PropertyObserverBase{Anori.ExpressionObservers.ReferenceTypeObservers.PropertyReferenceObserverOnNotifyProperyChanged{TParameter1, TParameter2, TResult}, TParameter1, TParameter2, TResult}" />
    /// <seealso cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="PropertyObserverBase" />
    public sealed class PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TParameter2, TResult> :
        PropertyObserverBase<PropertyReferenceObserverOnNotifyProperyChanged<TParameter1, TParameter2, TResult>,
            TParameter1, TParameter2, TResult>,
        INotifyPropertyChanged
        where TParameter1 : INotifyPropertyChanged
        where TParameter2 : INotifyPropertyChanged
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
        ///     <see cref="PropertyReferenceObserverOnNotifyProperyChanged{TParameter1, TParameter2,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isCached">if set to <c>true</c> [is cached].</param>
        /// <param name="safetyMode">The safety mode.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal PropertyReferenceObserverOnNotifyProperyChanged(
            [NotNull] TParameter1 parameter1,
            [NotNull] TParameter2 parameter2,
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> propertyExpression,
            bool isCached = false,
            LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None,
            TaskScheduler? taskScheduler = null)
            : base(parameter1, parameter2, propertyExpression)
        {
            Func<TResult?> get;
            if (taskScheduler == null)
            {
                get = () => ExpressionGetter.CreateReferenceGetter<TParameter1, TParameter2, TResult>(
                    propertyExpression.Parameters,
                    this.Tree)(parameter1, parameter2);
            }
            else
            {
                get = () => new TaskFactory<TResult?>(taskScheduler).StartNew(
                        p =>
                            {
                                var (p1, p2) = (ValueTuple<TParameter1, TParameter2>)p;
                                return ExpressionGetter.CreateReferenceGetter<TParameter1, TParameter2, TResult>(
                                    propertyExpression.Parameters,
                                    this.Tree)(p1, p2);
                            },
                        new ValueTuple<TParameter1, TParameter2>(parameter1, parameter2))
                    .Result;
            }

            if (isCached)
            {
                var cache = new ResetLazy<TResult?>(() => get(), safetyMode);
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
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}