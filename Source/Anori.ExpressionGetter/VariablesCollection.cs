// -----------------------------------------------------------------------
// <copyright file="VariablesCollection.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    ///     The Variables Collection class.
    /// </summary>
    internal class VariablesCollection : List<ParameterExpression>
    {
        /// <summary>
        ///     The index.
        /// </summary>
        private int index;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VariablesCollection" /> class.
        /// </summary>
        public VariablesCollection() => this.index = 1;

        /// <summary>
        ///     Gets the index of the next.
        /// </summary>
        /// <returns>The index.</returns>
        public int GetNextIndex() => ++this.index;
    }
}