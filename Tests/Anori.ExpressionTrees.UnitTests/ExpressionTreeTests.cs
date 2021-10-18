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
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using Anori.Asserts;
    using Anori.ExpressionTrees.Interfaces;
    using Anori.ExpressionTrees.UnitTests.TestClasses;

    using NUnit.Framework;

    public class ExpressionTreeTests
    {
        [Test]
        public void CreateGetter_Fallback_A_t_Property_null_Return10()
        {
            var tree = ExpressionTree.Factory.New<Func<TestClass1, int>>(t => t.intProperty + 1);
            var head = tree.Head;
            Assert.IsInstanceOf<IBinaryNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Result);
            Assert.IsNull(head.Parameter);
            Assert.AreEqual(2, head.ParameterNotes.Count());
            Assert.IsInstanceOf<IFieldNode>(head.ParameterNotes.ElementAt(0));
            Assert.IsInstanceOf<IConstantNode>(head.ParameterNotes.ElementAt(1));
            var node = (IBinaryNode)head;
            Assert.AreEqual(ExpressionType.Add, node.NodeType);
            Assert.IsInstanceOf<IConstantNode>(node.RightNode);
            Assert.IsNull(node.RightNode.Parameter);
            var right = node.RightNode;
            Assert.AreEqual(ExpressionType.Add, node.NodeType);
            Assert.IsInstanceOf<IFieldNode>(node.LeftNode);
            Assert.IsNotNull(node.LeftNode.Parameter);
            Assert.IsInstanceOf<IParameterNode>(node.LeftNode.Parameter);
            var left = node.LeftNode;
        }

        [Test]
        public void ExpressionTree_Collection()
        {
            var tree =
                ((Expression<Func<NotifyPropertyChangedClass1, ObservableCollection<int>>>)(t => t.IntCollection))
                .ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IPropertyNode>(head);
            Assert.AreEqual(typeof(ObservableCollection<int>), head.Type);
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(head.Type));
            AssertExtensions.IsTypeAssignableFrom<INotifyCollectionChanged>(head.Type);
            AssertExtensions.IsTypeAssignableFrom<INotifyPropertyChanged>(head.Type);
            Assert.IsNull(head.Result);
            Assert.IsNotNull(head.Parameter);
            var node = (IPropertyNode)head;
            Assert.AreEqual(1, head.ParameterNotes.Count());

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
            Assert.IsNull(head.Result);
            Assert.IsNotNull(head.Parameter);
            var node = (IIndexerNode)head;
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(node.Object.Type));
            Assert.AreEqual(2, head.ParameterNotes.Count());

            //Assert.AreEqual(1, node.RightNode.Count);
            //Assert.IsInstanceOf<IConstantNode>(node.RightNode.First());
            //var right = node.RightNode.First();
        }

        [Test]
        public void ExpressionTree_Collection_Indexer_1_property()
        {
            var tree = ((Expression<Func<NotifyPropertyChangedClass1, int>>)(t => t.Collection[1].Property))
                .ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IPropertyNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Result);
            Assert.IsNotNull(head.Parameter);
            var node = (IPropertyNode)head;

            var previous = node.Parameter;
            Assert.IsInstanceOf<IIndexerNode>(previous);
            var previousNode = (IIndexerNode)previous;
            Assert.IsNotNull(previousNode);
            Assert.IsNotNull(previousNode.Object);
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(previousNode.Object.Type));
            var indexers = (previousNode.Object as IPropertyNode).Type.GetIndexers();
            Assert.IsTrue(previousNode.Object.Type.IsIndexer(previousNode.MethodInfo));
            Assert.AreNotEqual(0, indexers.Count());

            var arg = previousNode.Arguments.First();
            Assert.IsNotNull(arg.Result);
        }

        [Test]
        public void ExpressionTree_Collection_Indexer_Dynamic_property()
        {
            var tree =
                ((Expression<Func<NotifyPropertyChangedClass1, NotifyPropertyChangedClass1, int>>)((t1, t2) =>
                                t1.Collection[t2.GetClass2().IntProperty + 1].Property)).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IPropertyNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Result);
            Assert.IsNotNull(head.Parameter);
            var node = (IPropertyNode)head;

            var previous = node.Parameter;
            Assert.IsInstanceOf<IIndexerNode>(previous);
            var previousNode = (IIndexerNode)previous;
            Assert.IsTrue(typeof(INotifyCollectionChanged).IsAssignableFrom(previousNode?.Object.Type));
            var indexers = (previousNode?.Object as IPropertyNode)?.Type.GetIndexers();
            Assert.IsTrue(previousNode?.Object.Type.IsIndexer(previousNode.MethodInfo));
            Assert.AreNotEqual(0, indexers?.Count());

            var arg = previousNode?.Arguments.First();
            Assert.IsNotNull(arg?.Result);
        }
        [Test]
        public void ExpressionTree_Create_TestClass1_intProperty()
        {
            var tree = ExpressionTree.Factory.New<Func<TestClass1, int>>(t => t.intProperty);
            var head = tree.Head;
            Assert.IsInstanceOf<IFieldNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Result);
            Assert.IsNotNull(head.Parameter);
            Assert.IsInstanceOf<IParameterNode>(head.Parameter);
            Assert.AreEqual(typeof(TestClass1), head.Parameter.Type);
            Assert.AreEqual(1, head.ParameterNotes.Count());
            Assert.IsInstanceOf<IParameterNode>(head.ParameterNotes.ElementAt(0));
        }

        [Test]
        public void ExpressionTree2()
        {
            var tree = ((Expression<Func<TestClass1, int>>)(t => t.intProperty + 1)).ExpressionTree();
            var head = tree.Head;
            Assert.IsInstanceOf<IBinaryNode>(head);
            Assert.AreEqual(typeof(int), head.Type);
            Assert.IsNull(head.Result);
            Assert.IsNull(head.Parameter);
            var node = (IBinaryNode)head;
            Assert.AreEqual(ExpressionType.Add, node.NodeType);
            Assert.IsNull(node.RightNode.Parameter);
            Assert.IsInstanceOf<IConstantNode>(node.RightNode);
            var right = node.RightNode;
        }
    }
}