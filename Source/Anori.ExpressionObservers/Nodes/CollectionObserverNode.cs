// -----------------------------------------------------------------------
// <copyright file="CollectionObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    using Anori.Common;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions;

    /// <summary>
    ///     Represents each node of nested properties expression and takes care of
    ///     subscribing/unsubscribing INotifyPropertyChanged.PropertyChanged listeners on it.
    /// </summary>
    internal class CollectionObserverNode : IObserverNode
    {
        /// <summary>
        ///     The action.
        /// </summary>
        private readonly Action action;

        /// <summary>
        ///     The arguments.
        /// </summary>
        private readonly List<Func<object>> args;

        /// <summary>
        ///     The notify property changed.
        /// </summary>
        //       private INotifyPropertyChanged? notifyPropertyChanged;
        private IDisposable? unsubscribe;

        /// <summary>
        ///     The get property.
        /// </summary>
        private Func<object>? getProperty;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CollectionObserverNode" /> class.
        /// </summary>
        /// <param name="methodInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">propertyInfo is null.</exception>
        public CollectionObserverNode(MethodInfo methodInfo, IList<IExpressionNode> arguments, Action action)
        {
            this.MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));

            this.args = new List<Func<object>>(arguments.Count);

            foreach (var argument in arguments)
            {
                var first = argument;

                if (first is IConstantNode constantNode)
                {
                    this.args.Add(() => constantNode.Value);
                }
                else if (first is IParameterNode parameterNode)
                {
                    this.args.Add(() => parameterNode.Expression);
                }
                else if (first is IFieldNode fieldNode)
                {
                    //              args.Add(() => fieldNode.FieldInfo.GetValue());
                }
                else
                {
                    throw new Exception(first.GetType().ToString());
                }
            }

            this.action = () =>
                {
                    action.Raise();
                    if (this.Next == null)
                    {
                        return;
                    }

                    this.Next.UnsubscribeListener();
                    this.SubscribeNextNode();
                };
        }
        public object Observable { get; }
        public object Value { get; }

        /// <summary>
        ///     Gets or sets the next.
        /// </summary>
        /// <value>
        ///     The next.
        /// </value>
        public IObserverNode? Next { get; set; }

        public IObserverNode Previous { get; set; }

        public Func<object> GetObservable { get; set; }

        /// <summary>
        ///     Gets the property information.
        /// </summary>
        /// <value>
        ///     The property information.
        /// </value>
        private MethodInfo MethodInfo { get; }

        public void SubscribeListenerFor(object obj)
        {
            if (obj is INotifyCollectionChanged collectionChanged)
            {
                this.SubscribeListenerFor(collectionChanged);
                return;
            }

            if (obj is INotifyPropertyChanged propertyChanged)
            {
                this.SubscribeListener();
            }
        }

        public void SubscribeListener()
        {
            var args = this.GetArgs();
            INotifyCollectionChanged notifyCollectionChanged = this.GetObservable() as INotifyCollectionChanged;
            this.getProperty = () =>
                {
                    var value = this.MethodInfo.Invoke(notifyCollectionChanged, args);
                    return value;
                };

            notifyCollectionChanged.CollectionChanged += this.OnCollectionChanged;

            this.unsubscribe = new Disposable(
                () =>
                    {
                        this.getProperty = null;
                        notifyCollectionChanged.CollectionChanged -= this.OnCollectionChanged;
                    });

            if (this.Next != null)
            {
                this.Next.SubscribeNextNode();
            }
        }

        /// <summary>
        ///     Generates the next node.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Trying to subscribe PropertyChanged listener in object that "
        ///     + $"owns '{this.ParameterNotes.PropertyInfo.Name}' property, but the object does not implements INotifyPropertyChanged.
        /// </exception>
        public void SubscribeNextNode()
        {
            var nextProperty = this.getProperty.Raise();

            if (nextProperty == null)
            {
                return;
            }

            if (nextProperty is INotifyCollectionChanged notifyCollectionChanged)
            {
                this.Next?.SubscribeListener();
                return;
            }

            if (nextProperty is INotifyPropertyChanged propertyChanged)
            {
                this.Next?.SubscribeListener();
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
                this.Next?.SubscribeListener();
            }
        }

        /// <summary>
        ///     Unsubscribes the listener.
        /// </summary>
        public void UnsubscribeListener()
        {
            this.unsubscribe?.Dispose();
            this.Next?.UnsubscribeListener();
        }

        /// <summary>
        ///     Subscribes the listener for.
        /// </summary>
        /// <param name="propertyChanged">The property changed.</param>
        protected void SubscribeListenerFor(object obj, object[] args)
        {
            //this.notifyPropertyChanged = propertyChanged;

            this.getProperty = () => this.MethodInfo.Invoke(obj, args);
            //            propertyChanged.PropertyChanged += this.OnPropertyChanged;

            this.unsubscribe = new Disposable(
                () =>
                    {
                        this.getProperty = null;
                        //                   propertyChanged.PropertyChanged -= this.OnPropertyChanged;
                    });

            if (this.Next != null)
            {
                this.SubscribeNextNode();
            }
        }

        private object[] GetArgs()
        {
            return this.args.Select(f => f.Raise()).ToArray();
        }

        /// <summary>
        ///     Called when [collection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => this.action.Raise();

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.MethodInfo.Name || string.IsNullOrEmpty(e.PropertyName))
            {
                this.action.Raise();
            }
        }
    }
}