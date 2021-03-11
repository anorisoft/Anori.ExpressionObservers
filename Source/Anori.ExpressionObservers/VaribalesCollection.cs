// -----------------------------------------------------------------------
// <copyright file="VaribalesCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    ///     Varibales Collection.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List{System.Linq.Expressions.ParameterExpression}" />
    internal class VaribalesCollection : List<ParameterExpression>
    {
        /// <summary>
        ///     The index.
        /// </summary>
        private int index;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VaribalesCollection" /> class.
        /// </summary>
        public VaribalesCollection() => this.index = 1;

        /// <summary>
        ///     Gets the index of the next.
        /// </summary>
        /// <returns>The index.</returns>
        public int GetNextIndex() => ++this.index;
    }
}