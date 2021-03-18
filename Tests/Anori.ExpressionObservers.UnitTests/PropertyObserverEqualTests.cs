using Anori.ExpressionObservers.UnitTests.TestClasses;
using Anori.PropertyChain.UnitTest;

using NUnit.Framework;

namespace Anori.ExpressionObservers.UnitTests
{
    public class PropertyObserverEqualTests : Bindable
    {
        [Test]
        public void NotifyPropertyChanged_SameAre_Equal_Test()
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

        [Test]
        public void NotifyPropertyChanged_SameAre_EqualOperator_Test()
        {
            var notifyPropertyChangedTestObject = new NotifyPropertyChangedTestObject();
            using var observer1 = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression,
                () => { });
            using var observer2 = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression,
                () => { });
            Assert.True(observer1 == observer2);
        }

        [Test]
        public void NotifyPropertyChanged_SameAre_NotEqualOperator_Test()
        {
            var notifyPropertyChangedTestObject = new NotifyPropertyChangedTestObject();
            using var observer1 = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression,
                () => { });
            using var observer2 = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression,
                () => { });
            Assert.False(observer1 != observer2);
        }



        [Test]
        public void NotifyPropertyChanged_Expression_ObservesIntegerAndBoolean_Test()
        {
            var actionIntegerRaised = false;
            var actionBooleanRaised = false;
            var notifyPropertyChangedTestObject =
                new NotifyPropertyChangedTestObject { IntProperty = 1, BoolProperty = false };
            using var integerObserver = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.IntPropertyExpression, false,
                () => actionIntegerRaised = true);
            integerObserver.Subscribe(true);

            using var booleanObserver = PropertyObserver.Observes(
                notifyPropertyChangedTestObject.BoolPropertyExpression, false,
                () => actionBooleanRaised = true);
            booleanObserver.Subscribe(true);

            Assert.False(actionIntegerRaised);
            Assert.False(actionBooleanRaised);
            notifyPropertyChangedTestObject.BoolProperty = true;
            Assert.True(actionBooleanRaised);
            Assert.False(actionIntegerRaised);
            notifyPropertyChangedTestObject.IntProperty = 2;
            Assert.True(actionBooleanRaised);
            Assert.True(actionIntegerRaised);
        }
    }
}