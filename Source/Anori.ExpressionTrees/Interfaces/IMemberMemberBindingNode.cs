// -----------------------------------------------------------------------
// <copyright file="IMemberMemberBindingNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IMemberMemberBindingNode : IBindingNode
    {
        List<IBindingNode> Bindings { get;  }
        MemberMemberBinding MemberMemberBinding { get; }
    }
}