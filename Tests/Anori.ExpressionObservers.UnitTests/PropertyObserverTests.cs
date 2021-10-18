// -----------------------------------------------------------------------
// <copyright file="ExpressionGetterTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable RedundantAssignment
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable UnusedVariable

namespace Anori.ExpressionObservers.SplitTree.UnitTests
{
    using Anori.ExpressionObservers.UnitTests;

    using NUnit.Framework;

    public class PropertyObserverTests
    {
        [Test]
        public void PropertyObserver_Equal()
        {

            var notifyPropertyChangedTestObject = new NotifyPropertyChangedTestObject();
            using var observer1 = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression,
                () => { });
            using var observer2 = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression,
                () => { });
            Assert.True(observer1.Equals(observer2));
        }
    }
}