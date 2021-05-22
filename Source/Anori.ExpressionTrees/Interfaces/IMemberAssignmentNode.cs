// -----------------------------------------------------------------------
// <copyright file="IMemberAssignmentNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Linq.Expressions;

    public interface IMemberAssignmentNode : IBindingNode
    {
        INodeCollection Nodes { get; }
        MemberBinding Binding { get; }
    }
}