// -----------------------------------------------------------------------
// <copyright file="PropertyObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using Anori.Common;
    using Anori.Extensions;
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    ///     Represents each node of nested properties expression and takes care of
    ///     subscribing/unsubscribing INotifyPropertyChanged.PropertyChanged listeners on it.
    /// </summary>
    internal class PropertyObserverNode : IObserverNode
    {
        /// <summary>
        ///     The action.
        /// </summary>
        private readonly Action action;

        /// <summary>
        ///     The notify property changed.
        /// </summary>
 //       private INotifyPropertyChanged? notifyPropertyChanged;

        private IDisposable? unsubscribe;

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
                    if (this.Next == null)
                    {
                        return;
                    }

                    this.Next.UnsubscribeListener();
                    this.GenerateNextNode();
                };
        }

        /// <summary>
        ///     Gets or sets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IObserverNode? Next { get; set; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        private PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Unsubscribes the listener.
        /// </summary>
        public void UnsubscribeListener()
        {
            this.unsubscribe?.Dispose();
            this.Next?.UnsubscribeListener();
        }

        /// <summary>
        /// Subscribes the listener for.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public void SubscribeListenerFor(object obj)
        {
            if (obj is not INotifyPropertyChanged propertyChanged)
            {
                return;
            }

            this.SubscribeListenerFor(propertyChanged);
        }

        /// <summary>
        ///     Subscribes the listener for.
        /// </summary>
        /// <param name="propertyChanged">The property changed.</param>
        protected void SubscribeListenerFor(INotifyPropertyChanged propertyChanged)
        {
            //this.notifyPropertyChanged = propertyChanged;

            this.next = () => this.PropertyInfo.GetValue(propertyChanged);
            propertyChanged.PropertyChanged += this.OnPropertyChanged;

            this.unsubscribe = new Disposable(() =>
                {
                    this.next = null;
                    propertyChanged.PropertyChanged -= this.OnPropertyChanged;
                });

            if (this.Next != null)
            {
                this.GenerateNextNode();
            }
        }

        private Func<object>? next;

        /// <summary>
        ///     Generates the next node.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Trying to subscribe PropertyChanged listener in object that "
        ///     + $"owns '{this.Previous.PropertyInfo.Name}' property, but the object does not implements INotifyPropertyChanged.
        /// </exception>
        public void GenerateNextNode()
        {
            var nextProperty = next.Raise();

            if (nextProperty == null)
            {
                return;
            }

            if (nextProperty is INotifyCollectionChanged notifyCollectionChanged)
            {
                this.Next?.SubscribeListenerFor(notifyCollectionChanged);
                return;
            }

            if (nextProperty is INotifyPropertyChanged propertyChanged)
            {
                this.Next?.SubscribeListenerFor(propertyChanged);
                return;
            }

            if (nextProperty.IsNullableTypeAssignableFrom<INotifyPropertyChanged>())
            {
                var propertyInfo = Nullable.GetUnderlyingType(nextProperty.GetType())?.GetProperty("Value");

                if (propertyInfo is null)
                {
                    return;
                }

                var nextPropertyChanged = (INotifyPropertyChanged)propertyInfo.GetValue(nextProperty);
                this.Next?.SubscribeListenerFor(nextPropertyChanged);
                return;
            }
        }

        protected void SubscribeListenerFor(INotifyCollectionChanged notifyCollectionChanged)
        {
            //    this.next = () => this.PropertyInfo.GetValue(propertyChanged);
            notifyCollectionChanged.CollectionChanged += this.OnCollectionChanged;

            this.unsubscribe = new Disposable(() =>
                {
                    this.next = null;
                    notifyCollectionChanged.CollectionChanged -= this.OnCollectionChanged;
                });

            if (this.Next != null)
            {
                this.GenerateNextNode();
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.PropertyInfo.Name || string.IsNullOrEmpty(e.PropertyName))
            {
                this.action.Raise();
            }
        }
    }
}