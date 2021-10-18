// -----------------------------------------------------------------------
// <copyright file="TestClass1.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree.TestClasses
{
    using System.Collections.Generic;

    using Anori.ExpressionObservers.ExpressionNodeSplitter;

    public class TestClass1
    {

        public IChangeable<int> ChangeableInt { get; } = new Changeable<int>();

        internal TestClass2 class2 = new TestClass2();

        internal TestClass2 test2B;

        internal int intProperty;

        public IList<int> List { get; } = new List<int>
                                              {
                                                  1,
                                                  2,
                                                  3,
                                                  4,
                                                  5
                                              };

        public int IntProperty
        {
            get => this.intProperty;
            set => this.intProperty = value;
        }

        public bool BoolProperty { get; set; }

        public TestClass2 Class2
        {
            get => this.class2;
            set => this.class2 = value;
        }

        public NotifyPropertyChangedClass2 NotifyPropertyChangedClass2
        {
            get;
            set;
        } = new NotifyPropertyChangedClass2();

        public TestClass2 Test2B
        {
            get => this.test2B;
            set => this.test2B = value;
        }

        public TestStruct2 Struct2 { get; set; }

        public int? NulableProperty { get; set; }
        public IList<int> IntArrayProperty { get; set; }

        public TestClass2 GetTest2() => this.Class2;
    }

    public struct TestStruct1
    {
        internal int property;

        internal TestStruct2 test2;

        public int Property
        {
            get => this.property;
            set => this.property = value;
        }

        public TestStruct2 GetTest2() => this.Test2;

        public TestStruct2 Test2
        {
            get => this.test2;
            set => this.test2 = value;
        }
    }

    public struct TestStruct2
    {
        internal int property;

        internal TestStruct3 test3;

        public int Property
        {
            get => this.property;
            set => this.property = value;
        }

        public TestStruct3 GetTest3() => this.Test3;

        public TestStruct3 Test3
        {
            get => this.test3;
            set => this.test3 = value;
        }
    }

    public struct TestStruct3
    {
        internal int property;

        public int Property
        {
            get => this.property;
            set => this.property = value;
        }
    }
}