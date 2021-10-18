// -----------------------------------------------------------------------
// <copyright file="ObserverNodeCreator.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;

    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions;

    using JetBrains.Annotations;


    internal class ObserverNodeCreator
    {
        private static ClassDebugger DebugExtensions { get; } = new ClassDebugger(typeof(ObserverNodeCreator));

        private readonly ObserverNodeBase observerNode;

        private readonly Dictionary<ParameterExpression, ConstantExpression> constants;

        private readonly IExpressionNode expressionNode;

        private readonly Type resultType;

        private readonly LambdaExpression expression;

        private readonly Expression escape;

        private Dictionary<ParameterExpression, ConstantExpression> dictionary;

        private LabelTarget returnTarget;

        private ObserverNodeCreator(
            ObserverNodeBase observerNode,
            Dictionary<ParameterExpression, ConstantExpression> constants,
            IExpressionNode expressionNode,
            Type resultType,
            Expression escape)
        {
            using var debug = DebugExtensions.DebugMethod();
            this.observerNode = observerNode;
            this.constants = constants;
            this.expressionNode = expressionNode;
            this.resultType = resultType;
            this.escape = escape;
        }

        private ObserverNodeCreator(
            ObserverNodeBase observerNode,
            Dictionary<ParameterExpression, ConstantExpression> constants,
            IExpressionNode expressionNode)
        {
            using var debug = DebugExtensions.DebugMethod();
            this.observerNode = observerNode;
            this.constants = constants;
            this.expressionNode = expressionNode;
            this.escape = this.escape;
        }

        private ObserverNodeCreator(ObserverNodeBase observerNode, IExpressionNode expressionNode)
        {
            using var debug = DebugExtensions.DebugMethod();
            this.observerNode = observerNode;
            this.constants = this.constants;
            this.expressionNode = expressionNode;
            this.escape = this.escape;
        }

        public BlockExpression Body { get; private set; }

        /// <summary>
        ///     Gets the false constant expression.
        /// </summary>
        /// <value>
        ///     The false constant expression.
        /// </value>
        [NotNull]
        private static ConstantExpression FalseConstantExpression => Expression.Constant(false);

        /// <summary>
        ///     Gets the true constant expression.
        /// </summary>
        /// <value>
        ///     The true constant expression.
        /// </value>
        [NotNull]
        private static ConstantExpression TrueConstantExpression => Expression.Constant(true);

        /// <summary>
        ///     Gets the parameter object from expression.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        [CanBeNull]
        public static Func<TParameter1, TParameter2, object>
            GetParameterObjectFromExpression<TParameter1, TParameter2, TResult>(
                [NotNull] IParameterNode parameter,
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression)
        {
            using var debug = DebugExtensions.DebugMethod();
            var parameters = expression.Parameters;
            var body = CreateParameterBody(parameter);
            var lambda = Expression.Lambda<Func<TParameter1, TParameter2, object>>(body, parameters);
            return lambda.Compile();
        }

        /// <summary>
        ///     Gets the parameter object from expression.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns></returns>
        [CanBeNull]
        public static Func<IParameterNode, TParameter>
            GetParameterToConstantExpression<TParameter1, TParameter2, TResult, TParameter>(
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression,
                TParameter1 parameter1,
                TParameter2 parameter2)
        {
            using var debug = DebugExtensions.DebugMethod();
            var parameters = expression.Parameters;
            return node =>
                {
                    var body = CreateParameterBody(node);
                    var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter>>(body, parameters);
                    return lambda.Compile()(parameter1, parameter2);
                };
        }

        /// <summary>
        ///     News the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="head">The head.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <returns></returns>
        public static ObserverNode<TResult> New<TParameter1, TResult>(
            TParameter1 parameter1,
            [NotNull] IReadOnlyList<ParameterExpression> parameters,
            [NotNull] IExpressionNode head,
            [NotNull] Expression fallback,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag = PropertyObserverFlag.None)
            where TParameter1 : INotifyPropertyChanged
        {
            using var debug = DebugExtensions.DebugMethod();
            var const1 = Expression.Constant(parameter1, typeof(TParameter1));
            var constants = new Dictionary<ParameterExpression, ConstantExpression> { { parameters[0], const1 } };
            var node = new ObserverNode<TResult>(action);
            var tree = new ObserverNodeCreator(node, constants, head, typeof(TResult), fallback);
            tree.Build();
            node.Getter = tree.GetGetter<TResult>();
            return node;
        }

        /// <summary>
        ///     News the specified head.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="head">The head.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <returns></returns>
        public static ObserverNode<TResult> New<TResult>(
            [NotNull] IExpressionNode head,
            [NotNull] Expression fallback,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag = PropertyObserverFlag.None)
        {
            using var debug = DebugExtensions.DebugMethod();
            var constants = new Dictionary<ParameterExpression, ConstantExpression>();
            var node = new ObserverNode<TResult>(action);
            var tree = new ObserverNodeCreator(node, constants, head, typeof(TResult), fallback);
            tree.Build();
            node.Getter = tree.GetGetter<TResult>();
            return node;
        }

        public static ObserverNode New(
            [NotNull] IExpressionNode head,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag = PropertyObserverFlag.None)
        {
            using var debug = DebugExtensions.DebugMethod();
            var constants = new Dictionary<ParameterExpression, ConstantExpression>();
            var node = new ObserverNode(action);
            var creator = new ObserverNodeCreator(node, constants, head);
            creator.BuildGetterLess();
            return node;
        }

        /// <summary>
        ///     News the specified parameter1.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="head">The head.</param>
        /// <param name="action">The action.</param>
        /// <param name="observerFlag">The observer flag.</param>
        /// <returns></returns>
        public static ObserverNode<TResult> New<TParameter1, TResult>(
            TParameter1 parameter1,
            [NotNull] IReadOnlyList<ParameterExpression> parameters,
            [NotNull] IExpressionNode head,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag = PropertyObserverFlag.None)
            where TParameter1 : INotifyPropertyChanged
        {
            using var debug = DebugExtensions.DebugMethod();
            return New<TParameter1, TResult>(
                parameter1,
                parameters,
                head,
                NullExpressionOf(typeof(TResult)),
                action,
                observerFlag);
        }

        public static ObserverNode New<TParameter1>(
            TParameter1 parameter1,
            [NotNull] IReadOnlyList<ParameterExpression> parameters,
            [NotNull] IExpressionNode head,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag = PropertyObserverFlag.None)
            where TParameter1 : INotifyPropertyChanged
        {
            using var debug = DebugExtensions.DebugMethod();
            var const1 = Expression.Constant(parameter1, typeof(TParameter1));
            var constants = new Dictionary<ParameterExpression, ConstantExpression> { { parameters[0], const1 } };
            var node = new ObserverNode(action);
            var creator = new ObserverNodeCreator(node, constants, head);
            creator.BuildGetterLess();
            return node;
        }

        public static ObserverNode<TResult> New<TResult>(
            [NotNull] IExpressionNode head,
            [NotNull] Action action,
            PropertyObserverFlag observerFlag = PropertyObserverFlag.None)
        {
            using var debug = DebugExtensions.DebugMethod();
            return New<TResult>(head, NullExpressionOf(typeof(TResult)), action, observerFlag);
        }

        /// <summary>
        ///     Gets the parameter node to constant node expression.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
        /// <typeparam name="TParameter2">The type of the parameter2.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="parameter2">The parameter2.</param>
        /// <returns></returns>
        [CanBeNull]
        public static Func<IParameterNode, ConstantExpression>
            ParameterNodeToConstantNodeExpression<TParameter1, TParameter2, TResult, TParameter>(
                [NotNull] Expression<Func<TParameter1, TParameter2, TResult>> expression,
                TParameter1 parameter1,
                TParameter2 parameter2)
        {
            using var debug = DebugExtensions.DebugMethod();
            var parameters = expression.Parameters;
            return node =>
                {
                    var body = CreateParameterBody(node);
                    var lambda = Expression.Lambda<Func<TParameter1, TParameter2, TParameter>>(body, parameters);
                    return Expression.Constant(lambda.Compile()(parameter1, parameter2), typeof(TParameter));
                };
        }

        /// <summary>
        ///     Creates the parameter body.
        /// </summary>
        /// <param name="resultParameter">The result parameter.</param>
        /// <returns>
        ///     The expression.
        /// </returns>
        [NotNull]
        internal static Expression CreateParameterBody([NotNull] IParameterNode resultParameter)
        {
            using var debug = DebugExtensions.DebugMethod();
            var body = resultParameter.Expression;
            return body;
        }

        internal void Build()
        {
            using var debug = DebugExtensions.DebugMethod();
            this.returnTarget = Expression.Label(this.resultType);
            this.Body = this.CreateValueBody(this.observerNode, this.expressionNode, this.escape);
        }

        internal void BuildGetterLess()
        {
            using var debug = DebugExtensions.DebugMethod();
            this.CreateGetterLessNode(this.observerNode, this.expressionNode);
        }

        internal Func<TResult> GetGetter<TResult>()
        {
            using var debug = DebugExtensions.DebugMethod();
            var lambda = Expression.Lambda<Func<TResult>>(this.Body);
            TResult Getter() => lambda.Compile()();
            return Getter;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="observerNodeBase"></param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The block expression.
        /// </returns>
        [NotNull]
        internal BlockExpression CreateValueBody(
            [NotNull] ObserverNodeBase observerNodeBase,
            [NotNull] IExpressionNode node,
            [NotNull] Expression fallback)
        {
            using var debug = DebugExtensions.DebugMethod();
            var body = this.CreateValueBlock(observerNodeBase, this.resultType, node, this.returnTarget, fallback);
            return body;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="observerNodeBase">The observer node base.</param>
        /// <param name="type">The type.</param>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        [NotNull]
        internal BlockExpression CreateValueBody(
            [NotNull] ObserverNodeBase observerNodeBase,
            [NotNull] Type type,
            [NotNull] IExpressionNode node)
        {
            using var debug = DebugExtensions.DebugMethod();
            var body = this.CreateValueBlock(observerNodeBase, type, node, Expression.Label(type));
            return body;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressionTree">The tree.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        internal BlockExpression CreateValueBody(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IExpressionNode head)
        {
            using var debug = DebugExtensions.DebugMethod();
            var returnTarget = Expression.Label(this.resultType);
            var body = this.CreateValueBlock(observerNode, this.resultType, head, returnTarget);
            return body;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressionTree">The tree.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        internal BlockExpression CreateValueBody(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IExpressionNode node,
            [NotNull] Expression fallback)
        {
            using var debug = DebugExtensions.DebugMethod();
            var returnTarget = Expression.Label(resultType);
            var body = this.CreateValueBlock(observerNode, resultType, node, returnTarget, fallback);
            return body;
        }

        /// <summary>
        ///     Constants the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="constant">The constant.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void ConstantLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Type resultType,
            [NotNull] IConstantNode constant,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            if (constant.Type.IsValueType && !constant.Type.IsNullable())
            {
                expressions.Add(Expression.Return(returnTarget, Expression.Constant(constant.Value, resultType)));
                return;
            }

            expressions.Add(
                Expression.IfThen(
                    Expression.Equal(Expression.Constant(constant.Value, resultType), NullExpressionOf(resultType)),
                    ifNull));
            expressions.Add(Expression.Return(returnTarget, Expression.Constant(constant.Value, resultType)));
        }

        /// <summary>
        ///     Constants the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="constant">The constant.</param>
        /// <param name="ifExpression">If expression.</param>
        private static void ConstantNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression targetParameter,
            [NotNull] IConstantNode constant,
            [NotNull] Expression ifExpression)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(Expression.Assign(targetParameter, Expression.Constant(constant.Value, constant.Type)));

            if (!constant.Type.IsValueType || constant.Type.IsNullable())
            {
                expressions.Add(
                    Expression.IfThen(
                        Expression.Equal(targetParameter, NullExpressionOf(constant.Type)),
                        ifExpression));
            }
        }

        /// <summary>
        ///     Field last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="field">The field.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void FieldLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Type resultType,
            [NotNull] IFieldNode field,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(Expression.Field(sourceParameter, field.FieldInfo), resultType)));
        }

        /// <summary>
        ///     Field next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="field">The field.</param>
        /// <param name="ifExpression">If expression.</param>
        private static void FieldNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Expression targetParameter,
            [NotNull] IFieldNode field,
            [NotNull] Expression ifExpression)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(Expression.Assign(targetParameter, Expression.Field(sourceParameter, field.FieldInfo)));

            if (field.Type.IsValueType && !field.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(field.Type)), ifExpression));
        }

        /// <summary>
        ///     Null expression.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression NullExpressionOf([NotNull] Type type)
        {
            using var debug = DebugExtensions.DebugMethod();
            return Expression.Constant(null, type);
        }

        /// <summary>
        ///     Parameter next parameter.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="ifExpression">If expression.</param>
        private static void ParameterNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression targetParameter,
            [NotNull] IExpressionNode parameter,
            [NotNull] Expression ifExpression)
        {
            using var debug = DebugExtensions.DebugMethod();
            if (parameter.Type.IsValueType && !parameter.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(parameter.Type)), ifExpression));
        }

        /// <summary>
        ///     Parameter last element.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <returns></returns>
        private static void ParameterLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Type resultType,
            [NotNull] IParameterNode parameter,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(ParameterMakeExpression(observerNode, parameter), resultType)));
        }

        /// <summary>
        ///     Parameter make expression.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The expression.
        /// </returns>
        [NotNull]
        private static Expression ParameterMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IParameterNode parameter) =>
            parameter.Expression;

        /// <summary>
        ///     Property last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="property">The property.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void PropertyLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression sourceParameter,
            [NotNull] Type resultType,
            [NotNull] IPropertyNode property,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            if (property.Type.IsValueType && !property.Type.IsNullable())
            {
                expressions.Add(
                    Expression.Return(
                        returnTarget,
                        Expression.Convert(
                            PropertyMakeExpression(observerNode, sourceParameter, property),
                            resultType)));
                return;
            }

            var name = $"value{variables.GetNextIndex()}";
            Debug.WriteLine($"{name} - {resultType}");

            var p = Expression.Variable(resultType, name);
            variables.Add(p);
            expressions.Add(Expression.Assign(p, PropertyMakeExpression(observerNode, sourceParameter, property)));
            expressions.Add(Expression.IfThen(Expression.Equal(p, NullExpressionOf(property.Type)), ifNull));
            expressions.Add(Expression.Return(returnTarget, p));
        }

        /// <summary>
        ///     Helpers the property last element.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="property">The property.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <returns></returns>
        private static void HelperPropertyLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression sourceParameter,
            [NotNull] Type resultType,
            [NotNull] PropertyNode property,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            if (property.Type.IsValueType && !property.Type.IsNullable())
            {
                expressions.Add(
                    Expression.Return(
                        returnTarget,
                        Expression.Convert(
                            PropertyMakeExpression(observerNode, sourceParameter, property),
                            resultType)));
                return;
            }

            var name = $"value{variables.GetNextIndex()}";
            Debug.WriteLine($"{name} - {resultType}");

            var p = Expression.Variable(resultType, name);
            variables.Add(p);
            expressions.Add(Expression.Assign(p, PropertyMakeExpression(observerNode, sourceParameter, property)));
            expressions.Add(Expression.IfThen(Expression.Equal(p, NullExpressionOf(property.Type)), ifNull));
            expressions.Add(Expression.Return(returnTarget, p));
        }

        /// <summary>
        ///     Property make expression.
        /// </summary>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="property">The property.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression PropertyMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Expression sourceParameter,
            [NotNull] IPropertyNode property) =>
            Expression.Call(sourceParameter, property.MethodInfo, property.Args);

        /// <summary>
        ///     Helpers the property make expression.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        [NotNull]
        private static Expression HelperPropertyMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Expression sourceParameter,
            [NotNull] IPropertyNode property)
        {
            using var debug = DebugExtensions.DebugMethod();
            return Expression.Call(sourceParameter, property.MethodInfo, property.Args);
        }

        /// <summary>
        ///     Property next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="property">The property.</param>
        /// <param name="ifNull">If null.</param>
        private static void PropertyNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Expression targetParameter,
            [NotNull] IPropertyNode property,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(targetParameter, PropertyMakeExpression(observerNode, sourceParameter, property)));

            if (property.Type.IsValueType && !property.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(property.Type)), ifNull));
        }

        /// <summary>
        ///     Helpers the property next element.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="property">The property.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns></returns>
        private static void HelperPropertyNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Expression targetParameter,
            [NotNull] IPropertyNode property,
            Type targetType,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    Expression.Convert(
                        HelperPropertyMakeExpression(observerNode, sourceParameter, property),
                        targetType)));

            if (property.Type.IsValueType && !property.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(property.Type)), ifNull));
        }

        private void CreateGetterLessNode([NotNull] ObserverNodeBase observerNode, [NotNull] IExpressionNode node)
        {
            using var debug = DebugExtensions.DebugMethod();

            List<IExpressionNode> list = new();
            var i = 0;
            while (true)
            {
                debug.WriteLine($"CreateGetterLessNode Walk down {i} - {node?.GetType().Name} - {node?.Type.Name}");

                if (i > 0 && node is IPropertyNode property && node.Parameter != null
                    && node.Parameter.Type.Implements<INotifyPropertyChanged>())
                {
                    debug.WriteLine(
                        $"INotifyPropertyChanged - {node.GetType().Name} - Property:{property.PropertyInfo.Name} as {node.Type.Name}");
                    var newNode = this.CreateNode(observerNode, node, Expression.Parameter(node.Parameter.Type));
                    list.Insert(
                        0,
                        new PropertyNode(
                            Expression.Constant(newNode),
                            typeof(SubObserverNode).GetProperty(nameof(newNode.Value)),
                            node.Type));
                    //                 list.Insert(0, new ConstantNode(newNode));
                    break;
                }

                list.Insert(0, node);

                if (node.Parameter == null)
                {
                    break;
                }

                node = node.Parameter;
                i++;
            }

            i = 1;
            var element = list.First();

            var count = list.Count;

            //for (; i < count - 1; i++)
            //{
            //    element = list[i];
            //    Debug.WriteLine(
            //        $"CreateVariableInnerExpressions Walk up {i} - {element.GetType().Name} - {element.Type.Name}");

            //    if (typeof(INotifyPropertyChanged).IsAssignableFrom(element.ParameterNotes.Type))
            //    {
            //    }

            //    this.InsertExpression(observerNode, expressions, variables, source, element, ifNull, p);
            //}
        }

        /// <summary>
        ///     Binaries the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="binary">The binary.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression BinaryMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IBinaryNode binary,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            switch (binary.BinaryExpression.NodeType)
            {
                case ExpressionType.OrElse:
                    {
                        var right = new List<Expression>();
                        right.Add(
                            Expression.Condition(
                                this.CreateVariableExpressions(
                                    observerNode,
                                    right,
                                    variables,
                                    binary.RightNode,
                                    ifNull),
                                TrueConstantExpression,
                                FalseConstantExpression));

                        var left = new List<Expression>();
                        left.Add(
                            Expression.Condition(
                                this.CreateVariableExpressions(observerNode, left, variables, binary.LeftNode, ifNull),
                                TrueConstantExpression,
                                Expression.Block(right)));

                        var block = Expression.Block(left);
                        return block;
                    }

                case ExpressionType.AndAlso:
                    {
                        var right = new List<Expression>();
                        right.Add(
                            Expression.Condition(
                                this.CreateVariableExpressions(
                                    observerNode,
                                    right,
                                    variables,
                                    binary.RightNode,
                                    ifNull),
                                TrueConstantExpression,
                                FalseConstantExpression));

                        var left = new List<Expression>();
                        left.Add(
                            Expression.Condition(
                                this.CreateVariableExpressions(observerNode, left, variables, binary.LeftNode, ifNull),
                                Expression.Block(right),
                                FalseConstantExpression));

                        var block = Expression.Block(left);
                        return block;
                    }

                case ExpressionType.Coalesce:
                    {
                        var label = Expression.Label();
                        var right = new List<Expression>();
                        right.Add(
                            this.CreateVariableExpressions(observerNode, right, variables, binary.RightNode, ifNull));
                        var rightBlock = Expression.Block(right);
                        var left = new List<Expression>();
                        var coalesce = Expression.Coalesce(
                            this.CreateVariableExpressions(
                                observerNode,
                                left,
                                variables,
                                binary.LeftNode,
                                Expression.Goto(label)),
                            rightBlock);
                        left.Add(Expression.Label(label));
                        left.Add(coalesce);

                        var block = Expression.Block(left);
                        return block;
                    }

                default:
                    {
                        var left = this.CreateVariableExpressions(
                            observerNode,
                            expressions,
                            variables,
                            binary.LeftNode,
                            ifNull);
                        var right = this.CreateVariableExpressions(
                            observerNode,
                            expressions,
                            variables,
                            binary.RightNode,
                            ifNull);
                        return Expression.MakeBinary(binary.BinaryExpression.NodeType, left, right);
                    }
            }
        }

        /// <summary>
        ///     Binaries the next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="target">The target.</param>
        /// <param name="binary">The binary.</param>
        /// <param name="ifNull">If null.</param>
        private void BinaryNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression target,
            [NotNull] IBinaryNode binary,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    target,
                    this.BinaryMakeExpression(observerNode, expressions, variables, binary, ifNull)));

            if (binary.Type.IsValueType && !binary.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(binary.Type)), ifNull));
        }

        /// <summary>
        ///     Binary element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="binary">The binary.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void BinaryLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            [NotNull] IBinaryNode binary,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        this.BinaryMakeExpression(observerNode, expressions, variables, binary, ifNull),
                        resultType)));
        }

        /// <summary>
        ///     Conditional element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="conditional">The conditional.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void ConditionalLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            [NotNull] in IConditionalNode conditional,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        this.ConditionalMakeExpression(observerNode, expressions, variables, conditional, ifNull),
                        resultType)));
        }

        /// <summary>
        ///     Conditional expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="conditional">The conditional.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression ConditionalMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IConditionalNode conditional,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var test = this.CreateVariableExpressions(observerNode, expressions, variables, conditional.Test, ifNull);

            var ifTrue = new List<Expression>();
            ifTrue.Add(this.CreateVariableExpressions(observerNode, ifTrue, variables, conditional.IfTrue, ifNull));

            var ifFalse = new List<Expression>();
            ifFalse.Add(this.CreateVariableExpressions(observerNode, ifFalse, variables, conditional.IfFalse, ifNull));

            return Expression.Condition(test, Expression.Block(ifTrue), Expression.Block(ifFalse));
        }

        /// <summary>
        ///     Conditional element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="target">The target.</param>
        /// <param name="conditional">The conditional.</param>
        /// <param name="ifNull">If null.</param>
        private void ConditionalNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression target,
            [NotNull] IConditionalNode conditional,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    target,
                    this.ConditionalMakeExpression(observerNode, expressions, variables, conditional, ifNull)));

            if (conditional.Type.IsValueType && !conditional.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(conditional.Type)), ifNull));
        }

        /// <summary>
        ///     Constructors the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression ConstructorMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IConstructorNode constructor,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var args = constructor.Parameters.Select(
                    argument => this.CreateVariableExpressions(observerNode, expressions, variables, argument, ifNull))
                .ToList();

            return Expression.New(constructor.Constructor, args);
        }

        /// <summary>
        ///     Constructors the next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="ifNull">If null.</param>
        private void ConstructorNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            [NotNull] IConstructorNode constructor,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    this.ConstructorMakeExpression(observerNode, expressions, variables, constructor, ifNull)));

            if (constructor.Type.IsValueType && !constructor.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(constructor.Type)), ifNull));
        }

        /// <summary>
        ///     Creates the binding expressions.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="binding">The binding.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Not supported Expression Tree Node type.</exception>
        [NotNull]
        private MemberBinding CreateBindingExpressions(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IBindingNode binding,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            switch (binding)
            {
                case IMemberAssignmentNode memberAssignment:
                    {
                        var expression = this.CreateVariableExpressions(
                            observerNode,
                            expressions,
                            variables,
                            memberAssignment.Node,
                            ifNull);
                        return Expression.Bind(memberAssignment.Binding.Member, expression);
                    }

                case IMemberListBindingNode memberListBinding:
                    {
                        var memberInitCollection = new List<ElementInit>();
                        foreach (var initializer in memberListBinding.Initializers)
                        {
                            var args = new List<Expression>();
                            foreach (var argument in initializer.Arguments)
                            {
                                var expression = this.CreateVariableExpressions(
                                    observerNode,
                                    expressions,
                                    variables,
                                    argument,
                                    ifNull);
                                args.Add(expression);
                            }

                            memberInitCollection.Add(Expression.ElementInit(initializer.ElementInit.AddMethod, args));
                        }

                        return Expression.ListBind(memberListBinding.Binding.Member, memberInitCollection);
                    }

                case IMemberMemberBindingNode memberMemberBindingElement:
                    {
                        var m = memberMemberBindingElement.Bindings.Select(
                            s => this.CreateBindingExpressions(observerNode, expressions, variables, s, ifNull));
                        return Expression.MemberBind(memberMemberBindingElement.MemberMemberBinding.Member, m);
                    }

                default:
                    throw new ArgumentOutOfRangeException($"{binding}");
            }
        }

        /// <summary>
        ///     Creates the value block.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <returns>The block expression.</returns>
        [NotNull]
        private BlockExpression CreateValueBlock(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IExpressionNode head,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            var expressions = new List<Expression>();
            var variables = new VariablesCollection();
            var ifNull = Expression.Return(returnTarget, NullExpressionOf(resultType));

            this.CreateValueExpressions(observerNode, resultType, head, expressions, variables, ifNull, returnTarget);

            expressions.Add(Expression.Label(returnTarget, NullExpressionOf(resultType)));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        ///     Creates the value block.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="node">The node.</param>
        /// <param name="source">The source.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <returns></returns>
        [NotNull]
        private BlockExpression CreateValueBlock(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IExpressionNode node,
            Expression source,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            var expressions = new List<Expression>();
            var variables = new VariablesCollection();
            var ifNull = Expression.Return(returnTarget, NullExpressionOf(resultType));

            var target = this.CreateVariableInnerExpressions(observerNode, expressions, variables, node, ifNull);
            this.InsertEndValueExpression(
                observerNode,
                resultType,
                expressions,
                variables,
                target,
                node,
                ifNull,
                returnTarget);

            expressions.Add(Expression.Label(returnTarget, NullExpressionOf(resultType)));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        /// Creates the value block.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="head">The head.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        /// The expression.
        /// </returns>
        [NotNull]
        private BlockExpression CreateValueBlock(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IExpressionNode head,
            [NotNull] LabelTarget returnTarget,
            [NotNull] Expression fallback)
        {
            using var debug = DebugExtensions.DebugMethod();
            var expressions = new List<Expression>();
            var variables = new VariablesCollection();
            var ifNull = Expression.Return(returnTarget, fallback);

            this.CreateValueExpressions(observerNode, resultType, head, expressions, variables, ifNull, returnTarget);

            expressions.Add(Expression.Label(returnTarget, fallback));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        ///     Creates the value chain expressions.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="node">The tree.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void CreateValueChainExpressions(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            var target = this.CreateVariableInnerExpressions(observerNode, expressions, variables, node, ifNull);
            this.InsertEndValueExpression(
                observerNode,
                resultType,
                expressions,
                variables,
                target,
                node,
                ifNull,
                returnTarget);
        }

        /// <summary>
        ///     Creates the value expressions.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="nodes">The tree.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <exception cref="NotSupportedException">Not supported node numbers.</exception>
        private void CreateValueExpressions(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IExpressionNode node,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            if (node.Parameter == null)

            {
                this.CreateValueSingleExpressions(
                    observerNode,
                    resultType,
                    expressions,
                    variables,
                    node,
                    ifNull,
                    returnTarget);
            }
            else
            {
                this.CreateValueChainExpressions(
                    observerNode,
                    resultType,
                    expressions,
                    variables,
                    node,
                    ifNull,
                    returnTarget);
            }
        }

        /// <summary>
        ///     Creates the value single expressions.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="node"></param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <param name="nodes">The tree.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supported Expression Tree Node type.</exception>
        private void CreateValueSingleExpressions(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            var element = node;
            switch (element)
            {
                case IFunctionNode function:
                    this.FunctionLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        function,
                        ifNull,
                        returnTarget);
                    break;

                case IConstantNode constant:
                    ConstantLastElement(observerNode, expressions, resultType, constant, ifNull, returnTarget);
                    break;

                case IParameterNode parameter:
                    ParameterLastElement(observerNode, expressions, resultType, parameter, returnTarget);
                    break;

                case IMethodNode method:
                    this.MethodLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        method,
                        ifNull,
                        returnTarget);
                    break;

                case IIndexerNode indexer:
                    this.IndexerLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        indexer,
                        ifNull,
                        returnTarget);
                    break;

                case IBinaryNode binary:
                    this.BinaryLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        binary,
                        ifNull,
                        returnTarget);
                    break;

                case IUnaryNode unary:
                    this.UnaryLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        unary,
                        ifNull,
                        returnTarget);
                    break;

                case IConditionalNode conditional:
                    this.ConditionalLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        conditional,
                        ifNull,
                        returnTarget);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{element}");
            }
        }

        /// <summary>
        ///     Creates the variable expressions.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The tree.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        private Expression CreateVariableExpressions(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var source = this.CreateVariableInnerExpressions(observerNode, expressions, variables, node, ifNull);
            if (node.Parameter == null)
            {
                return source;
            }

            var name = $"value{variables.GetNextIndex()}";
            debug.WriteLine($"{name} - {node.Type}");

            var target = Expression.Variable(node.Type, name);
            variables.Add(target);
            this.InsertExpression(observerNode, expressions, variables, source, node, ifNull, target);
            return target;
        }

        /// <summary>
        ///     Creates the variable inner expressions.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="node"></param>
        /// <param name="ifNull">If null.</param>
        /// <param name="nodes">The tree.</param>
        /// <returns>The expression.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Not supported element type.</exception>
        private Expression CreateVariableInnerExpressions(
            [NotNull] ObserverNodeBase obseNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();

            List<IExpressionNode> list = new();
            var i = 0;
            while (true)
            {
                debug.WriteLine(
                    $"Walk down {i} - {node.GetType().Name} - {node.Type.Name}");

                if (i > 0 && node is IPropertyNode property && node.ParameterNotes != null
                    && node.Parameter.Type.Implements<INotifyPropertyChanged>())
                {
                    debug.WriteLine(
                        $"INotifyPropertyChanged - {node.GetType().Name} - Property:{property.PropertyInfo.Name} as {node.Type.Name}");
                    var newNode = this.CreateNode(obseNode, node, Expression.Parameter(node.Parameter.Type));
                    list.Insert(
                        0,
                        new PropertyNode(
                            Expression.Constant(newNode),
                            typeof(SubObserverNode).GetProperty(nameof(newNode.Value)),
                            node.Type));
                    //                 list.Insert(0, new ConstantNode(newNode));
                    break;
                }

                list.Insert(0, node);

                if (node.Parameter == null)
                {
                    break;
                }

                node = node.Parameter;
                i++;
            }

            i = 1;
            var element = list.First();
            Expression target = this.CreateParameterExpression(obseNode, expressions, variables, element, ifNull);

            var count = list.Count;
            if (count == 1)
            {
                return target;
            }

            var source = target;
            for (; i < count - 1; i++)
            {
                element = list[i];
                debug.WriteLine(
                    $"CreateVariableInnerExpressions: Walk up {i} - {element.GetType().Name} - {element.Type.Name}");

                if (typeof(INotifyPropertyChanged).IsAssignableFrom(element.Parameter.Type))
                {
                }

                var p = Expression.Variable(element.Type, $"value{variables.GetNextIndex()}");
                variables.Add(p);
                target = p;
                this.InsertExpression(obseNode, expressions, variables, source, element, ifNull, p);
                source = target;
            }
            return target;
        }

        /// <summary>
        ///     Creates the parameter expression.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="element">The element.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">$"{element}</exception>
        private Expression CreateParameterExpression(
            ObserverNodeBase observerNode,
            IList<Expression> expressions,
            VariablesCollection variables,
            IExpressionNode? element,
            Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            Expression target;
            switch (element)
            {
                case IParameterNode parameter:
                    {
                        var p = parameter.Expression;
                        target = p;
                        ParameterNextElement(observerNode, expressions, target, parameter, ifNull);
                        break;
                    }

                case IPropertyNode property:
                    {
                        if (property is PropertyNode propertyNode)
                        {
                            var name = $"value{variables.GetNextIndex()}";
                            Debug.WriteLine($"{name} - {propertyNode.NodeType}");
                            var p = Expression.Variable(propertyNode.NodeType, name);
                            target = p;
                            variables.Add(p);
                            HelperPropertyNextElement(
                                observerNode,
                                expressions,
                                property.MemberExpression,
                                p,
                                property,
                                propertyNode.NodeType,
                                ifNull);
                            break;
                        }
                        else
                        {
                            var name = $"value{variables.GetNextIndex()}";
                            Debug.WriteLine($"{name} - {property.PropertyInfo.PropertyType}");
                            var p = Expression.Variable(property.PropertyInfo.PropertyType, name);
                            target = p;
                            variables.Add(p);
                            PropertyNextElement(
                                observerNode,
                                expressions,
                                property.MemberExpression,
                                p,
                                property,
                                ifNull);
                            break;
                        }
                    }

                case IConstantNode constant:
                    {
                        target = constant.Expression;
                        break;
                    }

                case IMethodNode method:
                    {
                        var name = $"value{variables.GetNextIndex()}";
                        Debug.WriteLine($"{name} - {method.Type}");
                        var p = Expression.Variable(method.Type, name);
                        target = p;
                        variables.Add(p);
                        this.MethodNextElement(observerNode, expressions, variables, target, method, ifNull);
                        break;
                    }

                case IIndexerNode indexer:
                    {
                        var p = Expression.Variable(indexer.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.IndexerNextElement(observerNode, expressions, variables, target, indexer, ifNull);
                        break;
                    }

                case IConstructorNode constructor:
                    {
                        var p = Expression.Variable(constructor.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.ConstructorNextElement(observerNode, expressions, variables, target, constructor, ifNull);
                        break;
                    }

                case IFunctionNode function:
                    {
                        var p = Expression.Variable(function.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.FunctionNextElement(observerNode, expressions, variables, target, function, ifNull);
                        break;
                    }

                case IBinaryNode binary:
                    {
                        var p = Expression.Variable(binary.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.BinaryNextElement(observerNode, expressions, variables, target, binary, ifNull);
                        break;
                    }

                case IUnaryNode unary:
                    {
                        var p = Expression.Variable(unary.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.UnaryNextElement(observerNode, expressions, variables, target, unary, ifNull);
                        break;
                    }

                case IConditionalNode conditional:
                    {
                        var p = Expression.Variable(conditional.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.ConditionalNextElement(observerNode, expressions, variables, target, conditional, ifNull);
                        break;
                    }

                case IMemberInitNode memberInit:
                    {
                        var p = Expression.Variable(memberInit.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        this.MemberInitNextElement(observerNode, expressions, variables, target, memberInit, ifNull);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException($"{element}");
                    }
            }

            return target;
        }

        /// <summary>
        ///     Creates the node.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="node">The node.</param>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        private SubObserverNode CreateNode(ObserverNodeBase observerNode, IExpressionNode node, Expression source)
        {
            using var debug = DebugExtensions.DebugMethod();
            var newObserverNode = new SubObserverNode(observerNode, node);

            var body = this.CreateValueBody(newObserverNode, typeof(object), node);
            var lambda = Expression.Lambda<Func<object>>(body);
            newObserverNode.Getter = () => lambda.Compile()();

            if (node.Parameter == null)
            {
                debug.WriteLine("CreateNode: ParameterNotes == null");
                return newObserverNode;
            }

            if (node.Type.IsValueType)
            {
                debug.WriteLine("CreateNode: Is Value Type");
                var returnTarget = Expression.Label(typeof(Nullable<>).MakeGenericType(node.Type));
                this.CreateValueBlock(
                    newObserverNode,
                    typeof(Nullable<>).MakeGenericType(node.Type),
                    node,
                    source,
                    returnTarget);
            }
            else
            {
                debug.WriteLine("CreateNode: Is Reference Type");
                var returnTarget = Expression.Label(node.Type);
                this.CreateValueBlock(newObserverNode, node.Type, node, source, returnTarget);
            }

            debug.WriteLine($"CreateNode: Add {newObserverNode} to {observerNode}");
            observerNode.AddChild(newObserverNode);
            return newObserverNode;
        }

        /// <summary>
        ///     Creates the variable inner expressions.
        /// </summary>
        /// <param name="observerNode">The observer node.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="node">The node.</param>
        /// <param name="source">The source.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns></returns>
        private Expression CreateVariableInnerExpressions(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression source,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            List<IExpressionNode> list = new();
            var i = 0;
            while (true)
            {
                Debug.WriteLine(
                    $"CreateVariableInnerExpressions Walk down {i} - {node.GetType().Name} - {node.Type.Name}");

                if (i > 0 && node is IPropertyNode property && node.ParameterNotes != null
                    && node.Parameter.Type.Implements<INotifyPropertyChanged>())
                {
                    debug.WriteLine(
                        $"INotifyPropertyChanged - {node.GetType().Name} - Property:{property.PropertyInfo.Name} as {node.Type.Name}");
                    this.CreateNode(observerNode, node, Expression.Parameter(node.Parameter.Type));
                    break;
                }

                list.Insert(0, node);

                if (node.Parameter == null)
                {
                    break;
                }

                node = node.Parameter;
                i++;
            }

            i = 0;
            Expression target = source;
            var element = list.First();

            var count = list.Count;
            for (; i < count - 1; i++)
            {
                element = list[i];
                debug.WriteLine(
                    $"CreateVariableInnerExpressions Walk up {i} - {element.GetType().Name} - {element.Type.Name}");

                //if (typeof(INotifyPropertyChanged).IsAssignableFrom(element.ParameterNotes.Type))
                //{
                //}
                var name = $"value{variables.GetNextIndex()}";
                Debug.WriteLine($"{name} - {element.Type}");

                var p = Expression.Variable(element.Type, name);
                variables.Add(p);
                target = p;
                this.InsertExpression(observerNode, expressions, variables, source, element, ifNull, p);
                source = target;
            }


            return target;
        }

        /// <summary>
        ///     Function last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="function">The function.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void FunctionLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            [NotNull] IFunctionNode function,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        this.FunctionMakeExpression(observerNode, expressions, variables, function, ifNull),
                        resultType)));
        }

        /// <summary>
        ///     Function make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="function">The function.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression FunctionMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IFunctionNode function,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var args = function.Parameters.Select(
                    functionParameter => this.CreateVariableExpressions(
                        observerNode,
                        expressions,
                        variables,
                        functionParameter,
                        ifNull))
                .ToList();

            return Expression.Call(function.MethodInfo, args);
        }

        /// <summary>
        ///     Function next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="function">The function.</param>
        /// <param name="ifNull">If null.</param>
        private void FunctionNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            [NotNull] IFunctionNode function,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    this.FunctionMakeExpression(observerNode, expressions, variables, function, ifNull)));

            if (!function.Type.IsValueType || function.Type.IsNullable())
            {
                expressions.Add(
                    Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(function.Type)), ifNull));
            }
        }

        /// <summary>
        ///     Insert end value expression.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="source">The source.</param>
        /// <param name="node">The node.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supported Expression Tree Node type.</exception>
        private void InsertEndValueExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression source,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            switch (node)
            {
                case IMethodNode method:
                    this.MethodLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        method,
                        ifNull,
                        returnTarget);
                    break;

                case IIndexerNode indexer:
                    this.IndexerLastElement(
                        observerNode,
                        expressions,
                        variables,
                        resultType,
                        indexer,
                        ifNull,
                        returnTarget);
                    break;

                case IPropertyNode property:
                    if (property is PropertyNode propertyNode)
                    {
                        HelperPropertyLastElement(
                            observerNode,
                            expressions,
                            variables,
                            source,
                            resultType,
                            propertyNode,
                            ifNull,
                            returnTarget);
                        break;
                    }

                    PropertyLastElement(
                        observerNode,
                        expressions,
                        variables,
                        source,
                        resultType,
                        property,
                        ifNull,
                        returnTarget);
                    break;

                case IFieldNode field:
                    FieldLastElement(observerNode, expressions, source, resultType, field, returnTarget);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{node}");
            }
        }

        /// <summary>
        ///     Insert expression.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="source">The source.</param>
        /// <param name="node">The node.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="target">The target.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supported Expression Tree Node type.</exception>
        private void InsertExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression source,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] Expression target)
        {
            using var debug = DebugExtensions.DebugMethod();
            switch (node)
            {
                case IParameterNode parameter:
                    ParameterNextElement(observerNode, expressions, target, parameter, ifNull);
                    break;

                case IConstantNode constant:
                    ConstantNextElement(observerNode, expressions, target, constant, ifNull);
                    break;

                case IFunctionNode function:
                    this.FunctionNextElement(observerNode, expressions, variables, target, function, ifNull);
                    break;

                case IMethodNode method:
                    this.MethodNextElement(observerNode, expressions, variables, target, method, ifNull);
                    break;

                case IIndexerNode indexer:
                    this.IndexerNextElement(observerNode, expressions, variables, target, indexer, ifNull);
                    break;

                case IPropertyNode property:
                    if (property is PropertyNode propertyNode)
                    {
                        HelperPropertyNextElement(
                            observerNode,
                            expressions,
                            source,
                            target,
                            property,
                            propertyNode.NodeType,
                            ifNull);
                        break;
                    }

                    PropertyNextElement(observerNode, expressions, source, target, property, ifNull);
                    break;

                case IFieldNode field:
                    FieldNextElement(observerNode, expressions, source, target, field, ifNull);
                    break;

                case IBinaryNode binary:
                    this.BinaryNextElement(observerNode, expressions, variables, target, binary, ifNull);
                    break;

                case IUnaryNode unary:
                    this.UnaryNextElement(observerNode, expressions, variables, target, unary, ifNull);
                    break;

                case IConditionalNode conditional:
                    this.ConditionalNextElement(observerNode, expressions, variables, target, conditional, ifNull);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{node}");
            }
        }

        /// <summary>
        ///     Member initialize make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="memberInit">The member initialize.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression MemberInitMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IMemberInitNode memberInit,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var args = memberInit.Parameters.Select(
                    argument => this.CreateVariableExpressions(observerNode, expressions, variables, argument, ifNull))
                .ToList();
            var bindings = memberInit.Bindings.Select(
                binding => this.CreateBindingExpressions(observerNode, expressions, variables, binding, ifNull));
            return Expression.MemberInit(
                Expression.New(memberInit.MemberInitExpression.NewExpression.Constructor, args),
                bindings);
        }

        /// <summary>
        ///     Member initialize next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="memberInit">The member initialize.</param>
        /// <param name="ifNull">If null.</param>
        private void MemberInitNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            [NotNull] IMemberInitNode memberInit,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    this.MemberInitMakeExpression(observerNode, expressions, variables, memberInit, ifNull)));

            if (memberInit.Type.IsValueType && !memberInit.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(memberInit.Type)), ifNull));
        }

        /// <summary>
        ///     Method last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="method">The method.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void MethodLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            [NotNull] IMethodNode method,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        this.MethodMakeExpression(observerNode, expressions, variables, method, ifNull),
                        resultType)));
        }

        /// <summary>
        ///     Indexer last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="indexer">The indexer.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void IndexerLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            [NotNull] IIndexerNode indexer,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        this.IndexerMakeExpression(observerNode, expressions, variables, indexer, ifNull),
                        resultType)));
        }

        /// <summary>
        ///     Method make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="method">The method.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression MethodMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IMethodNode method,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var @object = this.CreateVariableExpressions(observerNode, expressions, variables, method.Object, ifNull);

            var args = method.Arguments.Select(
                    argument => this.CreateVariableExpressions(observerNode, expressions, variables, argument, ifNull))
                .ToList();

            return Expression.Call(@object, method.MethodInfo, args);
        }

        /// <summary>
        ///     Indexer make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="indexer">The indexer.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns></returns>
        [NotNull]
        private Expression IndexerMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IIndexerNode indexer,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var @object = this.CreateVariableExpressions(observerNode, expressions, variables, indexer.Object, ifNull);

            var args = indexer.Arguments.Select(
                    argument => this.CreateVariableExpressions(observerNode, expressions, variables, argument, ifNull))
                .ToList();

            return Expression.Call(@object, indexer.MethodInfo, args);
        }

        /// <summary>
        ///     Method next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="method">The method.</param>
        /// <param name="ifNull">If null.</param>
        private void MethodNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            [NotNull] IMethodNode method,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    this.MethodMakeExpression(observerNode, expressions, variables, method, ifNull)));

            if (method.Type.IsValueType && !method.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(method.Type)), ifNull));
        }

        /// <summary>
        ///     Indexer next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="indexer">The indexer.</param>
        /// <param name="ifNull">If null.</param>
        private void IndexerNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            [NotNull] IIndexerNode indexer,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    this.IndexerMakeExpression(observerNode, expressions, variables, indexer, ifNull)));

            if (indexer.Type.IsValueType && !indexer.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(indexer.Type)), ifNull));
        }

        /// <summary>
        ///     Unary last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="unary">The unary.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private void UnaryLastElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            [NotNull] IUnaryNode unary,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        this.UnaryMakeExpression(observerNode, expressions, variables, unary, ifNull),
                        resultType)));
        }

        /// <summary>
        ///     Unary make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="unary">The unary.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private Expression UnaryMakeExpression(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IUnaryNode unary,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            var operand = this.CreateVariableExpressions(observerNode, expressions, variables, unary.Operand, ifNull);
            return Expression.MakeUnary(unary.UnaryExpression.NodeType, operand, unary.Type);
        }

        /// <summary>
        ///     Unary next element.
        /// </summary>
        /// <param name="observerNode"></param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="target">The target.</param>
        /// <param name="unary">The unary.</param>
        /// <param name="ifNull">If null.</param>
        private void UnaryNextElement(
            [NotNull] ObserverNodeBase observerNode,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression target,
            [NotNull] IUnaryNode unary,
            [NotNull] Expression ifNull)
        {
            using var debug = DebugExtensions.DebugMethod();
            expressions.Add(
                Expression.Assign(
                    target,
                    this.UnaryMakeExpression(observerNode, expressions, variables, unary, ifNull)));

            if (unary.Type.IsValueType && !unary.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(unary.Type)), ifNull));
        }
    }
}