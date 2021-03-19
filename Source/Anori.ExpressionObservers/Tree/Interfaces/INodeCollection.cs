// -----------------------------------------------------------------------
// <copyright file="INodeCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    ///     The Node Collection interface.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{Anori.ExpressionObservers.Tree.Interfaces.IExpressionNode}" />
    /// <seealso cref="Anori.ExpressionObservers.Tree.Interfaces.IRootAware" />
    public interface INodeCollection : IList<IExpressionNode>, IRootAware
    {
    }
}