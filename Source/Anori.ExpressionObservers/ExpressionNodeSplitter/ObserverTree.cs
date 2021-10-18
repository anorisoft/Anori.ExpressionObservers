// -----------------------------------------------------------------------
// <copyright file="ObserverTree.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using System;

    public partial class ObserverTree
    {
        private ObserverTree(IObserverTreeHead observerTreeNode, Type type)
        {
            this.Head = observerTreeNode;
            this.Type = type;
        }

        public static ObserverTreeFactory Factory { get; } =
            new(new NotifyCollectionChangedFinder(), new NotifyPropertyChangedFinder());

        public IObserverTreeHead Head { get; }

        public Type Type { get; }
    }
}