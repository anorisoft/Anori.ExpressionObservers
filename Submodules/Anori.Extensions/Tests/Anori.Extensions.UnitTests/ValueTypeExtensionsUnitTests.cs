// -----------------------------------------------------------------------
// <copyright file="EnumerableExtensionsUnitTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.UnitTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ValueTypeAndReferenceTypeExtensionsUnitTests
    {
        [Test]
        public void EnumerableExtensions_List_ReferenceAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IList<string> list = null;
                        list.ElementAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_List_ReferenceAtOrNull_in_Range_ReturnValue()
        {
            var list = new List<string> { "0", "1", "2", "3" };

            var actual = list.ElementAtOrNull(1);
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void EnumerableExtensions_List_ReferenceAtOrNull_in_OutRange_ReturnNull()
        {
            var list = new List<string> { "0", "1", "2", "3" };

            var actual = list.ElementAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void EnumerableExtensions_List_ValueAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IList<int> list = null;
                        list.ElementAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_List_ValueAtOrNull_in_Range_ReturnValue()
        {
            var list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ElementAtOrNull(1);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void EnumerableExtensions_List_ValueAtOrNull_in_OutRange_ReturnNull()
        {
            var list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ElementAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ReferenceAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<string> list = null;
                        list.ElementAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ReferenceAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<string> list = new[] { "0", "1", "2", "3" }.ToHashSet();

            var actual = list.ElementAtOrNull(1);
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ReferenceAtOrNull_in_OutRange_ReturnNull()
        {
            IEnumerable<string> list = new[] { "0", "1", "2", "3" }.ToHashSet();

            var actual = list.ElementAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ValueAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<int> list = null;
                        list.ElementAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ValueAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<int> list = new[] { 0, 1, 2, 3 }.ToHashSet();

            var actual = list.ElementAtOrNull(1);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ValueAtOrNull_in_OutRange_ReturnNull()
        {
            IEnumerable<int> list = new[] { 0, 1, 2, 3 }.ToHashSet();

            var actual = list.ElementAtOrNull(10);
            Assert.AreEqual(null, actual);
        }
    }
}