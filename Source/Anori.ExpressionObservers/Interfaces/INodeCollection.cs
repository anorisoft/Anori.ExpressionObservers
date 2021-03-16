// -----------------------------------------------------------------------
// <copyright file="INodeCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Node Collection interface.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{Anori.ExpressionObservers.Interfaces.IExpressionNode}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IExpressionTree" />
    public interface INodeCollection : IList<IExpressionNode>, IExpressionTree
    {
    }
}