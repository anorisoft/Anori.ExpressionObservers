// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedObserverTreeHead.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    public class NotifyPropertyChangedObserverTreeHead : NotifyPropertyChangedObserverTreeNode, IObserverTreeHead
    {
        public NotifyPropertyChangedObserverTreeHead([NotNull] IExpressionNode expressionHead)
            : base(expressionHead)
        {
        }
    }
}