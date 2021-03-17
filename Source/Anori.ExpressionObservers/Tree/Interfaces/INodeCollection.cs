// -----------------------------------------------------------------------
// <copyright file="INodeCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Node Collection interface.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{Anori.ExpressionObservers.Interfaces.IExpressionNode}" />
    /// <seealso cref="IExpressionTree" />
    public interface INodeCollection : IList<IExpressionNode>, IExpressionTree
    {
    }
}