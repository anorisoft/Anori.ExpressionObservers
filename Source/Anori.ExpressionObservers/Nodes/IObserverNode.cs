// -----------------------------------------------------------------------
// <copyright file="IObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    internal interface IObserverNode
    {
        void UnsubscribeListener();
        void SubscribeListenerFor(object obj);
        IObserverNode Next { get; set; }
        void GenerateNextNode();
    }
}