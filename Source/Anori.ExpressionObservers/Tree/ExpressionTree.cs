﻿// -----------------------------------------------------------------------
// <copyright file="ExpressionTree.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.Nodes;
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.ExpressionObservers.Tree.Nodes;

    using JetBrains.Annotations;

    /// <summary>
    ///     Expression Tree.
    /// </summary>
    /// <seealso cref="IRootAware" />
    internal class ExpressionTree : IExpressionTree
    {
        /// <summary>
        ///     Prevents a default instance of the <see cref="ExpressionTree" /> class from being created.
        /// </summary>
        private ExpressionTree()
        {
            this.Nodes = null!;
        }

        /// <summary>
        ///     Gets the roots.
        /// </summary>
        /// <value>
        ///     The roots.
        /// </value>
        public IList<IExpressionNode> Roots { get; } = new List<IExpressionNode>();

        /// <summary>
        ///     Gets or sets the nodes.
        /// </summary>
        /// <value>
        ///     The nodes.
        /// </value>
        public INodeCollection Nodes { get; set; }

        /// <summary>
        ///     Gets the tree.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The expression tree.</returns>
        public static IExpressionTree GetTree(Expression expression)
        {
            var tree = new ExpressionTree();
            tree.Nodes = GetTree(expression, tree, null);
            return tree;
        }

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
        ///     nameof(expression)
        ///     or
        ///     nameof(expression)
        ///     or
        ///     nameof(expression)
        ///     or
        ///     nameof(expression)
        ///     or
        ///     nameof(expression)
        ///     or
        ///     nameof(expression) is null.
        /// </exception>
        /// <exception cref="ExpressionObserversException">
        ///     Expression member is not a PropertyInfo
        ///     or
        ///     Method call has no ReturnParameter
        ///     or
        ///     Expression body is null
        ///     or
        ///     Expression body is not a supportet Expression {expression} type {expression.Type}.
        /// </exception>
        public static INodeCollection GetTree(
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

                    case MemberExpression _:
                        throw new TreeException("Expression member is not a PropertyInfo");

                    case ParameterExpression parameterExpression:
                        {
                            var element = new ParameterNode(parameterExpression);
                            var node = nodeCollection.AddElement(element);
                            nodeCollection.Roots.Add(node);
                            return nodeCollection;
                        }

                    case MethodCallExpression methodCallExpression
                        when methodCallExpression.Method.ReturnParameter == null:
                        throw new TreeException("Method call has no ReturnParameter");

                    case MethodCallExpression methodCallExpression:
                        expression = methodCallExpression.Object;
                        if (expression != null)
                        {
                            var element = new MethodNode(methodCallExpression);
                            element.Object = GetTree(expression, nodeCollection, element);

                            var arguments = new List<INodeCollection>();
                            foreach (var argument in methodCallExpression.Arguments)
                            {
                                arguments.Add(GetTree(argument, nodeCollection, element));
                            }

                            element.Arguments = arguments;
                            nodeCollection.AddElement(element);

                            return nodeCollection;
                        }
                        else
                        {
                            var element = new FunctionNode(methodCallExpression);
                            var parameters = new List<INodeCollection>();
                            foreach (var argument in methodCallExpression.Arguments)
                            {
                                parameters.Add(GetTree(argument, nodeCollection, element));
                            }

                            element.Parameters = parameters;
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case ConstantExpression constantExpression:
                        {
                            var element = new ConstantNode(constantExpression);
                            var node = nodeCollection.AddElement(element);
                            nodeCollection.Roots.Add(node);
                            return nodeCollection;
                        }

                    case BinaryExpression binaryExpression:
                        {
                            var element = new BinaryNode(binaryExpression);
                            element.LeftNodes = GetTree(binaryExpression.Left, nodeCollection, element);
                            element.RightNodes = GetTree(binaryExpression.Right, nodeCollection, element);
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case UnaryExpression unaryExpression:
                        {
                            var element = new UnaryNode(unaryExpression);
                            element.Operand = GetTree(unaryExpression.Operand, nodeCollection, element);
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case ConditionalExpression conditionalExpression:
                        {
                            var element = new ConditionalNode(conditionalExpression);
                            element.Test = GetTree(conditionalExpression.Test, nodeCollection, element);
                            element.IfTrue = GetTree(conditionalExpression.IfTrue, nodeCollection, element);
                            element.IfFalse = GetTree(conditionalExpression.IfFalse, nodeCollection, element);

                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case NewExpression newExpression:
                        {
                            var element = new ConstructorNode(newExpression);
                            var parameters = new List<INodeCollection>();
                            foreach (var argument in newExpression.Arguments)
                            {
                                parameters.Add(GetTree(argument, nodeCollection, element));
                            }

                            element.Parameters = parameters;
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case MemberInitExpression memberInitExpression:
                        {
                            var element = new MemberInitNode(memberInitExpression);
                            var parameters = new List<INodeCollection>();
                            foreach (var argument in memberInitExpression.NewExpression.Arguments)
                            {
                                parameters.Add(GetTree(argument, nodeCollection, element));
                            }

                            element.Parameters = parameters;

                            var bindings = memberInitExpression.Bindings;
                            var bindingtree = CreateBindingTree(nodeCollection, bindings, element);

                            element.Bindings = bindingtree;
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case null:
                        throw new TreeException("Expression body is null");

                    default:
                        throw new TreeException(
                            $"Expression body is not a supportet Expression {expression} type {expression.Type}");
                }
            }
        }

        /// <summary>
        ///     Creates the bindingtree.
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
            var bindingtree = new List<IBindingNode>();
            foreach (var binding in bindings)
            {
                switch (binding)
                {
                    case MemberAssignment memberAssignment:
                        {
                            bindingtree.Add(
                                new MemberAssignmentNode(
                                    memberAssignment,
                                    GetTree(memberAssignment.Expression, expressionTree, node)));
                            break;
                        }

                    case MemberMemberBinding memberMemberBinding:
                        {
                            var bs = CreateBindingTree(expressionTree, memberMemberBinding.Bindings, node);
                            bindingtree.Add(new MemberMemberBindingNode(memberMemberBinding, bs, node));
                            break;
                        }

                    case MemberListBinding memberListBinding:
                        {
                            var elementInits = new List<ElementInitNode>();
                            foreach (var i in memberListBinding.Initializers)
                            {
                                elementInits.Add(
                                    new ElementInitNode(
                                        i,
                                        i.Arguments.Select(a => GetTree(a, expressionTree, node)).ToList()));
                            }

                            bindingtree.Add(new MemberListBindingNode(memberListBinding, elementInits));
                            break;
                        }
                }
            }

            return bindingtree;
        }
    }
}