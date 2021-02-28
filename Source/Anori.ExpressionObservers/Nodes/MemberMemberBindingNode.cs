// -----------------------------------------------------------------------
// <copyright file="MemberMemberBindingNode.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Member Member Binding Node.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IBindingNode" />
    internal readonly struct MemberMemberBindingNode : IBindingNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberMemberBindingNode" /> struct.
        /// </summary>
        /// <param name="memberMemberBinding">The member member binding.</param>
        /// <param name="bindings">The bindings.</param>
        /// <param name="memberInitNode">The member initialize node.</param>
        public MemberMemberBindingNode(
            MemberMemberBinding memberMemberBinding,
            List<IBindingNode> bindings,
            MemberInitNode memberInitNode)
        {
            this.MemberMemberBinding = memberMemberBinding;
            this.Bindings = bindings;
            this.MemberInitNode = memberInitNode;
        }

        /// <summary>
        ///     Gets the member member binding.
        /// </summary>
        /// <value>
        ///     The member member binding.
        /// </value>
        [NotNull]
        public MemberMemberBinding MemberMemberBinding { get; }

        /// <summary>
        ///     Gets the bindings.
        /// </summary>
        /// <value>
        ///     The bindings.
        /// </value>
        public List<IBindingNode> Bindings { get; }

        /// <summary>
        ///     Gets the member initialize node.
        /// </summary>
        /// <value>
        ///     The member initialize node.
        /// </value>
        public MemberInitNode MemberInitNode { get; }
    }
}