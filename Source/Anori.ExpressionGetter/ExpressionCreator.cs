﻿// -----------------------------------------------------------------------
// <copyright file="ExpressionCreator.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.Extensions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Expression Creator.
    /// </summary>
    internal static class ExpressionCreator
    {
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
        ///     Creates the parameter body.
        /// </summary>
        /// <param name="resultParameter">The result parameter.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        internal static Expression CreateParameterBody(IParameterNode resultParameter)
        {
            var body = resultParameter.Expression;
            return body;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The block expression.
        /// </returns>
        [NotNull]
        internal static BlockExpression CreateValueBody(
            [NotNull] Type resultType,
            [NotNull] LambdaExpression expression,
            [NotNull] Expression fallback)
        {
            var returnTarget = Expression.Label(resultType);
            var tree = ExpressionTree.New(expression);
            var body = CreateValueBlock(resultType, tree, returnTarget, fallback);
            return body;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     The block expression.
        /// </returns>
        [NotNull]
        internal static BlockExpression CreateValueBody(
            [NotNull] Type resultType,
            [NotNull] LambdaExpression expression)
        {
            var returnTarget = Expression.Label(resultType);
            var tree = ExpressionTree.New(expression);
            var body = CreateValueBlock(resultType, tree, returnTarget);
            return body;
        }

        /// <summary>
        ///     Creates the value body.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressionTree">The tree.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        internal static BlockExpression CreateValueBody(
            [NotNull] Type resultType,
            [NotNull] IExpressionTree expressionTree)
        {
            var returnTarget = Expression.Label(resultType);
            var body = CreateValueBlock(resultType, expressionTree, returnTarget);
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
        internal static BlockExpression CreateValueBody(
            [NotNull] Type resultType,
            [NotNull] IExpressionTree expressionTree,
            [NotNull] Expression fallback)
        {
            var returnTarget = Expression.Label(resultType);
            var body = CreateValueBlock(resultType, expressionTree, returnTarget, fallback);
            return body;
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
        private static Expression BinaryMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IBinaryNode binary,
            [NotNull] Expression ifNull)
        {
            switch (binary.BinaryExpression.NodeType)
            {
                case ExpressionType.OrElse:
                    {
                        var right = new List<Expression>();
                        right.Add(
                            Expression.Condition(
                                CreateVariableExpressions(right, variables, binary.RightNode, ifNull),
                                TrueConstantExpression,
                                FalseConstantExpression));

                        var left = new List<Expression>();
                        left.Add(
                            Expression.Condition(
                                CreateVariableExpressions(left, variables, binary.LeftNode, ifNull),
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
                                CreateVariableExpressions(right, variables, binary.RightNode, ifNull),
                                TrueConstantExpression,
                                FalseConstantExpression));

                        var left = new List<Expression>();
                        left.Add(
                            Expression.Condition(
                                CreateVariableExpressions(left, variables, binary.LeftNode, ifNull),
                                Expression.Block(right),
                                FalseConstantExpression));

                        var block = Expression.Block(left);
                        return block;
                    }

                case ExpressionType.Coalesce:
                    {
                        var lable = Expression.Label();
                        var right = new List<Expression>();
                        right.Add(CreateVariableExpressions(right, variables, binary.RightNode, ifNull));
                        var rightBlock = Expression.Block(right);
                        var left = new List<Expression>();
                        var coalesce = Expression.Coalesce(
                            CreateVariableExpressions(left, variables, binary.LeftNode, Expression.Goto(lable)),
                            rightBlock);
                        left.Add(Expression.Label(lable));
                        left.Add(coalesce);

                        var block = Expression.Block(left);
                        return block;
                    }

                default:
                    {
                        var left = CreateVariableExpressions(expressions, variables, binary.LeftNode, ifNull);
                        var right = CreateVariableExpressions(expressions, variables, binary.RightNode, ifNull);
                        return Expression.MakeBinary(binary.BinaryExpression.NodeType, left, right);
                    }
            }
        }

        /// <summary>
        ///     Binaries the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="target">The target.</param>
        /// <param name="binary">The binary.</param>
        /// <param name="ifNull">If null.</param>
        private static void BinaryNextElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression target,
            IBinaryNode binary,
            [NotNull] Expression ifNull)
        {
            expressions.Add(Expression.Assign(target, BinaryMakeExpression(expressions, variables, binary, ifNull)));

            if (binary.Type.IsValueType && !binary.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(binary.Type)), ifNull));
        }

        /// <summary>
        ///     Bineries the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="binary">The binary.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void BineryLastElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            IBinaryNode binary,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(BinaryMakeExpression(expressions, variables, binary, ifNull), resultType)));

        /// <summary>
        ///     Conditionals the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="conditional">The conditional.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void ConditionalLastElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            in IConditionalNode conditional,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        ConditionalMakeExpression(expressions, variables, conditional, ifNull),
                        resultType)));

        /// <summary>
        ///     Conditionals the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="conditional">The conditional.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression ConditionalMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IConditionalNode conditional,
            [NotNull] Expression ifNull)
        {
            var test = CreateVariableExpressions(expressions, variables, conditional.Test, ifNull);

            var ifTrue = new List<Expression>();
            ifTrue.Add(CreateVariableExpressions(ifTrue, variables, conditional.IfTrue, ifNull));

            var ifFalse = new List<Expression>();
            ifFalse.Add(CreateVariableExpressions(ifFalse, variables, conditional.IfFalse, ifNull));

            return Expression.Condition(test, Expression.Block(ifTrue), Expression.Block(ifFalse));
        }

        /// <summary>
        ///     Conditionals the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="target">The target.</param>
        /// <param name="conditional">The conditional.</param>
        /// <param name="ifNull">If null.</param>
        private static void ConditionalNextElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression target,
            IConditionalNode conditional,
            [NotNull] Expression ifNull)
        {
            expressions.Add(
                Expression.Assign(target, ConditionalMakeExpression(expressions, variables, conditional, ifNull)));

            if (conditional.Type.IsValueType && !conditional.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(conditional.Type)), ifNull));
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
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Type resultType,
            IConstantNode constant,
            Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
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
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression targetParameter,
            IConstantNode constant,
            [NotNull] Expression ifExpression)
        {
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
        ///     Constructors the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression ConstructorMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IConstructorNode constructor,
            [NotNull] Expression ifNull)
        {
            var args = constructor.Parameters
                .Select(argument => CreateVariableExpressions(expressions, variables, argument, ifNull))
                .ToList();

            return Expression.New(constructor.Constructor, args);
        }

        /// <summary>
        ///     Constructors the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="ifNull">If null.</param>
        private static void ConstructorNextElement(
            IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            IConstructorNode constructor,
            [NotNull] Expression ifNull)
        {
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    ConstructorMakeExpression(expressions, variables, constructor, ifNull)));

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
        /// <exception cref="ArgumentOutOfRangeException">Not supportet Expression Tree Node type.</exception>
        [NotNull]
        private static MemberBinding CreateBindingExpressions(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IBindingNode binding,
            [NotNull] Expression ifNull)
        {
            switch (binding)
            {
                case IMemberAssignmentNode memberAssignment:
                    {
                        var expression = CreateVariableExpressions(
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
                                var expression = CreateVariableExpressions(
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
                            s => CreateBindingExpressions(expressions, variables, s, ifNull));
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
        private static BlockExpression CreateValueBlock(
            [NotNull] Type resultType,
            [NotNull] IExpressionTree tree,
            [NotNull] LabelTarget returnTarget)
        {
            var expressions = new List<Expression>();
            var variables = new VariablesCollection();
            var ifNull = Expression.Return(returnTarget, NullExpressionOf(resultType));

            CreateValueExpressions(resultType, tree.Head, expressions, variables, ifNull, returnTarget);

            expressions.Add(Expression.Label(returnTarget, NullExpressionOf(resultType)));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        ///     Creates the value block.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="tree">The tree.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static BlockExpression CreateValueBlock(
            [NotNull] Type resultType,
            [NotNull] IExpressionTree tree,
            [NotNull] LabelTarget returnTarget,
            [NotNull] Expression fallback)
        {
            var expressions = new List<Expression>();
            var variables = new VariablesCollection();
            var ifNull = Expression.Return(returnTarget, fallback);

            CreateValueExpressions(resultType, tree.Head, expressions, variables, ifNull, returnTarget);

            expressions.Add(Expression.Label(returnTarget, fallback));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        ///     Creates the value chain expressions.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="node">The tree.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void CreateValueChainExpressions(
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            var target = CreateVariableInnerExpressions(expressions, variables, node, ifNull);
            InsertEndValueExpression(resultType, expressions, variables, target, node, ifNull, returnTarget);
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
        private static void CreateValueExpressions(
            [NotNull] Type resultType,
            [NotNull] IExpressionNode node,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            if (node.Previous == null)

            {
                CreateValueSingleExpressions(resultType, expressions, variables, node, ifNull, returnTarget);
            }
            else
            {
                CreateValueChainExpressions(resultType, expressions, variables, node, ifNull, returnTarget);
            }
        }

        /// <summary>
        ///     Creates the value single expressions.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The tree.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supported Expression Tree Node type.</exception>
        private static void CreateValueSingleExpressions(
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            var element = node;
            switch (element)
            {
                case IFunctionNode function:
                    FunctionLastElement(expressions, variables, resultType, function, ifNull, returnTarget);
                    break;

                case IConstantNode constant:
                    ConstantLastElement(expressions, resultType, constant, ifNull, returnTarget);
                    break;

                case IParameterNode parameter:
                    ParameterLastElement(expressions, resultType, parameter, returnTarget);
                    break;

                case IMethodNode method:
                    MethodLastElement(expressions, variables, resultType, method, ifNull, returnTarget);
                    break;

                case IIndexerNode indexer:
                    IndexerLastElement(expressions, variables, resultType, indexer, ifNull, returnTarget);
                    break;

                case IBinaryNode binary:
                    BineryLastElement(expressions, variables, resultType, binary, ifNull, returnTarget);
                    break;

                case IUnaryNode unary:
                    UnaryLastElement(expressions, variables, resultType, unary, ifNull, returnTarget);
                    break;

                case IConditionalNode conditional:
                    ConditionalLastElement(expressions, variables, resultType, conditional, ifNull, returnTarget);
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
        private static Expression CreateVariableExpressions(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull)
        {
            var source = CreateVariableInnerExpressions(expressions, variables, node, ifNull);
            if (node.Previous == null)
            {
                return source;
            }

            var target = Expression.Variable(node.Type, $"value{variables.GetNextIndex()}");
            variables.Add(target);
            InsertExpression(expressions, variables, source, node, ifNull, target);
            return target;
        }

        /// <summary>
        ///     Creates the variable inner expressions.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The tree.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Not supported element type.</exception>
        private static Expression CreateVariableInnerExpressions(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull)
        {
            List<IExpressionNode> list = new List<IExpressionNode>();
            while (true)
            {
                list.Insert(0, node);
                if (node.Previous == null)
                {
                    break;
                }

                //if(!(node is IPropertyNode
                //    || node is IParameterNode
                //    || node is IFieldNode
                //    || node is IBinaryNode
                //    || node is IUnaryNode
                //    || node is IMethodNode
                //    || node is IConstantNode
                //    || node is IConditionalNode
                //    || node is IFunctionNode
                //    || node is IConstructorNode
                //    || node is IMemberInitNode
                //    || node is IIndexerNode))
                //{
                //    break;
                //}
                node = node.Previous;
            }

            var i = 1;
            Expression target;
            var element = list.First();
            switch (element)
            {
                case IParameterNode parameter:
                    {
                        var p = parameter.Expression;
                        target = p;
                        ParameterNextElement(expressions, target, parameter, ifNull);
                        break;
                    }

                case IConstantNode constant:
                    {
                        target = constant.Expression;
                        break;
                    }

                case IMethodNode method:
                    {
                        var p = Expression.Variable(method.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        MethodNextElement(expressions, variables, target, method, ifNull);
                        break;
                    }

                case IIndexerNode indexer:
                    {
                        var p = Expression.Variable(indexer.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        IndexerNextElement(expressions, variables, target, indexer, ifNull);
                        break;
                    }

                case IConstructorNode constructor:
                    {
                        var p = Expression.Variable(constructor.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        ConstructorNextElement(expressions, variables, target, constructor, ifNull);
                        break;
                    }

                case IFunctionNode function:
                    {
                        var p = Expression.Variable(function.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        FunctionNextElement(expressions, variables, target, function, ifNull);
                        break;
                    }

                case IBinaryNode binary:
                    {
                        var p = Expression.Variable(binary.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        BinaryNextElement(expressions, variables, target, binary, ifNull);
                        break;
                    }

                case IUnaryNode unary:
                    {
                        var p = Expression.Variable(unary.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        UnaryNextElement(expressions, variables, target, unary, ifNull);
                        break;
                    }

                case IConditionalNode conditional:
                    {
                        var p = Expression.Variable(conditional.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        ConditionalNextElement(expressions, variables, target, conditional, ifNull);
                        break;
                    }

                case IMemberInitNode memberInit:
                    {
                        var p = Expression.Variable(memberInit.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        MemberInitNextElement(expressions, variables, target, memberInit, ifNull);
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException($"{element}");
                    }
            }

            var count = list.Count;
            if (count == 1)
            {
                return target;
            }

            var source = target;
            for (; i < count - 1; i++)
            {
                element = list[i];
                var p = Expression.Variable(element.Type, $"value{variables.GetNextIndex()}");
                variables.Add(p);
                target = p;
                InsertExpression(expressions, variables, source, element, ifNull, p);
                source = target;
            }

            return target;
        }

        /// <summary>
        ///     Fields the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="field">The field.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void FieldLastElement(
            [NotNull] ICollection<Expression> expressions,
            Expression sourceParameter,
            [NotNull] Type resultType,
            IFieldNode field,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(Expression.Field(sourceParameter, field.FieldInfo), resultType)));

        /// <summary>
        ///     Fields the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="field">The field.</param>
        /// <param name="ifExpression">If expression.</param>
        private static void FieldNextElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Expression targetParameter,
            IFieldNode field,
            [NotNull] Expression ifExpression)
        {
            expressions.Add(Expression.Assign(targetParameter, Expression.Field(sourceParameter, field.FieldInfo)));

            if (field.Type.IsValueType && !field.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(field.Type)), ifExpression));
        }

        /// <summary>
        ///     Functions the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="function">The function.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void FunctionLastElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            IFunctionNode function,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(FunctionMakeExpression(expressions, variables, function, ifNull), resultType)));

        /// <summary>
        ///     Functions the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="function">The function.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression FunctionMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IFunctionNode function,
            [NotNull] Expression ifNull)
        {
            var args = function.Parameters.Select(
                    functionParameter => CreateVariableExpressions(
                        expressions,
                        variables,
                        functionParameter,
                        ifNull))
                .ToList();

            return Expression.Call(function.MethodInfo, args);
        }

        /// <summary>
        ///     Functions the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="function">The function.</param>
        /// <param name="ifNull">If null.</param>
        private static void FunctionNextElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            IFunctionNode function,
            [NotNull] Expression ifNull)
        {
            expressions.Add(
                Expression.Assign(targetParameter, FunctionMakeExpression(expressions, variables, function, ifNull)));

            if (!function.Type.IsValueType || function.Type.IsNullable())
            {
                expressions.Add(
                    Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(function.Type)), ifNull));
            }
        }

        /// <summary>
        ///     Inserts the end value expression.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="source">The source.</param>
        /// <param name="node">The node.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supportet Expression Tree Node type.</exception>
        private static void InsertEndValueExpression(
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression source,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            switch (node)
            {
                case IMethodNode method:
                    MethodLastElement(expressions, variables, resultType, method, ifNull, returnTarget);
                    break;

                case IIndexerNode indexer:
                    IndexerLastElement(expressions, variables, resultType, indexer, ifNull, returnTarget);
                    break;

                case IPropertyNode property:
                    PropertyLastElement(expressions, variables, source, resultType, property, ifNull, returnTarget);
                    break;

                case IFieldNode field:
                    FieldLastElement(expressions, source, resultType, field, returnTarget);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{node}");
            }
        }

        /// <summary>
        ///     Inserts the expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="source">The source.</param>
        /// <param name="node">The node.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="target">The target.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supportet Expression Tree Node type.</exception>
        private static void InsertExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression source,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] Expression target)
        {
            switch (node)
            {
                case IParameterNode parameter:
                    ParameterNextElement(expressions, target, parameter, ifNull);
                    break;

                case IConstantNode constant:
                    ConstantNextElement(expressions, target, constant, ifNull);
                    break;

                case IFunctionNode function:
                    FunctionNextElement(expressions, variables, target, function, ifNull);
                    break;

                case IMethodNode method:
                    MethodNextElement(expressions, variables, target, method, ifNull);
                    break;

                case IIndexerNode indexer:
                    IndexerNextElement(expressions, variables, target, indexer, ifNull);
                    break;

                case IPropertyNode property:
                    PropertyNextElement(expressions, source, target, property, ifNull);
                    break;

                case IFieldNode field:
                    FieldNextElement(expressions, source, target, field, ifNull);
                    break;

                case IBinaryNode binary:
                    BinaryNextElement(expressions, variables, target, binary, ifNull);
                    break;

                case IUnaryNode unary:
                    UnaryNextElement(expressions, variables, target, unary, ifNull);
                    break;

                case IConditionalNode conditional:
                    ConditionalNextElement(expressions, variables, target, conditional, ifNull);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{node}");
            }
        }

        /// <summary>
        ///     Members the initialize make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="memberInit">The member initialize.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression MemberInitMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IMemberInitNode memberInit,
            [NotNull] Expression ifNull)
        {
            var args = memberInit.Parameters
                .Select(argument => CreateVariableExpressions(expressions, variables, argument, ifNull))
                .ToList();
            var bindings = memberInit.Bindings.Select(
                binding => CreateBindingExpressions(expressions, variables, binding, ifNull));
            return Expression.MemberInit(
                Expression.New(memberInit.MemberInitExpression.NewExpression.Constructor, args),
                bindings);
        }

        /// <summary>
        ///     Members the initialize next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="memberInit">The member initialize.</param>
        /// <param name="ifNull">If null.</param>
        private static void MemberInitNextElement(
            IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            IMemberInitNode memberInit,
            [NotNull] Expression ifNull)
        {
            expressions.Add(
                Expression.Assign(
                    targetParameter,
                    MemberInitMakeExpression(expressions, variables, memberInit, ifNull)));

            if (memberInit.Type.IsValueType && !memberInit.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(memberInit.Type)), ifNull));
        }

        /// <summary>
        ///     Methods the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="method">The method.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void MethodLastElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            IMethodNode method,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(MethodMakeExpression(expressions, variables, method, ifNull), resultType)));

        private static void IndexerLastElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            IIndexerNode indexer,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(IndexerMakeExpression(expressions, variables, indexer, ifNull), resultType)));

        /// <summary>
        ///     Methods the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="method">The method.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression MethodMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IMethodNode method,
            [NotNull] Expression ifNull)
        {
            var @object = CreateVariableExpressions(expressions, variables, method.Object, ifNull);

            var args = method.Arguments
                .Select(argument => CreateVariableExpressions(expressions, variables, argument, ifNull))
                .ToList();

            return Expression.Call(@object, method.MethodInfo, args);
        }

        [NotNull]
        private static Expression IndexerMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IIndexerNode indexer,
            [NotNull] Expression ifNull)
        {
            var @object = CreateVariableExpressions(expressions, variables, indexer.Object, ifNull);

            var args = indexer.Arguments.Select(
                    argument => CreateVariableExpressions(expressions, variables, argument, ifNull))
                .ToList();

            return Expression.Call(@object, indexer.MethodInfo, args);
        }

        /// <summary>
        ///     Methods the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="method">The method.</param>
        /// <param name="ifNull">If null.</param>
        private static void MethodNextElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            IMethodNode method,
            [NotNull] Expression ifNull)
        {
            expressions.Add(
                Expression.Assign(targetParameter, MethodMakeExpression(expressions, variables, method, ifNull)));

            if (method.Type.IsValueType && !method.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(method.Type)), ifNull));
        }

        private static void IndexerNextElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression targetParameter,
            IIndexerNode indexer,
            [NotNull] Expression ifNull)
        {
            expressions.Add(
                Expression.Assign(targetParameter, IndexerMakeExpression(expressions, variables, indexer, ifNull)));

            if (indexer.Type.IsValueType && !indexer.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(indexer.Type)), ifNull));
        }

        /// <summary>
        ///     Nulls the expression of.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression NullExpressionOf([NotNull] Type type) => Expression.Constant(null, type);

        /// <summary>
        ///     Parameters the next parameter.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="ifExpression">If expression.</param>
        private static void ParameterNextElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression targetParameter,
            [NotNull] IExpressionNode parameter,
            [NotNull] Expression ifExpression)
        {
            if (parameter.Type.IsValueType && !parameter.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(parameter.Type)), ifExpression));
        }

        /// <summary>
        ///     Parameters the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void ParameterLastElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Type resultType,
            IParameterNode parameter,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(returnTarget, Expression.Convert(ParameterMakeExpression(parameter), resultType)));

        /// <summary>
        ///     Parameters the make expression.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression ParameterMakeExpression(IParameterNode parameter) => parameter.Expression;

        /// <summary>
        ///     Properties the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="property">The property.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void PropertyLastElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression sourceParameter,
            [NotNull] Type resultType,
            IPropertyNode property,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            if (property.Type.IsValueType && !property.Type.IsNullable())
            {
                expressions.Add(
                    Expression.Return(
                        returnTarget,
                        Expression.Convert(PropertyMakeExpression(sourceParameter, property), resultType)));
                return;
            }

            var p = Expression.Variable(resultType, $"value{variables.GetNextIndex()}");
            variables.Add(p);
            expressions.Add(Expression.Assign(p, PropertyMakeExpression(sourceParameter, property)));
            expressions.Add(Expression.IfThen(Expression.Equal(p, NullExpressionOf(property.Type)), ifNull));
            expressions.Add(Expression.Return(returnTarget, p));
        }

        /// <summary>
        ///     Properties the make expression.
        /// </summary>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="property">The property.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression
            PropertyMakeExpression([NotNull] Expression sourceParameter, IPropertyNode property) =>
            Expression.Call(sourceParameter, property.MethodInfo, property.Args);

        /// <summary>
        ///     Properties the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="property">The property.</param>
        /// <param name="ifNull">If null.</param>
        private static void PropertyNextElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Expression targetParameter,
            IPropertyNode property,
            [NotNull] Expression ifNull)
        {
            expressions.Add(Expression.Assign(targetParameter, PropertyMakeExpression(sourceParameter, property)));

            if (property.Type.IsValueType && !property.Type.IsNullable())
            {
                return;
            }

            expressions.Add(
                Expression.IfThen(Expression.Equal(targetParameter, NullExpressionOf(property.Type)), ifNull));
        }

        /// <summary>
        ///     Unaries the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="unary">The unary.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void UnaryLastElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Type resultType,
            IUnaryNode unary,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(UnaryMakeExpression(expressions, variables, unary, ifNull), resultType)));

        /// <summary>
        ///     Unaries the make expression.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="unary">The unary.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression UnaryMakeExpression(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            IUnaryNode unary,
            [NotNull] Expression ifNull)
        {
            var operand = CreateVariableExpressions(expressions, variables, unary.Operand, ifNull);
            return Expression.MakeUnary(unary.UnaryExpression.NodeType, operand, unary.Type);
        }

        /// <summary>
        ///     Unaries the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="target">The target.</param>
        /// <param name="unary">The unary.</param>
        /// <param name="ifNull">If null.</param>
        private static void UnaryNextElement(
            [NotNull] IList<Expression> expressions,
            [NotNull] VariablesCollection variables,
            [NotNull] Expression target,
            IUnaryNode unary,
            [NotNull] Expression ifNull)
        {
            expressions.Add(Expression.Assign(target, UnaryMakeExpression(expressions, variables, unary, ifNull)));

            if (unary.Type.IsValueType && !unary.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(unary.Type)), ifNull));
        }
    }
}