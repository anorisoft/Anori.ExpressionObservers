// -----------------------------------------------------------------------
// <copyright file="PropertyObserverTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;

    using Anori.Asserts;
    using Anori.ExpressionObservers.ExpressionNodeSplitter;
    using Anori.ExpressionObservers.UnitTests.SplitTree.TestClasses;
    using Anori.ExpressionTrees;
    using Anori.ExpressionTrees.Interfaces;

    using NUnit.Framework;

    public class PropertyObserverTests
    {
        private IExpressionTree? expressionTree;

        private IExpressionNode? expressionHead;

        private IExpressionNode? expressionParameter1;

        private IExpressionNode? expressionParameter2;

        private ObserverTree? observerTree;

        private IObserverTreeHead? observerHead;

        private IObserverTreeNode? observerChild1;

        private IObserverTreeNode? observerChild2;

        [Test]
        public void PropertyObserver_ObservableTree_Tree_1_Analyses()
        {
            this.GivenExpressionTree1();
            this.ThenHeaderIsIPropertyNodeOfTypeString();
            this.ThenParameter1IsINotifyPropertyChanged();
            this.ThenParameter2IsINotifyPropertyChanged();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_1_Analyses1()
        {
            this.GivenExpressionTree1();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIsIPropertyNode();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_1B_Analyses()
        {
            this.GivenExpressionTree1B();
            this.ThenHeaderIsIPropertyNodeOfTypeString();
            this.ThenParameter1IsINotifyPropertyChanged();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_1B_Analyses1()
        {
            this.GivenExpressionTree1B();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIsIPropertyNode();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_1C_Analyses1()
        {
            this.GivenExpressionTree1C();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIsIPropertyNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_2_Analyses1()
        {
            this.GivenExpressionTree2();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIsIMethodNode();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_3_Analyses1()
        {
            this.GivenExpressionTree3();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIs<IFunctionNode>();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
            this.ThanObserverTreeSecondChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_4_Analyses1()
        {
            this.GivenExpressionTree4();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIs<IMethodNode>();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
            this.ThanObserverTreeSecondChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_5_Analyses1()
        {
            this.GivenExpressionTree5();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIs<IBinaryNode>();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
            this.ThanObserverTreeSecondChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
            var c1 = this.observerChild1;
            var r1 = c1.Children.First().ExpressionHead.Result;
            var b1 = r1 == c1.ExpressionHead;
            var r2 = r1.Result;
            var b2 = r2 == c1.ExpressionHead;
            var r3 = r2.Result;
            var b3 = r2 == c1.ExpressionHead;
        }


        [Test]
        public void PropertyObserver_ObservableTree_Tree_6_Analyses1()
        {
            this.GivenExpressionTree6();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIs<IUnaryNode>();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_7_Analyses1()
        {
            this.GivenExpressionTree7();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIs<IUnaryNode>();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        [Test]
        public void PropertyObserver_ObservableTree_Tree_8_Analyses1()
        {
            this.GivenExpressionTree8();
            this.WhenCreateObserverTree();
            this.ThanObserverTreeHeadExpressionIs<IPropertyNode>();
            this.ThanObserverTreeFirstChild1ExpressionIsIPropertyNode();
            this.ThanObserverTreeChild2ExpressionIsIParameterNode();
        }

        private void ThenParameter2IsINotifyPropertyChanged()
        {
            this.expressionParameter2 = this.expressionParameter1!.Parameter;
            Assert.IsNotNull(this.expressionParameter2);
            AssertExtensions.IsTypeAssignableFrom<INotifyPropertyChanged>(this.expressionParameter2!.Type);
        }

        private void ThenParameter1IsINotifyPropertyChanged()
        {
            this.expressionParameter1 = this.expressionHead!.Parameter;
            Assert.IsNotNull(this.expressionParameter1);
            AssertExtensions.IsTypeAssignableFrom<INotifyPropertyChanged>(this.expressionParameter1!.Type);
        }

        private void ThenHeaderIsIPropertyNodeOfTypeString()
        {
            this.expressionHead = this.expressionTree!.Head;
            Assert.IsInstanceOf<IPropertyNode>(this.expressionHead);
            Assert.AreEqual(typeof(string), this.expressionHead.Type);
        }
        private void ThenHeaderIsIPropertyNodeOfType<T>()
        {
            this.expressionHead = this.expressionTree!.Head;
            Assert.IsInstanceOf<IPropertyNode>(this.expressionHead);
            Assert.AreEqual(typeof(T), this.expressionHead.Type);
        }
        private void GivenExpressionTree1()
        {
            this.expressionTree =
                ((Expression<Func<NotifyPropertyChangedClass1, string>>)(t => t.Class2.StringProperty))
                .ExpressionTree();
        }

        private void GivenExpressionTree1B()
        {
            this.expressionTree =
                ((Expression<Func<TestClass1, string>>)(t => t.NotifyPropertyChangedClass2.StringProperty))
                .ExpressionTree();
        }

        private void GivenExpressionTree1C()
        {
            this.expressionTree =
                ((Expression<Func<TestClass1, string>>)(t => t.Class2.StringProperty)).ExpressionTree();
        }

        private void GivenExpressionTree2()
        {
            this.expressionTree =
                ((Expression<Func<NotifyPropertyChangedClass1, string>>)(t => t.Class2.StringProperty.ToUpper()))
                .ExpressionTree();
        }

        private void GivenExpressionTree3()
        {
            this.expressionTree =
                ((Expression<Func<NotifyPropertyChangedClass1, NotifyPropertyChangedClass1, string>>)((p1, p2) =>
                                string.Concat(p1.Class2.StringProperty, p2.Class2.StringProperty))).ExpressionTree();
        }

        private void GivenExpressionTree4()
        {
            this.expressionTree =
                ((Expression<Func<NotifyPropertyChangedClass1, NotifyPropertyChangedClass1, string>>)((p1, p2) =>
                                string.Concat(p1.Class2.StringProperty, p2.Class2.IntProperty).ToUpper()))
                .ExpressionTree();
        }

        private void GivenExpressionTree5()
        {
            this.expressionTree =
                ((Expression<Func<NotifyPropertyChangedClass1, NotifyPropertyChangedClass1, int>>)((p1, p2) =>
                                p1.Class2.IntProperty + p2.Class2.IntProperty)).ExpressionTree();
        }

        private void GivenExpressionTree6()
        {
            this.expressionTree =
                ((Expression<Func<NotifyPropertyChangedClass1, bool>>)(p1 => !p1.Class2.BooleanProperty))
                .ExpressionTree();
        }

        private void GivenExpressionTree7()
        {
            this.expressionTree = ((Expression<Func<NotifyPropertyChangedClass1, int>>)(p1 => p1.IntCollection.First()))
                .ExpressionTree();
        }

        private void GivenExpressionTree8()
        {
            this.expressionTree = ((Expression<Func<TestClass1, int>>)(p1 => p1.ChangeableInt.Value)).ExpressionTree();
        }

        private void ThanObserverTreeChild2ExpressionIsIParameterNode()
        {
            this.observerChild2 = this.observerChild1!.Children.First();
            Assert.IsNotNull(this.observerChild2);
            Assert.IsInstanceOf<IParameterNode>(this.observerChild2.ExpressionHead);
        }

        private void ThanObserverTreeFirstChild1ExpressionIsIPropertyNode()
        {
            this.observerChild1 = this.observerHead!.Children.First();
            Assert.IsNotNull(this.observerChild1);
            Assert.IsInstanceOf<IPropertyNode>(this.observerChild1.ExpressionHead);
        }

        private void ThanObserverTreeSecondChild1ExpressionIsIPropertyNode()
        {
            this.observerChild1 = this.observerHead!.Children[1];
            Assert.IsNotNull(this.observerChild1);
            Assert.IsInstanceOf<IPropertyNode>(this.observerChild1.ExpressionHead);
        }

        private void ThanObserverTreeHeadExpressionIsIPropertyNode()
        {
            this.ThanObserverTreeHeadExpressionIs<IPropertyNode>();
        }

        private void ThanObserverTreeHeadExpressionIsIMethodNode()
        {
            this.ThanObserverTreeHeadExpressionIs<IMethodNode>();
        }

        private void ThanObserverTreeHeadExpressionIs<TNode>()
        {
            this.observerHead = this.observerTree!.Head;
            Assert.IsInstanceOf<IObserverTreeNode>(this.observerHead);
            Assert.AreEqual(typeof(string), this.observerTree.Type);
            Assert.IsInstanceOf<TNode>(this.observerHead.ExpressionHead);
        }

        private void WhenCreateObserverTree()
        {
            this.observerTree = new ObserverTree.ObserverTreeFactory(
                new NotifyCollectionChangedFinder(),
                new NotifyPropertyChangedFinder(),
                new ChangeableFinder())
                .New<NotifyPropertyChangedClass1, string>(this.expressionTree!);
        }
    }
}