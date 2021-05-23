// -----------------------------------------------------------------------
// <copyright file="IMemberListBindingNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The member list binding node interface.
    /// </summary>
    /// <seealso cref="Anori.ExpressionTrees.Interfaces.IBindingNode" />
    public interface IMemberListBindingNode :IBindingNode
    {
        /// <summary>
        /// Gets the initializers.
        /// </summary>
        /// <value>
        /// The initializers.
        /// </value>
        List<IElementInitNode> Initializers { get;  }
        /// <summary>
        /// Gets the binding.
        /// </summary>
        /// <value>
        /// The binding.
        /// </value>
        MemberBinding Binding { get;  }
    }
}