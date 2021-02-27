﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace Anori.ExpressionObservers.Observers
{
    internal class RootPropertyObserverNode : PropertyObserverNode , IEquatable<RootPropertyObserverNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootPropertyObserverNode"/> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <param name="parameter">The parameter.</param>
        public RootPropertyObserverNode(PropertyInfo propertyInfo, Action action, object parameter)
            : base(propertyInfo, action) =>
            this.Parameter = parameter;

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public object Parameter { get; }

        /// <summary>
        /// Subscribes the listener for parameter.
        /// </summary>
        public void SubscribeListenerForOwner()
        {
            if (this.Parameter is INotifyPropertyChanged notifyPropertyChanged)
            {
                this.SubscribeListenerFor(notifyPropertyChanged);
            }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(RootPropertyObserverNode other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Parameter, other.Parameter);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RootPropertyObserverNode) obj);
        }

        public override int GetHashCode()
        {
            return (Parameter != null ? Parameter.GetHashCode() : 0);
        }
    }
}