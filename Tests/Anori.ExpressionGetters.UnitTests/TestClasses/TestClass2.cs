// -----------------------------------------------------------------------
// <copyright file="TestClass2.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionGetters.UnitTests.TestClasses
{
    using System.Collections.Generic;

    public class TestClass2
    {
        // ReSharper disable once InconsistentNaming
        internal TestClass3 test3;

        public IList<int> List { get; } = new List<int>
                                              {
                                                  1,
                                                  2,
                                                  3,
                                                  4,
                                                  5
                                              };

        public IList<TestClass3> Tests { get; } =
            new List<TestClass3> { new TestClass3 { Property = 1 }, new TestClass3 { Property = 2 } };

        public int Property { get; set; }

        public TestClass3 Test3
        {
            get => this.test3;
            set => this.test3 = value;
        }

        public TestClass3 GetTest3() => this.Test3;

        public TestClass3 GetTest3(int i)
        {
            if (i != 1)
            {
                return null;
            }

            return this.Test3;
        }

        public TestClass3 GetTest3(int i, string s) => this.Test3;
    }
}