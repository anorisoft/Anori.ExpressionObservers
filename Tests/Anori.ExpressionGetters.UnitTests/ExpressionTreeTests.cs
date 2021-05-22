// -----------------------------------------------------------------------
// <copyright file="ExpressionTreeTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable RedundantAssignment
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable UnusedVariable

namespace Anori.ExpressionGetters.UnitTests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Anori.ExpressionGetters;
    using Anori.ExpressionGetters.Tree;
    using Anori.ExpressionGetters.Tree.Interfaces;
    using Anori.ExpressionGetters.UnitTests.TestClasses;

    using NUnit.Framework;

    public class ExpressionTreeTests
    {
        [Test]
        public void CreateGetter_Fallback_A_t_Property_null_Return10()
        {
            var tree = ExpressionTree.New<Func<TestClass1, int>>(t => t.intProperty + 1);
            var head = tree.Head;
            Assert.IsInstanceOf<IBinaryNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNull(head.Previous);
            Assert.IsNull(head.Parent);
            var node = (IBinaryNode)head;
            Assert.AreEqual(ExpressionType.Add, node.NodeType);
            Assert.AreEqual(1, node.RightNodes.Count);
            Assert.IsInstanceOf<IConstantNode>(node.RightNodes.First());
            var right = node.RightNodes.First();
        }
        [Test]
        public void ExpressionTree_Create_TestClass1_intProperty()
        {
            var tree = ExpressionTree.New<Func<TestClass1, int>>(t => t.intProperty);
            var head = tree.Head;
            Assert.IsInstanceOf<IFieldNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNotNull(head.Previous);
            Assert.IsInstanceOf<IParameterNode>(head.Previous);
            Assert.AreEqual(typeof(TestClass1), head.Previous.Type);
            Assert.IsNull(head.Parent);
        }

        [Test]
        public void ExpressionTree2()
        {
            var tree = ((Expression<Func<TestClass1, int>>)(t => t.intProperty + 1)).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IBinaryNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNull(head.Previous);
            Assert.IsNull(head.Parent);
            var node = (IBinaryNode)head;
            Assert.AreEqual(ExpressionType.Add, node.NodeType);
            Assert.AreEqual(1, node.RightNodes.Count);
            Assert.IsInstanceOf<IConstantNode>(node.RightNodes.First());
            var right = node.RightNodes.First();
        }
    }
}