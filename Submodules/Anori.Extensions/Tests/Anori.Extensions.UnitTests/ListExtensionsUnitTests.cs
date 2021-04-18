// -----------------------------------------------------------------------
// <copyright file="ListExtensionsUnitTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.UnitTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    public class ListExtensionsUnitTests
    {

        [Test]
        public void ListExtensions_ReferenceAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        List<string> list = null;
                        list.ReferenceAtOrNull(1);
                    });
        }

        [Test]
        public void ListExtensions_ReferenceAtOrNull_in_Range_ReturnValue()
        {
            var list = new List<string> { "0", "1", "2", "3" };

            var actual = list.ReferenceAtOrNull(1);
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void ListExtensions_ReferenceAtOrNull_in_OutRange_ReturnNull()
        {
            var list = new List<string> { "0", "1", "2", "3" };

            var actual = list.ReferenceAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void ListExtensions_ValueAtOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        IEnumerable<int> list = null;
                        list.ValueAtOrNull(1);
                    });
        }

        [Test]
        public void ListExtensions_ValueAtOrNull_in_Range_ReturnValue()
        {
            var list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ValueAtOrNull(1);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void ListExtensions_ValueAtOrNull_in_OutRange_ReturnNull()
        {
            var list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ValueAtOrNull(10);
            Assert.AreEqual(null, actual);
        }
    }
}