// -----------------------------------------------------------------------
// <copyright file="INodeCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    ///     The Node Collection interface.
    /// </summary>
    public interface INodeCollection : IList<IExpressionNode>, IRootAware
    {
    }
}