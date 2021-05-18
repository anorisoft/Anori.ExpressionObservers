// -----------------------------------------------------------------------
// <copyright file="RootPropertyObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    ///     Root Property Observer Node.
    /// </summary>
    internal class RootPropertyObserverNode : PropertyObserverNode, IEquatable<RootPropertyObserverNode>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RootPropertyObserverNode" /> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <param name="parameter">The parameter.</param>
        public RootPropertyObserverNode(PropertyInfo propertyInfo, Action action, object? parameter)
            : base(propertyInfo, action) =>
            this.Parameter = parameter;

        /// <summary>
        ///     Gets the parameter.
        /// </summary>
        /// <value>
        ///     The parameter.
        /// </value>
        public object? Parameter { get; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(RootPropertyObserverNode? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(this.Parameter, other.Parameter);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((RootPropertyObserverNode)obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => this.Parameter != null ? this.Parameter.GetHashCode() : 0;

        /// <summary>
        ///     Subscribes the listener for parameter.
        /// </summary>
        public void SubscribeListenerForRoot()
        {
            if (this.Parameter is INotifyPropertyChanged notifyPropertyChanged)
            {
                this.SubscribeListenerFor(notifyPropertyChanged);
            }
        }
    }
}