using System.Collections.Generic;
using System.Linq.Expressions;

namespace Anori.ExpressionObservers
{
    internal class VaribalesCollection : List<ParameterExpression>
    {
        /// <summary>
        /// The index
        /// </summary>
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="VaribalesCollection"/> class.
        /// </summary>
        public VaribalesCollection() => index = 1;

        /// <summary>
        /// Gets the index of the next.
        /// </summary>
        /// <returns></returns>
        public int GetNextIndex() => ++index;
    }
}