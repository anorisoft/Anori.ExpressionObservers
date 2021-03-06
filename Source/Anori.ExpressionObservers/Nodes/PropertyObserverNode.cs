﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    using Anori.Extensions;

    /// <summary>
    ///     Represents each node of nested properties expression and takes care of
    ///     subscribing/unsubscribing INotifyPropertyChanged.PropertyChanged listeners on it.
    /// </summary>
    internal class PropertyObserverNode
    {
        /// <summary>
        ///     The action.
        /// </summary>
        private readonly Action action;

        /// <summary>
        ///     The notify property changed.
        /// </summary>
        private INotifyPropertyChanged? notifyPropertyChanged;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverNode" /> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">propertyInfo is null.</exception>
        public PropertyObserverNode(PropertyInfo propertyInfo, Action action)
        {
            this.PropertyInfo = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));
            this.action = () =>
                {
                    action.Raise();
                    if (this.Previous == null)
                    {
                        return;
                    }

                    this.Previous.UnsubscribeListener();
                    this.GenerateNextNode();
                };
        }

        /// <summary>
        ///     Gets or sets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public PropertyObserverNode? Previous { get; set; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        public PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Subscribes the listener for.
        /// </summary>
        /// <param name="propertyChanged">The property changed.</param>
        public void SubscribeListenerFor(INotifyPropertyChanged propertyChanged)
        {
            this.notifyPropertyChanged = propertyChanged;
            this.notifyPropertyChanged.PropertyChanged += this.OnPropertyChanged;

            if (this.Previous != null)
            {
                this.GenerateNextNode();
            }
        }

        /// <summary>
        ///     Unsubscribes the listener.
        /// </summary>
        public void UnsubscribeListener()
        {
            if (this.notifyPropertyChanged != null)
            {
                this.notifyPropertyChanged.PropertyChanged -= this.OnPropertyChanged;
            }

            this.Previous?.UnsubscribeListener();
        }

        /// <summary>
        ///     Generates the next node.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Trying to subscribe PropertyChanged listener in object that "
        ///     + $"owns '{this.Previous.PropertyInfo.Name}' property, but the object does not implements INotifyPropertyChanged.
        /// </exception>
        private void GenerateNextNode()
        {
            var nextProperty = this.PropertyInfo.GetValue(this.notifyPropertyChanged);
            if (nextProperty == null)
            {
                return;
            }

            if (!(nextProperty is INotifyPropertyChanged propertyChanged))
            {
                throw new InvalidOperationException(
                    "Trying to subscribe PropertyChanged listener in object that "
                    + $"owns '{this.Previous?.PropertyInfo.Name}' property, but the object does not implements INotifyPropertyChanged.");
            }

            this.Previous?.SubscribeListenerFor(propertyChanged);
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e?.PropertyName == this.PropertyInfo.Name || string.IsNullOrEmpty(e?.PropertyName))
            {
                this.action.Raise();
            }
        }
    }
}