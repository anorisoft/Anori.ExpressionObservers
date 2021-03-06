﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverFundatinBase.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Anori.Common;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.ExpressionObservers.Tree.Nodes;
    using Anori.Extensions;

    /// <summary>
    ///     Property Observer Base.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="System.Collections.Generic.IEqualityComparer{Anori.ExpressionObservers.Base.PropertyObserverBase}" />
    /// <seealso cref="System.IEquatable{Anori.ExpressionObservers.Base.PropertyObserverBase}" />
    /// <seealso cref="IEqualityComparer{T}" />
    /// <seealso cref="IEquatable{T}" />
    /// <seealso cref="PropertyObserverFundatinBase" />
    /// <seealso cref="IDisposable" />
#pragma warning disable S4035 // Classes implementing "IEquatable<T>" should be sealed
    internal abstract class PropertyObserverFundatinBase : IDisposable,
                                                           IEqualityComparer<PropertyObserverFundatinBase>,
                                                           IEquatable<PropertyObserverFundatinBase>,
                                                           IActivatable
#pragma warning restore S4035 // Classes implementing "IEquatable<T>" should be sealed
    {
        private bool isActive;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverFundatinBase" /> class.
        /// </summary>
        /// <param name="observerFlag">The observer flag.</param>
        protected PropertyObserverFundatinBase(PropertyObserverFlag observerFlag)
        {
            this.ObserverFlag = observerFlag;
        }

        /// <summary>
        ///     Occurs when [is active changed].
        /// </summary>
        public event EventHandler<EventArgs<bool>>? IsActiveChanged;

        /// <summary>
        ///     Gets a value indicating whether this instance is fail fast.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is fail fast; otherwise, <c>false</c>.
        /// </value>
        private protected PropertyObserverFlag ObserverFlag { get; }

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public abstract string ExpressionString { get; }

        /// <summary>
        ///     Gets the root nodes.
        /// </summary>
        /// <value>
        ///     The root nodes.
        /// </value>
        internal IList<RootPropertyObserverNode> RootNodes { get; } = new List<RootPropertyObserverNode>();

        /// <summary>
        ///     Gets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get => this.isActive;
            private set
            {
                if (this.isActive == value)
                {
                    return;
                }

                this.isActive = value;
                this.IsActiveChanged.Raise(this, value);
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <summary>
        ///     Subscribes this instance.
        /// </summary>
        public void Activate()
        {
            this.Activate(false);
        }

        /// <summary>
        ///     Deactivates this instance.
        /// </summary>
        /// <exception cref="Anori.ExpressionObservers.Exceptions.AlreadyDeactivatedException">Already Deactivated.</exception>
        public void Deactivate()
        {
            if (!this.IsActive)
            {
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionOnGetIfDeactivated))
                {
                    throw new AlreadyDeactivatedException();
                }

                return;
            }

            this.IsActive = false;

            foreach (var rootPropertyObserverNode in this.RootNodes)
            {
                rootPropertyObserverNode.UnsubscribeListener();
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!this.IsActive)
                {
                    return;
                }

                this.IsActive = false;

                foreach (var rootPropertyObserverNode in this.RootNodes)
                {
                    rootPropertyObserverNode.UnsubscribeListener();
                }
            }
        }

        /// <summary>
        ///     Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        ///     true if the specified objects are equal; otherwise, false.
        /// </returns>
        public static bool Equals(PropertyObserverFundatinBase? x, PropertyObserverFundatinBase? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null))
            {
                return false;
            }

            if (ReferenceEquals(y, null))
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            if (x.ExpressionString != y.ExpressionString)
            {
                return false;
            }

            if (!x.RootNodes.SequenceEqual(y.RootNodes))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(PropertyObserverFundatinBase? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.RootNodes.SequenceEqual(other.RootNodes) && this.ExpressionString == other.ExpressionString;
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
            if (ReferenceEquals(null, obj))
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

            return this.Equals((PropertyObserverFundatinBase)obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.RootNodes != null ? this.RootNodes.GetHashCode() : 0) * 397)
                       ^ (this.ExpressionString != null ? this.ExpressionString.GetHashCode() : 0);
            }
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public int GetHashCode(PropertyObserverFundatinBase obj)
        {
            unchecked
            {
                return ((obj.ExpressionString != null ? obj.ExpressionString.GetHashCode() : 0) * 397)
                       ^ (obj.RootNodes != null ? obj.RootNodes.GetHashCode() : 0);
            }
        }

        /// <summary>
        ///     Subscribes the specified silent.
        /// </summary>
        /// <param name="silent">if set to <c>true</c> [silent].</param>
        protected void Activate(bool silent)
        {
            if (this.IsActive)
            {
                if (this.ObserverFlag.HasFlag(PropertyObserverFlag.ThrowsExceptionIfAlreadyActivated))
                {
                    throw new AlreadyActivatedException();
                }

                return;
            }

            this.IsActive = true;
            foreach (var rootPropertyObserverNode in this.RootNodes)
            {
                rootPropertyObserverNode.SubscribeListenerForRoot();
            }

            if (!silent)
            {
                this.OnAction();
            }
        }

        /// <summary>
        ///     The action.
        /// </summary>
        protected abstract void OnAction();

        /// <summary>
        /// Looptrees the specified expression node.
        /// </summary>
        /// <param name="expressionNode">The expression node.</param>
        /// <param name="observerNode">The observer node.</param>
        internal void LoopTree(IExpressionNode expressionNode, PropertyObserverNode observerNode)
        {
            var previousNode = observerNode;
            while (expressionNode.Next is PropertyNode property)
            {
                var currentNode = new PropertyObserverNode(property.PropertyInfo, this.OnAction);

                previousNode.Previous = currentNode;
                previousNode = currentNode;
                expressionNode = expressionNode.Next;
            }
        }

        /// <summary>
        ///     Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        ///     true if the specified objects are equal; otherwise, false.
        /// </returns>
        bool IEqualityComparer<PropertyObserverFundatinBase>.Equals(
            PropertyObserverFundatinBase? x,
            PropertyObserverFundatinBase? y) =>
            Equals(x, y);

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(PropertyObserverFundatinBase? a, PropertyObserverFundatinBase? b) =>
            Equals(a, b);

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(PropertyObserverFundatinBase a, object b)
        {
            return Equals(a, b);
        }

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(PropertyObserverFundatinBase a, PropertyObserverFundatinBase b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(PropertyObserverFundatinBase a, object b)
        {
            return !a.Equals(b);
        }
    }
}