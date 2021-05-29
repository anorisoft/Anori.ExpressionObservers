// -----------------------------------------------------------------------
// <copyright file="ExpressionTreeTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable RedundantAssignment
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable UnusedVariable

namespace Anori.ExpressionTrees.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Anori.ExpressionTrees.Interfaces;
    using Anori.ExpressionTrees.UnitTests.TestClasses;

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
            Assert.IsNull(node.RightNode.Previous);
            Assert.IsInstanceOf<IConstantNode>(node.RightNode);
            var right = node.RightNode;
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
            Assert.IsNull(node.RightNode.Previous);
            Assert.IsInstanceOf<IConstantNode>(node.RightNode);
            var right = node.RightNode;
        }

        [Test]
        public void ExpressionTree_Collection()
        {
            var tree = ((Expression<Func<NotifyPropertyChangedClass1, ObservableCollection<int>>>)(t => t.IntCollection)).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IPropertyNode>(head);
            Assert.AreEqual(typeof(ObservableCollection<int>), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNotNull(head.Previous);
            Assert.IsNull(head.Parent);
            var node = (IPropertyNode)head;
            //Assert.AreEqual(ExpressionType.Add, node.NodeType);
            //Assert.AreEqual(1, node.RightNode.Count);
            //Assert.IsInstanceOf<IConstantNode>(node.RightNode.First());
            //var right = node.RightNode.First();
        }

        [Test]
        public void ExpressionTree_Collection_Indexer_1()
        {
            var tree = ((Expression<Func<NotifyPropertyChangedClass1, int>>)(t => t.IntCollection[1])).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IIndexerNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNotNull(head.Previous);
            Assert.IsNull(head.Parent);
            var node = (IIndexerNode)head;
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(node.Object.Type));
            //Assert.AreEqual(1, node.RightNode.Count);
            //Assert.IsInstanceOf<IConstantNode>(node.RightNode.First());
            //var right = node.RightNode.First();
        }

        [Test]
        public void ExpressionTree_Collection_Indexer_1_property()
        {
            var tree = ((Expression<Func<NotifyPropertyChangedClass1, int>>)(t => t.Collection[1].Property)).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IPropertyNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNotNull(head.Previous);
            Assert.IsNull(head.Parent);
            var node = (IPropertyNode)head;
           
            var previous = node.Previous;
            Assert.IsInstanceOf<IIndexerNode>(previous);
            var previousNode = (IIndexerNode)previous;
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(previousNode.Object.Type));
            var xs = (previousNode.Object as IPropertyNode).Type.GetIndexers();
            Assert.IsTrue(previousNode.Object.Type.IsIndexer(previousNode.MethodInfo));
            Assert.AreNotEqual(0, xs.Count());

            var arg = previousNode.Arguments.First();
            Assert.IsNotNull(arg.Next);
        }


        [Test]
        public void ExpressionTree_Collection_Indexer_Dynamic_property()
        {
            var tree = ((Expression<Func<NotifyPropertyChangedClass1, NotifyPropertyChangedClass1, int>>)((t1, t2) => t1.Collection[t2.GetClass2().IntProperty + 1].Property)).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IPropertyNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Next);
            Assert.IsNotNull(head.Previous);
            Assert.IsNull(head.Parent);
            var node = (IPropertyNode)head;

            var previous = node.Previous;
            Assert.IsInstanceOf<IIndexerNode>(previous);
            var previousNode = (IIndexerNode)previous;
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(previousNode.Object.Type));
            var xs = (previousNode.Object as IPropertyNode).Type.GetIndexers();
            Assert.IsTrue(previousNode.Object.Type.IsIndexer(previousNode.MethodInfo));
            Assert.AreNotEqual(0, xs.Count());

            var arg = previousNode.Arguments.First();
            Assert.IsNotNull(arg.Next);
        }
    }
}