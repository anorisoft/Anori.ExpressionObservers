// -----------------------------------------------------------------------
// <copyright file="ExpressionGetter.ValueGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Tree.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     Expression Getter.
    /// </summary>
    public static partial class ExpressionGetter
    {
        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The getter.
        /// </returns>
        /// <exception cref="ArgumentNullException">expression is null.</exception>
        [NotNull]
        public static Func<TResult?> CreateValueGetter<TResult>([NotNull] Expression<Func<TResult>> expression)
            where TResult : struct
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="expressionTree">The tree.</param>
        /// <returns>
        ///     The getter.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     parameters
        ///     or
        ///     tree is null.
        /// </exception>
        [NotNull]
        public static Func<TResult?> CreateValueGetter<TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters,
            [NotNull] IExpressionTree expressionTree)
            where TResult : struct
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (expressionTree == null)
            {
                throw new ArgumentNullException(nameof(expressionTree));
            }

            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expressionTree);
            var lambda = Expression.Lambda<Func<TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="expressionTree">The expression tree.</param>
        /// <returns>The Getter.</returns>
        /// <exception cref="ArgumentNullException">
        ///     parameters or expressionTree is null.
        /// </exception>
        [NotNull]
        public static Func<TParameter1, TResult?> CreateValueGetter<TParameter1, TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters,
            [NotNull] IExpressionTree expressionTree)
            where TResult : struct
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (expressionTree == null)
            {
                throw new ArgumentNullException(nameof(expressionTree));
            }

            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expressionTree);
            var lambda = Expression.Lambda<Func<TParameter1, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="expressionTree">The expression tree.</param>
        /// <returns>The Getter.</returns>
        /// <exception cref="ArgumentNullException">
        ///     parameters
        ///     or
        ///     expressionTree is null.
        /// </exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TResult?> CreateValueGetter<TParameter1, TParameter2, TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters,
            [NotNull] IExpressionTree expressionTree)
            where TResult : struct
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (expressionTree == null)
            {
                throw new ArgumentNullException(nameof(expressionTree));
            }

            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expressionTree);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The getter.</returns>
        /// <exception cref="ArgumentNullException">expression is null.</exception>
        [NotNull]
        public static Func<TParameter, TResult?> CreateValueGetter<TParameter, TResult>(
            [NotNull] Expression<Func<TParameter, TResult>> expression)
            where TResult : struct
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The getter.
        /// </returns>
        /// <exception cref="ArgumentNullException">expression is null.</exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TResult?> CreateValueGetter<TParameter1, TParameter2, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : struct
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The getter.
        /// </returns>
        /// <exception cref="ArgumentNullException">expression is null.</exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TParameter3, TResult?> CreateValueGetter<TParameter1, TParameter2,
            TParameter3, TResult>([NotNull] Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : struct
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter3, TResult?>>(body, parameters);
            return lambda.Compile();
        }
    }
}