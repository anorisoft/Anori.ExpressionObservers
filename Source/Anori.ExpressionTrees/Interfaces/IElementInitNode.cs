// -----------------------------------------------------------------------
// <copyright file="IElementInitNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IElementInitNode
    {
        IEnumerable<INodeCollection> Arguments { get; }

        ElementInit ElementInit { get; }
    }
}