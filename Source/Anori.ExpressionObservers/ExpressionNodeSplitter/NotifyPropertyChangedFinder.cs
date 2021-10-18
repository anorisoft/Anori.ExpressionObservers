// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedFinder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using System;
    using System.ComponentModel;

    using Anori.ExpressionTrees.Interfaces;

    public class NotifyPropertyChangedFinder : IObservableFinder
    {
        public bool IsObservable(IExpressionNode node)
        {
            return IsTypeAssignableFrom<INotifyPropertyChanged>(node.Type)
                   && typeof(IPropertyNode).IsAssignableFrom(node.Result?.GetType());

        }
        public IObserverTreeNode CreateObserverTreeNode(IExpressionNode node)
        {
            return new NotifyPropertyChangedObserverTreeHead(node);
        }

        private static bool IsTypeAssignableFrom<T>(Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }
    }
}