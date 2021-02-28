// -----------------------------------------------------------------------
// <copyright file="ExpressionCreator.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Anori.ExpressionObservers.Nodes;
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
            [NotNull] Expression expression,
            [NotNull] Expression fallback)
        {
            var returnTarget = Expression.Label(resultType);
            var tree = ExpressionTree.GetTree(expression);
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
            [NotNull] Expression expression)
        {
            var returnTarget = Expression.Label(resultType);
            var tree = ExpressionTree.GetTree(expression);
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
            [NotNull] ExpressionTree expressionTree)
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
            [NotNull] ExpressionTree expressionTree,
            [NotNull] Expression fallback)
        {
            var returnTarget = Expression.Label(resultType);
            var body = CreateValueBlock(resultType, expressionTree, returnTarget, fallback);
            return body;
        }

        /// <summary>
        ///     Creates the parameter body.
        /// </summary>
        /// <param name="resultParameter">The result parameter.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        internal static Expression CreateParameterBody(ParameterNode resultParameter)
        {
            var body = resultParameter.Expression;
            return body;
        }

        /// <summary>
        ///     Nulls the expression of.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression NullExpressionOf([NotNull] Type type) => Expression.Constant(null, type);

        /// <summary>
        ///     Creates the value block.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <returns>The block expression.</returns>
        [NotNull]
        private static BlockExpression CreateValueBlock(
            [NotNull] Type resultType,
            [NotNull] ExpressionTree nodes,
            [NotNull] LabelTarget returnTarget)
        {
            var expressions = new List<Expression>();
            var variables = new VaribalesCollection();
            var ifNull = Expression.Return(returnTarget, NullExpressionOf(resultType));

            CreateValueExpressions(resultType, nodes.Nodes, expressions, variables, ifNull, returnTarget);

            expressions.Add(Expression.Label(returnTarget, NullExpressionOf(resultType)));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        ///     Creates the value block.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static BlockExpression CreateValueBlock(
            [NotNull] Type resultType,
            [NotNull] ExpressionTree nodes,
            [NotNull] LabelTarget returnTarget,
            [NotNull] Expression fallback)
        {
            var expressions = new List<Expression>();
            var variables = new VaribalesCollection();
            var ifNull = Expression.Return(returnTarget, fallback);

            CreateValueExpressions(resultType, nodes.Nodes, expressions, variables, ifNull, returnTarget);

            expressions.Add(Expression.Label(returnTarget, fallback));
            var body = Expression.Block(variables, expressions);
            return body;
        }

        /// <summary>
        ///     Creates the value expressions.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <exception cref="NotSupportedException">Not suppoerted node nubmers.</exception>
        private static void CreateValueExpressions(
            [NotNull] Type resultType,
            [NotNull] NodeCollection nodes,
            [NotNull] IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            switch (nodes.Count)
            {
                case 0:
                    throw new NotSupportedException();

                case 1:
                    CreateValueSingleExpressions(resultType, expressions, variables, nodes, ifNull, returnTarget);
                    break;

                default:
                    CreateValueChainExpressions(resultType, expressions, variables, nodes, ifNull, returnTarget);
                    break;
            }
        }

        /// <summary>
        ///     Creates the value chain expressions.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void CreateValueChainExpressions(
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] NodeCollection nodes,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            var target = CreateVariableInnerExpressions(expressions, variables, nodes, ifNull);
            InsertEndValueExpression(resultType, expressions, variables, target, nodes.First(), ifNull, returnTarget);
        }

        /// <summary>
        ///     Creates the variable expressions.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        private static Expression CreateVariableExpressions(
            [NotNull] IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] NodeCollection nodes,
            [NotNull] Expression ifNull)
        {
            var source = CreateVariableInnerExpressions(expressions, variables, nodes, ifNull);
            if (nodes.Count == 1)
            {
                return source;
            }

            var target = Expression.Variable(nodes.First().Type, $"value{variables.GetNextIndex()}");
            variables.Add(target);
            InsertExpression(expressions, variables, source, nodes.First(), ifNull, target);
            return target;
        }

        /// <summary>
        ///     Creates the variable inner expressions.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="ifNull">If null.</param>
        /// <returns>The expression.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Not supportet element type.</exception>
        private static Expression CreateVariableInnerExpressions(
            [NotNull] IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] NodeCollection nodes,
            [NotNull] Expression ifNull)
        {
            var list = nodes.ToList();
            list.Reverse();
            var i = 1;
            Expression target;
            var element = list.First();
            switch (element)
            {
                case ParameterNode parameter:
                    {
                        var p = parameter.Expression;
                        target = p;
                        ParameterNextParameter(expressions, target, parameter, ifNull);
                        break;
                    }

                case ConstantNode constant:
                    target = constant.Expression;
                    break;

                case MethodNode method:
                    {
                        var p = Expression.Variable(method.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        MethodNextElement(expressions, variables, target, method, ifNull);
                        break;
                    }

                case ConstructorNode constructor:
                    {
                        var p = Expression.Variable(constructor.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        ConstructorNextElement(expressions, variables, target, constructor, ifNull);
                        break;
                    }

                case FunctionNode function:
                    {
                        var p = Expression.Variable(function.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        FunctionNextElement(expressions, variables, target, function, ifNull);
                        break;
                    }

                case BinaryNode binary:
                    {
                        var p = Expression.Variable(binary.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        BinaryNextElement(expressions, variables, target, binary, ifNull);
                        break;
                    }

                case UnaryNode unary:
                    {
                        var p = Expression.Variable(unary.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        UnaryNextElement(expressions, variables, target, unary, ifNull);
                        break;
                    }

                case ConditionalNode conditional:
                    {
                        var p = Expression.Variable(conditional.Type, $"value{variables.GetNextIndex()}");
                        target = p;
                        variables.Add(p);
                        ConditionalNextElement(expressions, variables, target, conditional, ifNull);
                        break;
                    }

                case MemberInitNode memberInit:
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
        ///     Members the initialize next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="memberInit">The member initialize.</param>
        /// <param name="ifNull">If null.</param>
        private static void MemberInitNextElement(
            IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression targetParameter,
            MemberInitNode memberInit,
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
            [NotNull] VaribalesCollection variables,
            MemberInitNode memberInit,
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
            [NotNull] VaribalesCollection variables,
            [NotNull] IBindingNode binding,
            [NotNull] Expression ifNull)
        {
            switch (binding)
            {
                case MemberAssignmentNode memberAssignment:
                    {
                        var expression = CreateVariableExpressions(
                            expressions,
                            variables,
                            memberAssignment.Nodes,
                            ifNull);
                        return Expression.Bind(memberAssignment.Binding.Member, expression);
                    }

                case MemberListBindingNode memberListBinding:
                    {
                        var memberInitCollection = new List<ElementInit>();
                        foreach (var initializer in memberListBinding.Initializers)
                        {
                            var args = new List<Expression>();
                            foreach (var argument in initializer.Arguments)
                            {
                                var expression = CreateVariableExpressions(expressions, variables, argument, ifNull);
                                args.Add(expression);
                            }

                            memberInitCollection.Add(Expression.ElementInit(initializer.ElementInit.AddMethod, args));
                        }

                        return Expression.ListBind(memberListBinding.Binding.Member, memberInitCollection);
                    }

                case MemberMemberBindingNode memberMemberBindingElement:
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
        ///     Constructors the next element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="ifNull">If null.</param>
        private static void ConstructorNextElement(
            IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression targetParameter,
            ConstructorNode constructor,
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression source,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            switch (node)
            {
                case MethodNode method:
                    MethodLastElement(expressions, variables, resultType, method, ifNull, returnTarget);
                    break;

                case PropertyNode property:
                    PropertyLastElement(expressions, source, resultType, property, returnTarget);
                    break;

                case FieldNode field:
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression source,
            [NotNull] IExpressionNode node,
            [NotNull] Expression ifNull,
            [NotNull] Expression target)
        {
            switch (node)
            {
                case ParameterNode parameter:
                    ParameterNextParameter(expressions, target, parameter, ifNull);
                    break;

                case ConstantNode constant:
                    ConstantNextElement(expressions, target, constant, ifNull);
                    break;

                case FunctionNode function:
                    FunctionNextElement(expressions, variables, target, function, ifNull);
                    break;

                case MethodNode method:
                    MethodNextElement(expressions, variables, target, method, ifNull);
                    break;

                case PropertyNode property:
                    PropertyNextElement(expressions, source, target, property, ifNull);
                    break;

                case FieldNode field:
                    FieldNextElement(expressions, source, target, field, ifNull);
                    break;

                case BinaryNode binary:
                    BinaryNextElement(expressions, variables, target, binary, ifNull);
                    break;

                case UnaryNode unary:
                    UnaryNextElement(expressions, variables, target, unary, ifNull);
                    break;

                case ConditionalNode conditional:
                    ConditionalNextElement(expressions, variables, target, conditional, ifNull);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{node}");
            }
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
            FieldNode field,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(Expression.Field(sourceParameter, field.FieldInfo), resultType)));

        /// <summary>
        ///     Creates the value single expressions.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="variables">The variables.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="ifNull">If null.</param>
        /// <param name="returnTarget">The return target.</param>
        /// <exception cref="ArgumentOutOfRangeException">Not supportet Expression Tree Node type.</exception>
        private static void CreateValueSingleExpressions(
            [NotNull] Type resultType,
            [NotNull] IList<Expression> expressions,
            [NotNull] VaribalesCollection variables,
            [NotNull] NodeCollection nodes,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget)
        {
            var element = nodes.First();
            switch (element)
            {
                case FunctionNode function:
                    FunctionLastElement(expressions, variables, resultType, function, ifNull, returnTarget);
                    break;

                case ConstantNode constant:
                    ConstantLastElement(expressions, resultType, constant, returnTarget);
                    break;

                case ParameterNode parameter:
                    ParametertLastElement(expressions, resultType, parameter, returnTarget);
                    break;

                case MethodNode method:
                    MethodLastElement(expressions, variables, resultType, method, ifNull, returnTarget);
                    break;

                case BinaryNode binary:
                    BineryLastElement(expressions, variables, resultType, binary, ifNull, returnTarget);
                    break;

                case UnaryNode unary:
                    UnaryLastElement(expressions, variables, resultType, unary, ifNull, returnTarget);
                    break;

                case ConditionalNode conditional:
                    ConditionalLastElement(expressions, variables, resultType, conditional, ifNull, returnTarget);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"{element}");
            }
        }

        /// <summary>
        ///     Constants the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="constant">The constant.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void ConstantLastElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Type resultType,
            ConstantNode constant,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(Expression.Return(returnTarget, Expression.Constant(constant.Value, resultType)));

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
            ConstantNode constant,
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
        ///     Parameterts the make expression.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression ParametertMakeExpression(ParameterNode parameter) => parameter.Expression;

        /// <summary>
        ///     Parameterts the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void ParametertLastElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Type resultType,
            ParameterNode parameter,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(returnTarget, Expression.Convert(ParametertMakeExpression(parameter), resultType)));

        /// <summary>
        ///     Parameters the next parameter.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="targetParameter">The target parameter.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="ifExpression">If expression.</param>
        private static void ParameterNextParameter(
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
            FieldNode field,
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
        ///     Properties the make expression.
        /// </summary>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="property">The property.</param>
        /// <returns>The expression.</returns>
        [NotNull]
        private static Expression PropertyMakeExpression([NotNull] Expression sourceParameter, PropertyNode property) =>
            Expression.Call(sourceParameter, property.MethodInfo, property.Args);

        /// <summary>
        ///     Properties the last element.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        /// <param name="sourceParameter">The source parameter.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="property">The property.</param>
        /// <param name="returnTarget">The return target.</param>
        private static void PropertyLastElement(
            [NotNull] ICollection<Expression> expressions,
            [NotNull] Expression sourceParameter,
            [NotNull] Type resultType,
            PropertyNode property,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(PropertyMakeExpression(sourceParameter, property), resultType)));

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
            PropertyNode property,
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
            [NotNull] VaribalesCollection variables,
            ConstructorNode constructor,
            [NotNull] Expression ifNull)
        {
            var args = constructor.Parameters
                .Select(argument => CreateVariableExpressions(expressions, variables, argument, ifNull))
                .ToList();

            return Expression.New(constructor.Constructor, args);
        }

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
            [NotNull] VaribalesCollection variables,
            MethodNode method,
            [NotNull] Expression ifNull)
        {
            var @object = CreateVariableExpressions(expressions, variables, method.Object, ifNull);

            var args = method.Arguments
                .Select(argument => CreateVariableExpressions(expressions, variables, argument, ifNull))
                .ToList();

            return Expression.Call(@object, method.MethodInfo, args);
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Type resultType,
            MethodNode method,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(MethodMakeExpression(expressions, variables, method, ifNull), resultType)));

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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression targetParameter,
            MethodNode method,
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Type resultType,
            in ConditionalNode conditional,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(
                        ConditionalMakeExpression(expressions, variables, conditional, ifNull),
                        resultType)));

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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression target,
            ConditionalNode conditional,
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
            [NotNull] VaribalesCollection variables,
            ConditionalNode conditional,
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
            [NotNull] VaribalesCollection variables,
            UnaryNode unary,
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression target,
            UnaryNode unary,
            [NotNull] Expression ifNull)
        {
            expressions.Add(Expression.Assign(target, UnaryMakeExpression(expressions, variables, unary, ifNull)));

            if (unary.Type.IsValueType && !unary.Type.IsNullable())
            {
                return;
            }

            expressions.Add(Expression.IfThen(Expression.Equal(target, NullExpressionOf(unary.Type)), ifNull));
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Type resultType,
            UnaryNode unary,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(UnaryMakeExpression(expressions, variables, unary, ifNull), resultType)));

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
            [NotNull] VaribalesCollection variables,
            [NotNull] Type resultType,
            BinaryNode binary,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(BinaryMakeExpression(expressions, variables, binary, ifNull), resultType)));

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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression target,
            BinaryNode binary,
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
            [NotNull] VaribalesCollection variables,
            BinaryNode binary,
            [NotNull] Expression ifNull)
        {
            switch (binary.BinaryExpression.NodeType)
            {
                case ExpressionType.OrElse:
                    {
                        var right = new List<Expression>();
                        right.Add(
                            Expression.Condition(
                                CreateVariableExpressions(right, variables, binary.RightNodes, ifNull),
                                TrueConstantExpression,
                                FalseConstantExpression));

                        var left = new List<Expression>();
                        left.Add(
                            Expression.Condition(
                                CreateVariableExpressions(left, variables, binary.LeftNodes, ifNull),
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
                                CreateVariableExpressions(right, variables, binary.RightNodes, ifNull),
                                TrueConstantExpression,
                                FalseConstantExpression));

                        var left = new List<Expression>();
                        left.Add(
                            Expression.Condition(
                                CreateVariableExpressions(left, variables, binary.LeftNodes, ifNull),
                                Expression.Block(right),
                                FalseConstantExpression));

                        var block = Expression.Block(left);
                        return block;
                    }

                case ExpressionType.Coalesce:
                    {
                        var lable = Expression.Label();
                        var right = new List<Expression>();
                        right.Add(CreateVariableExpressions(right, variables, binary.RightNodes, ifNull));
                        var rightBlock = Expression.Block(right);
                        var left = new List<Expression>();
                        var coalesce = Expression.Coalesce(
                            CreateVariableExpressions(left, variables, binary.LeftNodes, Expression.Goto(lable)),
                            rightBlock);
                        left.Add(Expression.Label(lable));
                        left.Add(coalesce);

                        var block = Expression.Block(left);
                        return block;
                    }

                default:
                    {
                        var left = CreateVariableExpressions(expressions, variables, binary.LeftNodes, ifNull);
                        var right = CreateVariableExpressions(expressions, variables, binary.RightNodes, ifNull);
                        return Expression.MakeBinary(binary.BinaryExpression.NodeType, left, right);
                    }
            }
        }

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
            [NotNull] VaribalesCollection variables,
            FunctionNode function,
            [NotNull] Expression ifNull)
        {
            var args = function.Parameters.Select(
                    functionParameter => CreateVariableExpressions(expressions, variables, functionParameter, ifNull))
                .ToList();

            return Expression.Call(function.MethodInfo, args);
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
            [NotNull] VaribalesCollection variables,
            [NotNull] Type resultType,
            FunctionNode function,
            [NotNull] Expression ifNull,
            [NotNull] LabelTarget returnTarget) =>
            expressions.Add(
                Expression.Return(
                    returnTarget,
                    Expression.Convert(FunctionMakeExpression(expressions, variables, function, ifNull), resultType)));

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
            [NotNull] VaribalesCollection variables,
            [NotNull] Expression targetParameter,
            FunctionNode function,
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
    }
}