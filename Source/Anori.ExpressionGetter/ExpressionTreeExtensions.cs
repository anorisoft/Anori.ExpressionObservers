// -----------------------------------------------------------------------
// <copyright file="ExpressionTreeExtensions.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters
{
    using System.Linq.Expressions;

    using Anori.ExpressionGetters.Tree.Interfaces;

    /// <summary>
    ///     The Expression Tree Extensions class.
    /// </summary>
    public static class ExpressionTreeExtensions
    {
        /// <summary>
        ///     The Expression Tree by LambdaExpression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The Expression Tree.</returns>
        public static IExpressionTree ExpressionTree(this LambdaExpression expression) =>
            Tree.ExpressionTree.New(expression);

        /// <summary>
        ///     The Expression Tree by Expression{TFunc}.
        /// </summary>
        /// <typeparam name="TFunc">The type of the function.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The Expression Tree.</returns>
        public static IExpressionTree ExpressionTree<TFunc>(this Expression<TFunc> expression) =>
            Tree.ExpressionTree.New(expression);
    }
}