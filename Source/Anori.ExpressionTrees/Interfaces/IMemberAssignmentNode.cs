// -----------------------------------------------------------------------
// <copyright file="IMemberAssignmentNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Linq.Expressions;

    /// <summary>
    /// The i member assignment node interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionTrees.Interfaces.IBindingNode" />
    public interface IMemberAssignmentNode : IBindingNode
    {
        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        INodeCollection Nodes { get; }
        /// <summary>
        /// Gets the binding.
        /// </summary>
        /// <value>
        /// The binding.
        /// </value>
        MemberBinding Binding { get; }
    }
}