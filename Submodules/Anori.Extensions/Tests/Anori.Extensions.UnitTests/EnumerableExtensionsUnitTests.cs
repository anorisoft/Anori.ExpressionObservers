// -----------------------------------------------------------------------
// <copyright file="EnumerableExtensionsUnitTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    public class EnumerableExtensionsUnitTests
    {
        [Test]
        public void EnumerableExtensions_List_ReferenceAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<string> list = null;
                        list.ReferenceAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_List_ReferenceAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<string> list = new List<string> { "0", "1", "2", "3" };

            var actual = list.ReferenceAtOrNull(1);
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void EnumerableExtensions_List_ReferenceAtOrNull_in_OutRange_ReturnNull()
        {
            IEnumerable<string> list = new List<string> { "0", "1", "2", "3" };

            var actual = list.ReferenceAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void EnumerableExtensions_List_ValueAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<int> list = null;
                        list.ValueAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_List_ValueAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<int> list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ValueAtOrNull(1);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void EnumerableExtensions_List_ValueAtOrNull_in_OutRange_ReturnNull()
        {
            IEnumerable<int> list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ValueAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ReferenceAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<string> list = null;
                        list.ReferenceAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ReferenceAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<string> list = new []{ "0", "1", "2", "3" }.ToHashSet(); 

            var actual = list.ReferenceAtOrNull(1);
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ReferenceAtOrNull_in_OutRange_ReturnNull()
        {
            IEnumerable<string> list = new[] { "0", "1", "2", "3" }.ToHashSet();

            var actual = list.ReferenceAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ValueAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<int> list = null;
                        list.ValueAtOrNull(1);
                    });
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ValueAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<int> list = new[] { 0, 1, 2, 3 }.ToHashSet();

            var actual = list.ValueAtOrNull(1);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void EnumerableExtensions_Enumerable_ValueAtOrNull_in_OutRange_ReturnNull()
        {
            IEnumerable<int> list = new[] { 0, 1, 2, 3 }.ToHashSet();

            var actual = list.ValueAtOrNull(10);
            Assert.AreEqual(null, actual);
        }
    }
}