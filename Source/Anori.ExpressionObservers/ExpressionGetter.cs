using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Anori.ExpressionObservers.Nodes;
using JetBrains.Annotations;

namespace Anori.ExpressionObservers
{
    public static class ExpressionGetter
    {
        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">expression</exception>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TResult?> CreateValueGetter<TResult>(
            [NotNull] Expression<Func<TResult>> expression)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="tree">The tree.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// parameters
        /// or
        /// tree
        /// </exception>
        /// <exception cref="ArgumentNullException">parameters
        /// or
        /// tree</exception>
        [NotNull]
       public static Func<TResult?> CreateValueGetter<TResult>(
           [NotNull] ReadOnlyCollection<ParameterExpression> parameters,
           [NotNull] ExpressionTree tree)
            where TResult : struct
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (tree == null) throw new ArgumentNullException(nameof(tree));
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), tree);
            var lambda = Expression.Lambda<Func<TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="tree">The tree.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// parameters
        /// or
        /// tree
        /// </exception>
        /// <exception cref="ArgumentNullException">parameters
        /// or
        /// tree</exception>
        [NotNull]
        public static Func<TResult> CreateReferenceGetter<TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters, 
            [NotNull] ExpressionTree tree)
            where TResult : class
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (tree == null) throw new ArgumentNullException(nameof(tree));
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), tree);
            var lambda = Expression.Lambda<Func<TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// parameters
        /// or
        /// tree
        /// </exception>
        [NotNull]
        public static Func<TResult> CreateValueGetter<TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters, [NotNull] ExpressionTree tree, TResult fallback)
            where TResult : struct
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (tree == null) throw new ArgumentNullException(nameof(tree));
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), tree, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// parameters
        /// or
        /// tree
        /// </exception>
        [NotNull]
        public static Func<TParameter1, TResult> CreateValueGetter<TParameter1, TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters, [NotNull] ExpressionTree tree, TResult fallback)
            where TResult : struct
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (tree == null) throw new ArgumentNullException(nameof(tree));
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), tree, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TParameter1, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// parameters
        /// or
        /// tree
        /// </exception>
        [NotNull]
        public static Func<TResult> CreateReferenceGetter<TResult>(
            [NotNull] ReadOnlyCollection<ParameterExpression> parameters, [NotNull] ExpressionTree tree, TResult fallback)
            where TResult : class
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (tree == null) throw new ArgumentNullException(nameof(tree));
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), tree, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter, TResult?> CreateValueGetter<TParameter, TResult>(
            [NotNull] Expression<Func<TParameter, TResult>> expression)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter, TResult> CreateValueGetter<TParameter, TResult>(
            [NotNull] Expression<Func<TParameter, TResult>> expression, TResult fallback)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TParameter, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TResult> CreateValueGetter<TResult>(
            [NotNull] Expression<Func<TResult>> expression, TResult fallback)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TResult?> CreateValueGetter<TParameter1, TParameter2, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TResult?> CreateValueGetter<TParameter1, TParameter2, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression, TResult fallback)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TParameter3, TResult?> CreateValueGetter<TParameter1, TParameter2,
            TParameter3, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : struct
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter3, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the value getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        [NotNull]
        public static Func<TParameter1, TParameter2, TParameter3, TResult?> CreateValueGetter<TParameter1, TParameter2,
            TParameter3, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression, TResult fallback)
            where TResult : struct
        {
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult?), expression.Body, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter3, TResult?>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter, TResult> CreateReferenceGetter<TParameter, TResult>(
            [NotNull] Expression<Func<TParameter, TResult>> expression)
            where TResult : class
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter, TResult> CreateReferenceGetter<TParameter, TResult>(
            [NotNull] Expression<Func<TParameter, TResult>> expression, TResult fallback)
            where TResult : class
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TParameter, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">expression</exception>
        [NotNull]
        public static Func<TParameter1, TParameter2, TResult> CreateReferenceGetter<TParameter1, TParameter2, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression)
            where TResult : class
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        [NotNull]
        public static Func<TParameter1, TParameter2, TParameter3, TResult> CreateReferenceGetter<TParameter1,
            TParameter2, TParameter3, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression)
            where TResult : class
        {
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter3, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the reference getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TParameter3">The type of the parameter3.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        [NotNull]
        public static Func<TParameter1, TParameter2, TParameter3, TResult> CreateReferenceGetter<TParameter1,
            TParameter2, TParameter3, TResult>(
            [NotNull] Expression<Func<TParameter1, TParameter2, TParameter3, TResult>> expression, [CanBeNull] TResult fallback)
            where TResult : class
        {
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateValueBody(typeof(TResult), expression.Body, Fallback(fallback));
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter3, TResult>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        /// Creates the parameter getter.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        [CanBeNull]
        public static Func<TParameter1, TParameter2, object> CreateParameterGetter<TParameter1, TParameter2, TResult>(
            [NotNull] ParameterNode parameter, 
            [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression)
        {
            var parameters = expression.Parameters;
            var body = ExpressionCreator.CreateParameterBody(parameter);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, object>>(body, parameters);
            return lambda.Compile();
        }


        /// <summary>
        /// Fallbacks the specified fallback.
        /// </summary>
        /// <typeparam name="TFallback">The type of the fallback.</typeparam>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        [CanBeNull]
        private static Expression Fallback<TFallback>(TFallback fallback) =>
            Expression.Constant(fallback, typeof(TFallback));
    }
}