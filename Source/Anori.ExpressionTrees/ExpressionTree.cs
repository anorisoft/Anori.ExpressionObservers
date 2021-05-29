// -----------------------------------------------------------------------
// <copyright file="ExpressionTree.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Exceptions;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.ExpressionTrees.Nodes;
    using Anori.Extensions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Expression Tree class.
    ///     The Expression Tree class analyse a LambdaExpression and builds a tree of IExpressionNodes. The result of the
    ///     expression is the head and divides into root elements.
    /// </summary>
    /// <seealso cref="IRootAware" />
    public class ExpressionTree : IExpressionTree
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTree" /> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        private ExpressionTree(LambdaExpression expression)
        {
            this.ExpressionString = expression.ToAnonymousParametersString();
            this.Head = GetBranches(expression.Body, this, null);
        }

        /// <summary>
        ///     Gets the roots.
        /// </summary>
        /// <value>
        ///     The roots.
        /// </value>
        public IList<IExpressionNode> Roots { get; } = new List<IExpressionNode>();

        /// <summary>
        ///     Gets the expression string.
        /// </summary>
        /// <value>
        ///     The expression string.
        /// </value>
        public string ExpressionString { get; }

        /// <summary>
        ///     Gets the head of the expression tree.
        /// </summary>
        /// <value>
        ///     The head.
        /// </value>
        public IExpressionNode Head { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTree" /> with generic parameter class.
        /// </summary>
        /// <typeparam name="TFunc">The type of the function.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     A new instance of the <see cref="ExpressionTree" />.
        /// </returns>
        public static IExpressionTree New<TFunc>(Expression<TFunc> expression) => new ExpressionTree(expression);

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTree" /> with generic parameter class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///     A new instance of the <see cref="ExpressionTree" />.
        /// </returns>
        public static IExpressionTree New(LambdaExpression expression) => new ExpressionTree(expression);

        /// <summary>
        ///     Gets the tree.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressionTree">The tree.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>
        ///     The expression tree.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     nameof(expression) is null.
        /// </exception>
        /// <exception cref="ExpressionTreesException">
        ///     Expression member is not a PropertyInfo
        ///     or
        ///     Method call has no ReturnParameter
        ///     or
        ///     Expression body is null
        ///     or
        ///     Expression body is not a supported Expression {expression} type {expression.Type}.
        /// </exception>
        private static IExpressionNode GetBranches(
            [NotNull] Expression expression,
            [NotNull] IRootAware expressionTree,
            IExpressionNode? parent)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (expressionTree == null)
            {
                throw new ArgumentNullException(nameof(expressionTree));
            }

            var nodeCollection = new NodeCollection(expressionTree, parent);
            while (true)
            {
                switch (expression)
                {
                    case MemberExpression { Member: PropertyInfo propertyInfo } memberExpression:
                        {
                            expression = memberExpression.Expression;
                            nodeCollection.AddElement(new PropertyNode(memberExpression, propertyInfo));
                            break;
                        }

                    case MemberExpression { Member: FieldInfo fieldInfo } memberExpression:
                        {
                            expression = memberExpression.Expression;
                            nodeCollection.AddElement(new FieldNode(memberExpression, fieldInfo));
                            break;
                        }

                    case MemberExpression:
                        throw new TreeException("Expression member is not a PropertyInfo");

                    case ParameterExpression parameterExpression:
                        {
                            var element = new ParameterNode(parameterExpression);
                            var node = nodeCollection.AddElement(element);
                            nodeCollection.Roots.Add(node);
                            return nodeCollection.First();
                        }

                    case MethodCallExpression methodCallExpression
                        when methodCallExpression.Method.ReturnParameter == null:
                        throw new TreeException("Method call has no ReturnParameter");

                    case MethodCallExpression methodCallExpression:
                        expression = methodCallExpression.Object;
                        if (expression != null)
                        {
                            if (expression.Type.IsIndexer(methodCallExpression))
                            {
                                var element = new IndexerNode(methodCallExpression);
                                element.Object = GetBranches(expression, nodeCollection, element);

                                var arguments = methodCallExpression.Arguments.Select(argument => GetBranches(argument, nodeCollection, element)).ToList();

                                element.Arguments = arguments;
                                ((IInternalExpressionNode)element.Object).SetNext(element);
                                ((IInternalExpressionNode)element).SetPrevious(element.Object);
                                nodeCollection.AddElement(element);

                                return nodeCollection.First();
                            }
                            else
                            {
                                var element = new MethodNode(methodCallExpression);
                                element.Object = GetBranches(expression, nodeCollection, element);

                                var arguments = methodCallExpression.Arguments.Select(argument => GetBranches(argument, nodeCollection, element)).ToList();

                                element.Arguments = arguments;
                                nodeCollection.AddElement(element);

                                return nodeCollection.First();
                            }
                        }
                        else
                        {
                            var element = new FunctionNode(methodCallExpression);
                            var parameters = methodCallExpression.Arguments.Select(argument => GetBranches(argument, nodeCollection, element)).ToList();

                            element.Parameters = parameters;
                            nodeCollection.AddElement(element);
                            return nodeCollection.First();
                        }

                    case ConstantExpression constantExpression:
                        {
                            var element = new ConstantNode(constantExpression);
                            var node = nodeCollection.AddElement(element);
                            nodeCollection.Roots.Add(node);
                            return nodeCollection.First();
                        }

                    case BinaryExpression binaryExpression:
                        {
                            var element = new BinaryNode(binaryExpression);
                            element.LeftNode = GetBranches(binaryExpression.Left, nodeCollection, element);
                            element.RightNode = GetBranches(binaryExpression.Right, nodeCollection, element);
                            nodeCollection.AddElement(element);
                            return nodeCollection.First();
                        }

                    case UnaryExpression unaryExpression:
                        {
                            var element = new UnaryNode(unaryExpression);
                            element.Operand = GetBranches(unaryExpression.Operand, nodeCollection, element);
                            nodeCollection.AddElement(element);
                            return nodeCollection.First();
                        }

                    case ConditionalExpression conditionalExpression:
                        {
                            var element = new ConditionalNode(conditionalExpression);
                            element.Test = GetBranches(conditionalExpression.Test, nodeCollection, element);
                            element.IfTrue = GetBranches(conditionalExpression.IfTrue, nodeCollection, element);
                            element.IfFalse = GetBranches(conditionalExpression.IfFalse, nodeCollection, element);

                            nodeCollection.AddElement(element);
                            return nodeCollection.First();
                        }

                    case NewExpression newExpression:
                        {
                            var element = new ConstructorNode(newExpression);
                            var parameters = newExpression.Arguments.Select(argument => GetBranches(argument, nodeCollection, element)).ToList();

                            element.Parameters = parameters;
                            nodeCollection.AddElement(element);
                            return nodeCollection.First();
                        }

                    case MemberInitExpression memberInitExpression:
                        {
                            var element = new MemberInitNode(memberInitExpression);
                            var parameters = memberInitExpression.NewExpression.Arguments.Select(argument => GetBranches(argument, nodeCollection, element)).ToList();

                            element.Parameters = parameters;

                            var bindings = memberInitExpression.Bindings;
                            var bindingTree = CreateBindingTree(nodeCollection, bindings, element);

                            element.Bindings = bindingTree;
                            nodeCollection.AddElement(element);
                            return nodeCollection.First();
                        }

                    case null:
                        throw new TreeException("Expression body is null");

                    default:
                        throw new TreeException(
                            $"Expression body is not a supported Expression {expression} type {expression.Type}");
                }
            }
        }

        /// <summary>
        ///     Creates the binding tree.
        /// </summary>
        /// <param name="expressionTree">The tree.</param>
        /// <param name="bindings">The bindings.</param>
        /// <param name="node">The node.</param>
        /// <returns>The binding list.</returns>
        private static List<IBindingNode> CreateBindingTree(
            IRootAware expressionTree,
            IEnumerable<MemberBinding> bindings,
            MemberInitNode node)
        {
            var bindingTree = new List<IBindingNode>();
            foreach (var binding in bindings)
            {
                switch (binding)
                {
                    case MemberAssignment memberAssignment:
                        {
                            bindingTree.Add(
                                new MemberAssignmentNode(
                                    memberAssignment,
                                    GetBranches(memberAssignment.Expression, expressionTree, node)));
                            break;
                        }

                    case MemberMemberBinding memberMemberBinding:
                        {
                            var bs = CreateBindingTree(expressionTree, memberMemberBinding.Bindings, node);
                            bindingTree.Add(new MemberMemberBindingNode(memberMemberBinding, bs, node));
                            break;
                        }

                    case MemberListBinding memberListBinding:
                        {
                            var elementInits = memberListBinding.Initializers
                                .Select(
                                    i => new ElementInitNode(
                                        i,
                                        i.Arguments.Select(a => GetBranches(a, expressionTree, node)).ToList()))
                                .Cast<IElementInitNode>()
                                .ToList();

                            bindingTree.Add(new MemberListBindingNode(memberListBinding, elementInits));
                            break;
                        }
                }
            }

            return bindingTree;
        }
    }
}