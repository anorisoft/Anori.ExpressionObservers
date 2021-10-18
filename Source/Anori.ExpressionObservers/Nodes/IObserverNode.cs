// -----------------------------------------------------------------------
// <copyright file="IObserverNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    public interface IObserverNode
    {
        void UnsubscribeListener();
       // void SubscribeListener(object obj);
        IObserverNode Next { get; set; }
        IObserverNode Previous { get; set; }
        object Observable { get; }
        void SubscribeNextNode();
        void SubscribeListener();
    }
}