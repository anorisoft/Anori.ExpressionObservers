// -----------------------------------------------------------------------
// <copyright file="PropertyObserverTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    public class PropertyReferenceObserverTests : Bindable
    {
        private readonly NotifyPropertyChangedClass1 readonlyFieldInstance = new NotifyPropertyChangedClass1();

        private NotifyPropertyChangedClass1 propertyInstance = new NotifyPropertyChangedClass1();

        public NotifyPropertyChangedClass1 PropertyInstance
        {
            get => this.propertyInstance;
            set
            {
                if (Equals(value, this.propertyInstance))
                {
                    return;
                }

                this.propertyInstance = value;
                this.OnPropertyChanged();
            }
        }

        [Test]
        public void PropertyObserver_p1_instance1_StringProperty_p2_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => instance1.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_instance1_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyGenericObserver_instance1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(() => instance.Class2, false, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyGenericObserver_instance1_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_instance1_StringProperty()
        {
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                () => this.readonlyFieldInstance.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_instance1_Classe2_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance,
                i => this.readonlyFieldInstance.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Instance1_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance,
                i => this.PropertyInstance.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.PropertyInstance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.PropertyInstance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.PropertyInstance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(instance, i => instance.StringProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(instance, i => i.StringProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_StringProperty_Count1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(instance, i => i.Class2.StringProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_StringProperty_Value()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (string)null;
            using var observes = PropertyReferenceObserver.Observes(instance, i => i.Class2.StringProperty, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.StringProperty = "1";
            Assert.AreEqual(null, value);
            observes.Subscribe();
            Assert.AreEqual("1", value);
            instance.Class2.StringProperty = "2";
            Assert.AreEqual("2", value);
            observes.Unsubscribe();
            Assert.AreEqual("2", value);
            instance.Class2.StringProperty = "3";
            Assert.AreEqual("2", value);
        }

        [Test]
        public void PropertyObserver_p1_Class2_StringProperty_Value()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var value = (string)null;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => (int.Parse(p1.Class2.StringProperty) + int.Parse(p2.Class2.StringProperty)).ToString(),
                v =>
                {
                    value = v;
                    TestContext.Out.WriteLine($"V: {v}");
                });
            Assert.AreEqual(null, value);
            instance1.Class2.StringProperty = "1";
            Assert.AreEqual(null, value);
            observes.Subscribe();
            Assert.AreEqual(null, value);
            instance2.Class2.StringProperty = "2";
            Assert.AreEqual("3", value);
            instance1.Class2.StringProperty = "2";
            Assert.AreEqual("4", value);
            instance2.Class2.StringProperty = "3";
            Assert.AreEqual("5", value);
            observes.Unsubscribe();
            Assert.AreEqual("5", value);
            instance1.Class2.StringProperty = "3";
            Assert.AreEqual("5", value);
        }

        [Test]
        public void PropertyObserver_p_Class2_StringProperty_and_1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance,
                i => i.Class2.StringProperty + 1,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_Class2_StringProperty_and_p2_Class2_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.StringProperty + p2.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            instance2.Class2.StringProperty = "2";
            Assert.AreEqual(3, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(3, callCount);
            instance2.Class2.StringProperty = "3";
            Assert.AreEqual(3, callCount);
        }

        [Test]
        public void PropertyObserver_p2_Class2_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.StringProperty + p2.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance2.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance2.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance2.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_Class2_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.StringProperty + p2.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_StringProperty_Class2_null()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(instance, p => p.Class2.StringProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_Class2_StringProperty_Class2_null()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_Class2_StringProperty_And_p1_Class2_StringProperty_Class2_null()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.StringProperty + p2.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(3, callCount);
            instance2.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(3, callCount);
        }

        [Test]
        public void PropertyObserver_p2_Class2_StringProperty_Class2_null()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p2.Class2.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance2.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance2.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_StringProperty_plus_1_Class2_null()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.Observes(
                instance,
                i => i.Class2.StringProperty + 1,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(2, callCount);
        }
    }
}