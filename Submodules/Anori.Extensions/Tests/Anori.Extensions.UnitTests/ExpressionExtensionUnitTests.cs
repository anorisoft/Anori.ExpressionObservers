// -----------------------------------------------------------------------
// <copyright file="ExpressionExtensionUnitTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Anori.Extensions.UnitTests
{
    using Anori.Extensions.UnitTests.TestClasses;

    using NUnit.Framework;

    using System.Linq.Expressions;

    public class ExpressionExtensionUnitTests
    {
        public TestClass1 Class1 { get; set; }

        [Test]
        public void ExpressionExtension_Class1_IntProperty()
        {
            Expression<Func<int>> expression = () => this.Class1.IntProperty;
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => arg1.IntProperty";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_IntProperty()
        {
            var class1 = new TestClass1();

            Expression<Func<int>> expression = () => (class1.IntProperty);
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => arg1.IntProperty";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_o_IntProperty()
        {
            Expression<Func<TestClass1, int>> expression = o => o.IntProperty;
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => arg1.IntProperty";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_o_IntProperty_add_1()
        {
            Expression<Func<TestClass1, int>> expression = o => o.IntProperty + 1;
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => (arg1.IntProperty + 1)";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_o_Equals_o()
        {
            Expression<Func<TestClass1, bool>> expression = o => o.Equals(o);
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => arg1.Equals(arg1)";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_l_o()
        {
            Expression<Func<int, List<TestClass1>, TestClass1>> expression = (o, l) => l[o];
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1, arg2) => arg2.get_Item(arg1)";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_o()
        {
            Expression<Func<TestClass1, TestClass1>> expression = o => o;
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => arg1";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_o_ToString()
        {
            Expression<Func<TestClass1, string>> expression = o => o.ToString();
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => arg1.ToString()";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_nameof_o()
        {
            Expression<Func<TestClass1, string>> expression = o => nameof(o);
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1) => \"arg1\"";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExpressionExtension_class1_c1_c2_IntProperty()
        {
            Expression<Func<TestClass1, TestClass1, int>> expression = (c1, c2) => c1.IntProperty;
            TestContext.Out.WriteLine(expression.ToString());
            var actual = expression.ToAnonymousParametersString();
            var expected = "(arg1, arg2) => arg1.IntProperty";
            TestContext.Out.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}