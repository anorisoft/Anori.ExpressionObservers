// -----------------------------------------------------------------------
// <copyright file="ObserverOnValueChangedBase.cs" company="AnoriSoft">
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
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Base.ObserverBase{TSelf, TResult}" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    internal abstract class ObserverOnValueChangedBase<TSelf, TResult> : ObserverBase<TSelf, TResult>,
                                                                         INotifyPropertyChanged
        where TSelf : IPropertyObserverBase<TSelf>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObserverOnValueChangedBase{TSelf, TResult}" /> class.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="observerFlag">The observer flag.</param>
        protected ObserverOnValueChangedBase(
            [NotNull] Expression<Func<TResult>> propertyExpression,
            PropertyObserverFlag observerFlag)
            : base(propertyExpression, observerFlag)
        {
        }

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
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Called when [silent activate].
        /// </summary>
        protected override void OnSilentActivate() => this.UpdateValueField.Raise();


        /// <summary>
        /// The action.
        /// </summary>
        protected override void OnAction() => this.UpdateValueProperty.Raise();

        /// <summary>
        /// Called when [deactivate].
        /// </summary>
        protected override void OnDeactivate() => this.ResetValueProperty.Raise();

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