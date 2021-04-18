// -----------------------------------------------------------------------
// <copyright file="ListExtensionsUnitTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.UnitTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class DictionaryExtensionsUnitTests
    {
        [Test]
        public void DictionaryExtensions_ReferenceType_GetValueOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        Dictionary<int, string> dictionary = null;
                        dictionary.GetObjectOrNull(1);
                    });
        }

        [Test]
        public void DictionaryExtensions_ValueType_GetValueOrNull_null_ReturnNull()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    {
                        Dictionary<int, int> dictionary = null;
                        dictionary.GetValueOrNull(1);
                    });
        }

        [Test]
        public void DictionaryExtensions_ReferenceType_GetValueOrNull_KeyExist_ReturnValue()
        {
            var dictionary = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" } };

            var actual = dictionary.GetObjectOrNull(1);
            Assert.AreEqual("1", actual);
        }

        [Test]
        public void DictionaryExtensions_ValueType_GetValueOrNull_KeyExist_ReturnValue()
        {
            var dictionary = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } };

            var actual = dictionary.GetValueOrNull(1);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void DictionaryExtensions_ReferenceType_GetValueOrNull_KeyNotExist_ReturnNull()
        {
            var dictionary = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" } };

            var actual = dictionary.GetObjectOrNull(4);

            Assert.AreEqual(null, actual);
        }

        [Test]
        public void DictionaryExtensions_ValueType_GetValueOrNull_KeyNotExist_ReturnNull()
        {
            var dictionary = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 3, 3 } };

            var actual = dictionary.GetValueOrNull(4);
            Assert.AreEqual(null, actual);
        }
    }
}