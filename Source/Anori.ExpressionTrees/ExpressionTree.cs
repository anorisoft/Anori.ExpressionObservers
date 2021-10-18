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
        public class ExpressionTreeFactory : IExpressionTreeFactory
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="ExpressionTree" /> with generic parameter class.
            /// </summary>
            /// <typeparam name="TFunc">The type of the function.</typeparam>
            /// <param name="expression">The expression.</param>
            /// <returns>
            ///     A new instance of the <see cref="ExpressionTree" />.
            /// </returns>
            public IExpressionTree New<TFunc>(Expression<TFunc> expression) => new ExpressionTree(expression);

            /// <summary>
            ///     Initializes a new instance of the <see cref="ExpressionTree" /> with generic parameter class.
            /// </summary>
            /// <param name="expression">The expression.</param>
            /// <returns>
            ///     A new instance of the <see cref="ExpressionTree" />.
            /// </returns>
            public IExpressionTree New(LambdaExpression expression) => new ExpressionTree(expression);
        }

        public static IExpressionTreeFactory Factory { get; } = new ExpressionTreeFactory();

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
                        expression = AddPropertyNode(memberExpression, nodeCollection, propertyInfo);
                        break;

                    case MemberExpression { Member: FieldInfo fieldInfo } memberExpression:
                        expression = AddFieldNode(memberExpression, nodeCollection, fieldInfo);
                        break;

                    case MemberExpression:
                        throw new TreeException("Expression member is not a PropertyInfo");

                    case ParameterExpression parameterExpression:
                        return AddParameterNode(parameterExpression, nodeCollection);

                    case MethodCallExpression { Method: { ReturnParameter: null } }:
                        throw new TreeException("Method call has no ReturnParameter");

                    case MethodCallExpression { Object: null } methodCallExpression:
                        return AddFunctionNode(methodCallExpression, nodeCollection);

                    case MethodCallExpression
                            { Object: { } expr } methodCallExpression when expr.Type.IsIndexer(methodCallExpression):
                        return AddIndexerNode(expr, methodCallExpression, nodeCollection);

                    case MethodCallExpression { Object: { } expr } methodCallExpression:
                        return AddMethodNode(expr, methodCallExpression, nodeCollection);

                    case ConstantExpression constantExpression:
                        return AddConstantNode(constantExpression, nodeCollection);

                    case BinaryExpression binaryExpression:
                        return AddBinaryNode(binaryExpression, nodeCollection);

                    case UnaryExpression unaryExpression:
                        return AddUnaryNode(unaryExpression, nodeCollection);

                    case ConditionalExpression conditionalExpression:
                        return AddConditionalNode(conditionalExpression, nodeCollection);

                    case NewExpression newExpression:
                        return AddConstructorNode(newExpression, nodeCollection);

                    case MemberInitExpression memberInitExpression:
                        return AddMemberInitNode(memberInitExpression, nodeCollection);

                    case null:
                        throw new TreeException("Expression body is null");

                    default:
                        throw new TreeException(
                            $"Expression body is not a supported Expression {expression} type {expression.Type}");
                }
            }
        }
        private static IExpressionNode AddMemberInitNode(
            MemberInitExpression memberInitExpression,
            NodeCollection nodeCollection)
        {
            var element = new MemberInitNode(memberInitExpression);
            var parameters = memberInitExpression.NewExpression.Arguments
                .Select(argument => GetBranches(argument, nodeCollection, element))
                .ToList();

            element.Parameters = parameters;

            var bindings = memberInitExpression.Bindings;
            var bindingTree = CreateBindingTree(nodeCollection, bindings, element);

            element.Bindings = bindingTree;
            nodeCollection.AddElement(element);
            return nodeCollection.First();
        }
        private static IExpressionNode AddConstructorNode(NewExpression newExpression, NodeCollection nodeCollection)
        {
            var element = new ConstructorNode(newExpression);
            var parameters = newExpression.Arguments.Select(argument => GetBranches(argument, nodeCollection, element))
                .ToList();

            element.Parameters = parameters;
            nodeCollection.AddElement(element);
            return nodeCollection.First();
        }
        private static IExpressionNode AddConditionalNode(
            ConditionalExpression conditionalExpression,
            NodeCollection nodeCollection)
        {
            var element = new ConditionalNode(conditionalExpression);
            element.Test = GetBranches(conditionalExpression.Test, nodeCollection, element);
            element.IfTrue = GetBranches(conditionalExpression.IfTrue, nodeCollection, element);
            element.IfFalse = GetBranches(conditionalExpression.IfFalse, nodeCollection, element);

            nodeCollection.AddElement(element);
            return nodeCollection.First();
        }
        private static IExpressionNode AddUnaryNode(UnaryExpression unaryExpression, NodeCollection nodeCollection)
        {
            var element = new UnaryNode(unaryExpression);
            element.Operand = GetBranches(unaryExpression.Operand, nodeCollection, element);
            nodeCollection.AddElement(element);
            return nodeCollection.First();
        }
        private static IExpressionNode AddBinaryNode(BinaryExpression binaryExpression, NodeCollection nodeCollection)
        {
            var element = new BinaryNode(binaryExpression);
            element.LeftNode = GetBranches(binaryExpression.Left, nodeCollection, element);
            element.RightNode = GetBranches(binaryExpression.Right, nodeCollection, element);
            nodeCollection.AddElement(element);
            return nodeCollection.First();
        }
        private static IExpressionNode AddConstantNode(
            ConstantExpression constantExpression,
            NodeCollection nodeCollection)
        {
            var element = new ConstantNode(constantExpression);
            var node = nodeCollection.AddElement(element);
            nodeCollection.Roots.Add(node);
            return nodeCollection.First();
        }
        private static IExpressionNode AddMethodNode(
            Expression expression,
            MethodCallExpression methodCallExpression,
            NodeCollection nodeCollection)
        {
            var element = new MethodNode(methodCallExpression);
            element.Object = GetBranches(expression, nodeCollection, element);
            var arguments = methodCallExpression.Arguments
                .Select(argument => GetBranches(argument, nodeCollection, element))
                .ToList();

            element.Arguments = arguments;
            nodeCollection.AddElement(element);

            return nodeCollection.First();
        }
        private static IExpressionNode AddIndexerNode(
            Expression expression,
            MethodCallExpression methodCallExpression,
            NodeCollection nodeCollection)
        {
            var element = new IndexerNode(methodCallExpression);
            element.Object = GetBranches(expression, nodeCollection, element);

            var arguments = methodCallExpression.Arguments
                .Select(argument => GetBranches(argument, nodeCollection, element))
                .ToList();

            element.Arguments = arguments;
            ((IInternalExpressionNode)element.Object).SetResult(element);
            ((IInternalExpressionNode)element).SetParameter(element.Object);
            nodeCollection.AddElement(element);

            return nodeCollection.First();
        }
        private static IExpressionNode AddFunctionNode(
            MethodCallExpression methodCallExpression,
            NodeCollection nodeCollection)
        {
            var element = new FunctionNode(methodCallExpression);
            var parameters = methodCallExpression.Arguments
                .Select(argument => GetBranches(argument, nodeCollection, element))
                .ToList();

            element.Parameters = parameters;
            nodeCollection.AddElement(element);
            return nodeCollection.First();
        }
        private static IExpressionNode AddParameterNode(
            ParameterExpression parameterExpression,
            NodeCollection nodeCollection)
        {
            var element = new ParameterNode(parameterExpression);
            var node = nodeCollection.AddElement(element);
            nodeCollection.Roots.Add(node);
            return nodeCollection.First();
        }
        private static Expression AddFieldNode(
            MemberExpression memberExpression,
            NodeCollection nodeCollection,
            FieldInfo fieldInfo)
        {
            var expression = memberExpression.Expression;
            var node = new FieldNode(memberExpression, fieldInfo);
            nodeCollection.AddElement(node);
            return expression;
        }
        private static Expression AddPropertyNode(
            MemberExpression memberExpression,
            NodeCollection nodeCollection,
            PropertyInfo propertyInfo)
        {
            var expression = memberExpression.Expression;
            var node = new PropertyNode(memberExpression, propertyInfo);
            nodeCollection.AddElement(node);
            return expression;
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
                SwitchBinding(expressionTree, node, binding, bindingTree);
            }

            return bindingTree;
        }
        private static void SwitchBinding(
            IRootAware expressionTree,
            MemberInitNode node,
            MemberBinding binding,
            List<IBindingNode> bindingTree)
        {
            switch (binding)
            {
                case MemberAssignment memberAssignment:
                    AddMemberAssignmentNode(expressionTree, node, memberAssignment, bindingTree);
                    break;

                case MemberMemberBinding memberMemberBinding:
                    AddMemberMemberBindingNode(expressionTree, node, memberMemberBinding, bindingTree);
                    break;

                case MemberListBinding memberListBinding:
                    AddMemberListBindingNode(expressionTree, node, memberListBinding, bindingTree);
                    break;
            }
        }
        private static void AddMemberListBindingNode(
            IRootAware expressionTree,
            IExpressionNode node,
            MemberListBinding memberListBinding,
            ICollection<IBindingNode> bindingTree)
        {
            var elementInits = memberListBinding.Initializers
                .Select(
                    i => new ElementInitNode(i, i.Arguments.Select(a => GetBranches(a, expressionTree, node)).ToList()))
                .Cast<IElementInitNode>()
                .ToList();

            bindingTree.Add(new MemberListBindingNode(memberListBinding, elementInits));
        }
        private static void AddMemberMemberBindingNode(
            IRootAware expressionTree,
            MemberInitNode node,
            MemberMemberBinding memberMemberBinding,
            ICollection<IBindingNode> bindingTree)
        {
            var bs = CreateBindingTree(expressionTree, memberMemberBinding.Bindings, node);
            bindingTree.Add(new MemberMemberBindingNode(memberMemberBinding, bs, node));
        }
        private static void AddMemberAssignmentNode(
            IRootAware expressionTree,
            IExpressionNode node,
            MemberAssignment memberAssignment,
            ICollection<IBindingNode> bindingTree)
        {
            var n = new MemberAssignmentNode(
                memberAssignment,
                GetBranches(memberAssignment.Expression, expressionTree, node));
            bindingTree.Add(n);
        }
    }
}