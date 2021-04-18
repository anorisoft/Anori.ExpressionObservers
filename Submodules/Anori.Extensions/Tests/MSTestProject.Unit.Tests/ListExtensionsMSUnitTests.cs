// -----------------------------------------------------------------------
// <copyright file="ListExtensionsMSUnitTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.UnitTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListExtensionsMSUnitTests
    {

        [TestMethod]

        public void ListExtensions_ValueAtOrNull_Null_ReturnNull()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                    {
                        List<int> list = null;
                        list.ValueAtOrNull(10);
                    });
        }

        [TestMethod]

        public void ListExtensions_ValueAtOrNull_in_OutRange_ReturnNull()
        {
            var list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ValueAtOrNull(10);
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void ListExtensions_ValueAtOrNull_in_Range_ReturnValue()
        {
            IEnumerable<int> list = new List<int> { 0, 1, 2, 3 };

            var actual = list.ValueAtOrNull(1);
            Assert.AreEqual(1, actual);
        }
    }
}