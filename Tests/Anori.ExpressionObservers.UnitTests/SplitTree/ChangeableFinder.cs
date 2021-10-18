// -----------------------------------------------------------------------
// <copyright file="ChangeableFinder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree
{
    using System;

    using Anori.ExpressionObservers.ExpressionNodeSplitter;
    using Anori.ExpressionTrees.Interfaces;

    public class ChangeableFinder : IObservableFinder
    {
        public bool IsObservable(IExpressionNode node)
        {
            return IsTypeAssignableFrom<IPropertyNode>(node.GetType()) && IsTypeAssignableFrom<IChangeable>(node.Type);

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