// -----------------------------------------------------------------------
// <copyright file="MemberAssignmentNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Nodes
{
    using System.Linq.Expressions;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Member Assignment Node.
    /// </summary>
    /// <seealso cref="IBindingNode" />
    internal readonly struct MemberAssignmentNode : IMemberAssignmentNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberAssignmentNode" /> struct.
        /// </summary>
        /// <param name="memberAssignment">The member assignment.</param>
        /// <param name="nodes">The nodes.</param>
        public MemberAssignmentNode([NotNull] MemberAssignment memberAssignment, [NotNull] INodeCollection nodes)
        {
            this.MemberAssignment = memberAssignment;
            this.Nodes = nodes;
        }

        /// <summary>
        ///     Gets the member assignment.
        /// </summary>
        /// <value>
        ///     The member assignment.
        /// </value>
        [NotNull]
        public MemberAssignment MemberAssignment { get; }

        /// <summary>
        ///     Gets the nodes.
        /// </summary>
        /// <value>
        ///     The nodes.
        /// </value>
        [NotNull]
        public INodeCollection Nodes { get; }

        /// <summary>
        ///     Gets the binding.
        /// </summary>
        /// <value>
        ///     The binding.
        /// </value>
        [NotNull]
        public MemberBinding Binding => this.MemberAssignment;
    }
}