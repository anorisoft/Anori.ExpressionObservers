// -----------------------------------------------------------------------
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
    using Anori.ExpressionObservers.Tree.Interfaces;
    using Anori.ExpressionObservers.Tree.Nodes;
    using Anori.Extensions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Expression Tree class.
    ///     The Expression Tree class alyses a LambdaExpression and builds a tree of IExpressionNodes. The result of the
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
            this.Nodes = GetBranches(expression.Body, this, null);
            this.ExpressionString = expression.ToAnonymousParametersString();
            this.Head = this.Nodes.First();
        }

        /// <summary>
        ///     Gets the roots.
        /// </summary>
        /// <value>
        ///     The roots.
        /// </value>
        public IList<IExpressionNode> Roots { get; } = new List<IExpressionNode>();

        /// <summary>
        ///     Gets the nodes.
        /// </summary>
        /// <value>
        ///     The nodes.
        /// </value>
        public INodeCollection Nodes { get; }

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
        internal static INodeCollection GetBranches(
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
                            element.Object = GetBranches(expression, nodeCollection, element);

                            var arguments = new List<INodeCollection>();
                            foreach (var argument in methodCallExpression.Arguments)
                            {
                                arguments.Add(GetBranches(argument, nodeCollection, element));
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
                                parameters.Add(GetBranches(argument, nodeCollection, element));
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
                            element.LeftNodes = GetBranches(binaryExpression.Left, nodeCollection, element);
                            element.RightNodes = GetBranches(binaryExpression.Right, nodeCollection, element);
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case UnaryExpression unaryExpression:
                        {
                            var element = new UnaryNode(unaryExpression);
                            element.Operand = GetBranches(unaryExpression.Operand, nodeCollection, element);
                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case ConditionalExpression conditionalExpression:
                        {
                            var element = new ConditionalNode(conditionalExpression);
                            element.Test = GetBranches(conditionalExpression.Test, nodeCollection, element);
                            element.IfTrue = GetBranches(conditionalExpression.IfTrue, nodeCollection, element);
                            element.IfFalse = GetBranches(conditionalExpression.IfFalse, nodeCollection, element);

                            nodeCollection.AddElement(element);
                            return nodeCollection;
                        }

                    case NewExpression newExpression:
                        {
                            var element = new ConstructorNode(newExpression);
                            var parameters = new List<INodeCollection>();
                            foreach (var argument in newExpression.Arguments)
                            {
                                parameters.Add(GetBranches(argument, nodeCollection, element));
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
                                parameters.Add(GetBranches(argument, nodeCollection, element));
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
                                    GetBranches(memberAssignment.Expression, expressionTree, node)));
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
                                        i.Arguments.Select(a => GetBranches(a, expressionTree, node)).ToList()));
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