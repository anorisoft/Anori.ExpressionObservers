// -----------------------------------------------------------------------
// <copyright file="IMemberMemberBindingNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The i member member binding node interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionTrees.Interfaces.IBindingNode" />
    public interface IMemberMemberBindingNode : IBindingNode
    {
        /// <summary>
        /// Gets the bindings.
        /// </summary>
        /// <value>
        /// The bindings.
        /// </value>
        List<IBindingNode> Bindings { get;  }


        /// <summary>
        /// Gets the member member binding.
        /// </summary>
        /// <value>
        /// The member member binding.
        /// </value>
        MemberMemberBinding MemberMemberBinding { get;  }
    }
}