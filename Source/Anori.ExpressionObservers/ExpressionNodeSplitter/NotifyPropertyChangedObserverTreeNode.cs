// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedObserverTreeNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using System.Collections.Generic;

    using Anori.ExpressionTrees.Interfaces;

    public class NotifyPropertyChangedObserverTreeNode : IObserverTreeNode
    {
        private readonly List<IObserverTreeNode> children = new();

        public NotifyPropertyChangedObserverTreeNode(IExpressionNode expressionHead)
        {
            this.ExpressionHead = expressionHead;
        }

        public IList<IObserverTreeNode> Children => this.children;

        public IExpressionNode ExpressionHead { get; }

        public void AddChild(IObserverTreeNode item)
        {
            this.children.Add(item);
        }
    }
}