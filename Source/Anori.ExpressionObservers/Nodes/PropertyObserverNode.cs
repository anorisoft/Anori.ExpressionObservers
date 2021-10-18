// -----------------------------------------------------------------------
// <copyright file="PropertyObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    using Anori.Common;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions;

    /// <summary>
    ///     Represents each node of nested properties expression and takes care of
    ///     subscribing/unsubscribing INotifyPropertyChanged.PropertyChanged listeners on it.
    /// </summary>
    internal class PropertyObserverNode : IObserverNode
    {
        /// <summary>
        /// The action.
        /// </summary>
        private readonly Action action;

        /// <summary>
        ///     The propertyChangedAction.
        /// </summary>
        private Action propertyChangedAction;

        /// <summary>
        ///     The notify property changed.
        /// </summary>
        private IDisposable? unsubscribe;

        /// <summary>
        ///     The property changed.
        /// </summary>
        private INotifyPropertyChanged? propertyChanged;

        /// <summary>
        ///     Gets or sets the get next observable.
        /// </summary>
        /// <value>
        ///     The get next observable.
        /// </value>
        private Func<object>? getNextObservable;

        /// <summary>
        /// The next.
        /// </summary>
        private IObserverNode? next;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyObserverNode" /> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="action">The propertyChangedAction.</param>
        /// <exception cref="ArgumentNullException">propertyInfo is null.</exception>
        public PropertyObserverNode(PropertyInfo propertyInfo, Action action)
        {
            this.PropertyInfo = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));
            this.getNextObservable = () => this.PropertyInfo.GetValue(this.propertyChanged);
            this.GetObservable ??= () => this.Previous?.Observable;

            this.action = action;
            this.propertyChangedAction = action;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyObserverNode"/> class.
        /// </summary>
        /// <param name="propertyNode">The property node.</param>
        /// <param name="action">The action.</param>
        public PropertyObserverNode(IPropertyNode propertyNode, Action action) :this(propertyNode.PropertyInfo, action)
        {
        }

        /// <summary>
        ///     Gets the observable.
        /// </summary>
        /// <value>
        ///     The observable.
        /// </value>
        public object Observable => this.getNextObservable.Raise();

        /// <summary>
        ///     Gets or sets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IObserverNode? Next
        {
            get => this.next;
            set
            {
                this.next = value;
                this.propertyChangedAction =
                    value != null ? 
                        () => SubscribeUnsubscribeListener(this.action, this.next) :
                        this.action;
            }
        }

        /// <summary>
        ///     Gets or sets the previous.
        /// </summary>
        /// <value>
        ///     The previous.
        /// </value>
        public IObserverNode? Previous { get; set; } = null!;

        /// <summary>
        ///     Gets or sets the get observable.
        /// </summary>
        /// <value>
        ///     The get observable.
        /// </value>
        protected Func<object>? GetObservable { get; set; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        private PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Subscribes the listener.
        /// </summary>
        public void SubscribeListener()
        {
            var changed = this.propertyChanged = this.GetObservable.Raise() as INotifyPropertyChanged;
            if (changed == null)
            {
                this.unsubscribe?.Dispose();
                return;
            }

            this.unsubscribe?.Dispose();
            changed.PropertyChanged += this.OnPropertyChanged;
            this.unsubscribe = new Disposable(
                () =>
                    {
                        this.unsubscribe = null;
                        this.getNextObservable = null;
                        changed.PropertyChanged -= this.OnPropertyChanged;
                        this.Next?.UnsubscribeListener();
                    });

            if (this.Next != null)
            {
                this.SubscribeNextNode();
            }
        }

        /// <summary>
        ///     Subscribes the next node.
        /// </summary>
        public void SubscribeNextNode() => this.Next?.SubscribeListener();

        /// <summary>
        ///     Unsubscribes the listener.
        /// </summary>
        public void UnsubscribeListener() => this.unsubscribe?.Dispose();

        /// <summary>
        ///     Subscribes the unsubscribe listener.
        /// </summary>
        /// <param name="next">The next.</param>
        private static void SubscribeUnsubscribeListener(Action action, IObserverNode next)
        {
            action.Raise();
            next.UnsubscribeListener();
            next.SubscribeListener();
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
                this.propertyChangedAction.Raise();
            }
        }
    }
}