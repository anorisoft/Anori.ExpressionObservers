// -----------------------------------------------------------------------
// <copyright file="NotifyCollectionChangedFinder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using System;
    using System.Collections.Specialized;

    using Anori.ExpressionTrees.Interfaces;

    public class NotifyCollectionChangedFinder : IObservableFinder
    {
        public IObserverTreeNode CreateObserverTreeNode(IExpressionNode node)
        {
            return new NotifyCollectionChangedObserverTreeNode(node);
        }
        public bool IsObservable(IExpressionNode node)
        {
            return node.Result != null && IsTypeAssignableFrom<INotifyCollectionChanged>(node.Type)
                                       && IsTypeAssignableFrom<IFunctionNode>(node.Result.GetType());
        }

        private static bool IsTypeAssignableFrom<T>(Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }
    }
}