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
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Interfaces;

    /// <summary>
    ///     Represents each node of nested properties expression and takes care of
    ///     subscribing/unsubscribing INotifyPropertyChanged.PropertyChanged listeners on it.
    /// </summary>
    internal class IndexerObserverNode : IObserverNode
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
        ///     Initializes a new instance of the <see cref="IndexerObserverNode" /> class.
        /// </summary>
        /// <param name="methodInfo">The property information.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">propertyInfo is null.</exception>
        public IndexerObserverNode(MethodInfo methodInfo, IList<IExpressionNode> arguments, Action action)
        {
            this.MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));

            args = new List<Func<object>>(arguments.Count);

            foreach (var argument in arguments)
            {
                var first = argument;

                if (first is IConstantNode constantNode)
                {
                    args.Add(()=> constantNode.Value);
                }
                else if (first is IParameterNode parameterNode)
                {
                    args.Add(() => parameterNode.Expression);
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
        private MethodInfo MethodInfo { get; }

        /// <summary>
        ///     Unsubscribes the listener.
        /// </summary>
        public void UnsubscribeListener()
        {
            this.unsubscribe?.Dispose();
            this.Next?.UnsubscribeListener();
        }

        public void SubscribeListenerFor(object obj)
        {
            
            if (obj is INotifyCollectionChanged collectionChanged)
            {
                SubscribeListenerFor(collectionChanged);
                return;
            }
            
            if (obj is INotifyPropertyChanged propertyChanged)
            {
                SubscribeListenerFor(propertyChanged);
                return;
            }
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

            this.unsubscribe = new Disposable(() =>
                {
                    this.getProperty = null;
 //                   propertyChanged.PropertyChanged -= this.OnPropertyChanged;
                });

            if (this.Next != null)
            {
                this.GenerateNextNode();
            }
        }

        /// <summary>
        /// The get property.
        /// </summary>
        private Func<object>? getProperty;

        /// <summary>
        /// The arguments.
        /// </summary>
        private readonly List<Func<object>> args;

        /// <summary>
        ///     Generates the next node.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Trying to subscribe PropertyChanged listener in object that "
        ///     + $"owns '{this.Previous.PropertyInfo.Name}' property, but the object does not implements INotifyPropertyChanged.
        /// </exception>
        public void GenerateNextNode()
        {
            var nextProperty = this.getProperty.Raise();

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
            var args = GetArgs();
            this.getProperty = () =>
                {
                    var value = this.MethodInfo.Invoke(notifyCollectionChanged, args);
                    return value;
                };


            notifyCollectionChanged.CollectionChanged += this.OnCollectionChanged;

            this.unsubscribe = new Disposable(() =>
                {
                    this.getProperty = null;
                    notifyCollectionChanged.CollectionChanged -= this.OnCollectionChanged;
                });

            if (this.Next != null)
            {
                this.Next.GenerateNextNode();
            }
        }
        private object[] GetArgs()
        {
            return this.args.Select(f => f.Raise()).ToArray();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.action.Raise();
        }

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