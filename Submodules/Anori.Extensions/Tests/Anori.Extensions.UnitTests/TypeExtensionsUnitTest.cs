// -----------------------------------------------------------------------
// <copyright file="TypeExtensionsUnitTest.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Extensions.UnitTests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;

    public class TypeExtensionsUnitTests
    {
        [Test]
        public void TypeExtensions_IsNullable_Type_Null_ReturnException()
        {
            Assert.Throws<ArgumentNullException>(() => { ((Type)null).IsNullable(); });
        }

        [Test]
        public void TypeExtensions_IsNullable_TypeInfo_Null_ReturnException()
        {
            Assert.Throws<ArgumentNullException>(() => { ((TypeInfo)null).IsNullable(); });
        }

        [Test]
        public void TypeExtensions_IsNullable_int_ReturnFalse()
        {
            Assert.False(typeof(int).IsNullable());
        }

        [Test]
        public void TypeExtensions_IsNullable_nullable_int_ReturnTrue()
        {
            Assert.True(typeof(int?).IsNullable());
        }

        [Test]
        public void TypeExtensions_IsNullableOf_int_ReturnFalse()
        {
            Assert.False(TypeExtensions.IsNullable<int>());
        }

        [Test]
        public void TypeExtensions_IsNullableOf_nullable_int_ReturnTrue()
        {
            Assert.True(TypeExtensions.IsNullable<int?>());
        }

        [Test]
        public void TypeExtensions_IsNullable_GetTypeInfo_int_ReturnFalse()
        {
            Assert.False(typeof(int).GetTypeInfo().IsNullable());
        }

        [Test]
        public void TypeExtensions_IsNullable_GetTypeInfo_nullable_int_ReturnTrue()
        {
            Assert.True(typeof(int?).GetTypeInfo().IsNullable());
        }
    }
}