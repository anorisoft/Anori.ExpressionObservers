// -----------------------------------------------------------------------
// <copyright file="IObservableFinder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using Anori.ExpressionTrees.Interfaces;

    public interface IObservableFinder
    {
        bool IsObservable(IExpressionNode node);
        

        IObserverTreeNode CreateObserverTreeNode(IExpressionNode node);

    }
}