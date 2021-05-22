// -----------------------------------------------------------------------
// <copyright file="IMemberListBindingNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IMemberListBindingNode :IBindingNode
    {
        List<IElementInitNode> Initializers { get;  }
        MemberBinding Binding { get;  }
    }
}