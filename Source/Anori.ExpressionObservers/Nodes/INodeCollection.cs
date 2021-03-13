// -----------------------------------------------------------------------
// <copyright file="INodeCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System.Collections.Generic;

    public interface INodeCollection : IList<IExpressionNode>, IExpressionTree
    {
    }
}