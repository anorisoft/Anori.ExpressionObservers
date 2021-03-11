// -----------------------------------------------------------------------
// <copyright file="MemberListBindingNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Member List Binding Node.
    /// </summary>
    /// <seealso cref="Anori.ExpressionObservers.Nodes.IBindingNode" />
    internal readonly struct MemberListBindingNode : IBindingNode
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberListBindingNode" /> struct.
        /// </summary>
        /// <param name="memberListBinding">The member list binding.</param>
        /// <param name="initializers">The initializers.</param>
        public MemberListBindingNode(MemberListBinding memberListBinding, List<ElementInitNode> initializers)
        {
            this.MemberListBinding = memberListBinding;
            this.Initializers = initializers;
        }

        /// <summary>
        ///     Gets the member list binding.
        /// </summary>
        /// <value>
        ///     The member list binding.
        /// </value>
        [NotNull]
        public MemberListBinding MemberListBinding { get; }

        /// <summary>
        ///     Gets the initializers.
        /// </summary>
        /// <value>
        ///     The initializers.
        /// </value>
        public List<ElementInitNode> Initializers { get; }

        /// <summary>
        ///     Gets the binding.
        /// </summary>
        /// <value>
        ///     The binding.
        /// </value>
        public MemberBinding Binding => this.MemberListBinding;
    }
}