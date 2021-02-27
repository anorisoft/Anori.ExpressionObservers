// -----------------------------------------------------------------------
// <copyright file="RootPropertyObserverNode.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Reflection;

namespace Anori.ExpressionObservers.Observers
{
    internal class RootPropertyObserverNode<TParameter> : PropertyObserverNode
        
        where TParameter : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootPropertyObserverNode"/> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <param name="parameter">The parameter.</param>
        public RootPropertyObserverNode(PropertyInfo propertyInfo, Action action, TParameter parameter1)
            : base(propertyInfo, action)
        {

            this.Parameter1 = parameter1;
        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public TParameter Parameter1 { get; }

        /// <summary>
        /// Subscribes the listener for parameter.
        /// </summary>
   //     public void SubscribeListenerForOwner() => this.SubscribeListenerFor(this.Parameter1);
    }
}