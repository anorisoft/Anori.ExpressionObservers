// -----------------------------------------------------------------------
// <copyright file="ObserverOnValueChangedBase{TSelf,TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers.Base
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using Anori.ExpressionObservers.Base;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.Extensions;

    using JetBrains.Annotations;

    /// <summary>
    ///     The Observer On Value Changed Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    internal abstract class
        ObserverOnValueChangedBase<TSelf, TParameter1, TResult> : ObserverBase<TSelf, TParameter1, TResult>,
                                                                  INotifyPropertyChanged
        where TParameter1 : INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverOnValueChangedBase{TSelf, TParameter1,TResult}" /> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        protected ObserverOnValueChangedBase(
            [NotNull] TParameter1 parameter1,
            [NotNull] Expression<Func<TParameter1, TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(parameter1, propertyExpression, observerFlag)
        {
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets or sets the update value action.
        /// </summary>
        /// <value>
        ///     The update value action.
        /// </value>
        [NotNull]
        private protected Action UpdateValueProperty { get; set; } = null!;

        /// <summary>
        ///     Gets or sets the silent update value action.
        /// </summary>
        /// <value>
        ///     The silent update value action.
        /// </value>
        [NotNull]
        private protected Action UpdateValueField { get; set; } = null!;

        /// <summary>
        ///     Gets or sets the reset value property.
        /// </summary>
        /// <value>
        ///     The reset value property.
        /// </value>
        private protected Action ResetValueProperty { get; set; } = null!;

        /// <summary>
        ///     The action.
        /// </summary>
        protected override void OnAction() => this.UpdateValueProperty.Raise();

        /// <summary>
        ///     Called when [deactivate].
        /// </summary>
        protected override void OnDeactivate() => this.ResetValueProperty.Raise();

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.UpdateValueField.Raise();

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Is any published.</returns>
        [NotifyPropertyChangedInvocator]
        private protected bool OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            this.PropertyChanged.Raise(this, propertyName);
    }
}