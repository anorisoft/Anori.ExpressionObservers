// -----------------------------------------------------------------------
// <copyright file="RootPropertyObserverNode{TParameter1}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Observers
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    ///     Root Property Observer Node.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Observers.PropertyObserverNode" />
    internal class RootPropertyObserverNode<TParameter1> : PropertyObserverNode
        where TParameter1 : INotifyPropertyChanged
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RootPropertyObserverNode{TParameter}" /> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <param name="parameter1">The parameter1.</param>
        public RootPropertyObserverNode(PropertyInfo propertyInfo, Action action, TParameter1 parameter1)
            : base(propertyInfo, action)
        {
            this.Parameter1 = parameter1;
        }

        /// <summary>
        ///     Gets the parameter.
        /// </summary>
        /// <value>
        ///     The parameter.
        /// </value>
        public TParameter1 Parameter1 { get; }
    }
}