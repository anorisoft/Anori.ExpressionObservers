// -----------------------------------------------------------------------
// <copyright file="IExpressionTreeFactory.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.Interfaces
{
    using System.Linq.Expressions;

    public interface IExpressionTreeFactory
    {
        IExpressionTree New<TFunc>(Expression<TFunc> expression);

        IExpressionTree New(LambdaExpression expression);
    }
}