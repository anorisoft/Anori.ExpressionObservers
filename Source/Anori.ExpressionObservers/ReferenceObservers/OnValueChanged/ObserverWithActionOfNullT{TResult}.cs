// -----------------------------------------------------------------------
// <copyright file="ObserverWithActionOfNullT{TResult}.cs" company="AnoriSoft">
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

    /// <summary>
    ///     The Observer With Action Of Null T class.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal sealed class ObserverWithActionOfNullT<TResult> :
        ObserverOnValueChangedBase<INotifyReferencePropertyObserver<TResult>, TResult>,
        INotifyReferencePropertyObserver<TResult>
        where TResult : class
    {
        /// <summary>
        ///     The valueChangedAction.
        /// </summary>
        [NotNull]
        private readonly Action<TResult?, TResult?> valueChangedAction;

        /// <summary>
        ///     The getter.
        /// </summary>
        [NotNull]
        private readonly Func<TResult?> getter;

        /// <summary>
        ///     The silent valueChangedAction.
        /// </summary>
        [NotNull]
        private readonly Action silentAction;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionOfNullT{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The valueChangedAction.</param>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">valueChangedAction</exception>
        /// <exception cref="System.ArgumentNullException">propertyExpression is null.</exception>
        internal ObserverWithActionOfNullT(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?, TResult?> action,
            [NotNull] TaskScheduler taskScheduler,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateGetter(this.CreateGetter(Getter(propertyExpression, this.Tree), taskScheduler));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionOfNullT{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The valueChangedAction.</param>
        /// <param name="synchronizationContext">The synchronization context.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">valueChangedAction</exception>
        internal ObserverWithActionOfNullT(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            [NotNull] SynchronizationContext synchronizationContext,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(
                this.CreateGetter(Getter(propertyExpression, this.Tree), synchronizationContext));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverWithActionOfNullT{TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="action">The valueChangedAction.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <exception cref="ArgumentNullException">valueChangedAction</exception>
        internal ObserverWithActionOfNullT(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            [NotNull] Action<TResult?> action,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
            this.valueChangedAction = action ?? throw new ArgumentNullException(nameof(action));
            this.getter = this.CreateNullableReferenceGetter(this.CreateGetter(Getter(propertyExpression, this.Tree)));
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public TResult? Value => this.getter();

        /// <summary>
        ///     On the valueChangedAction.
        /// </summary>
        protected override void OnAction() => this.valueChangedAction(this.getter());

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.silentAction.Raise();

        /// <summary>
        ///     Getters the specified property expression.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>Getter.</returns>
        private static Func<TResult?> Getter(Expression<Func<TResult>> propertyExpression, IExpressionTree tree) =>
            ExpressionGetter.CreateReferenceGetterByTree<TResult>(propertyExpression.Parameters, tree);

      
    }
}