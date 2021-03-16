// -----------------------------------------------------------------------
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
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Observers;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Reference Observer With Getter.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="PropertyReferenceObserverOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverBase" />
    public sealed class PropertyReferenceObserverOnNotifyProperyChanged<TResult> :
        PropertyObserverBase<PropertyReferenceObserverOnNotifyProperyChanged<TResult>>,
        INotifyPropertyChanged
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
        private readonly Func<TResult> getter;

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
            bool isCached = false,
            LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None,
            TaskScheduler? taskScheduler = null)
        {
            propertyExpression = propertyExpression ?? throw new ArgumentNullException(nameof(propertyExpression));
            var tree = ExpressionTree.GetTree(propertyExpression.Body);
            this.ExpressionString = propertyExpression.ToString();

            this.CreateChain(tree);

            Func<TResult> get;
            if (taskScheduler == null)
            {
                get = ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree);
            }
            else
            {
                get = () => new TaskFactory<TResult>(taskScheduler).StartNew(
                        ExpressionGetter.CreateReferenceGetter<TResult>(propertyExpression.Parameters, tree))
                    .Result;
            }

            if (isCached)
            {
                var cache = new ResetLazy<TResult>(() => get(), safetyMode);
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
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public override string ExpressionString { get; }

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