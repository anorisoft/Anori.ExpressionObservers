// -----------------------------------------------------------------------
// <copyright file="IObserverTreeNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using System.Collections.Generic;

    using Anori.ExpressionTrees.Interfaces;

    public interface IObserverTreeNode
    {
        void AddChild(IObserverTreeNode child);

        public IList<IObserverTreeNode> Children { get; }

        public IExpressionNode ExpressionHead { get; }

    }
}