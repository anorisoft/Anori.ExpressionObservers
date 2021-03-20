// -----------------------------------------------------------------------
// <copyright file="PropertyObserverTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    public class PropertyObserverTests : Bindable
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
        public void PropertyObserver_p1_instance1_IntProperty_p2_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => instance1.IntProperty,
                () => {
                    callCount++;
                });
            Assert.AreEqual(0, callCount);
            instance1.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty_p2_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => instance1.IntProperty,
                false,
                () => {
                    callCount++;
                });
            Assert.AreEqual(0, callCount);
            instance1.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty_p2_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => instance1.IntProperty,
                true,
                () => {
                    callCount++;
                });
            Assert.AreEqual(0, callCount);
            instance1.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            instance1.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty_AutoAvtivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.IntProperty, 
                false,
                () => callCount++);

            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty_AutoAvtivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.IntProperty,
                true,
                () => callCount++);

            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyGenericObserver_instance1_IntProperty_AutoActivateFalse()
        {
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyGenericObserver_Fallback_instance1_IntProperty_AutoActivateFalse()
        {
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                false,
                () => callCount++, 10);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyGenericObserver_Fallback_instance1_IntProperty_AutoActivateTrue()
        {
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                true,
                () => callCount++, 10);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyGenericObserver_instance1_IntProperty_AutoActivateTrue()
        {
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
             Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, () => callCount++);
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
        public void PropertyObserver_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, false, () => callCount++);
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
        public void PropertyObserver_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, () => callCount++);
            Assert.AreEqual(0, callCount);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }


        [Test]
        public void PropertyObserver_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1(){ StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.GetValue());
            
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
        public void PropertyObserver_Fallback_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, false, () => callCount++);
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
        public void PropertyObserver_Fallback_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, () => callCount++);
            Assert.AreEqual(0, callCount);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_instance1_IntProperty()
        {
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_instance1_Classe2_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                i => this.readonlyFieldInstance.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Instance1_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                i => this.PropertyInstance.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.PropertyInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.PropertyInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.PropertyInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => instance.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => i.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_Count1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => i.Class2.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_and_1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                i => i.Class2.IntProperty + 1,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_Class2_IntProperty_and_p2_Class2_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.IntProperty + p2.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            instance2.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(3, callCount);
            instance2.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
        }

        [Test]
        public void PropertyObserver_p2_Class2_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.IntProperty + p2.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance2.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance2.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance2.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p1_Class2_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.IntProperty + p2.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_Class2_null()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, p => p.Class2.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.IntProperty = 1;
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
        public void PropertyObserver_p1_Class2_IntProperty_Class2_null()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.IntProperty = 1;
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
        public void PropertyObserver_p1_Class2_IntProperty_And_p1_Class2_IntProperty_Class2_null()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.IntProperty + p2.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance1.Class2.IntProperty = 1;
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
        public void PropertyObserver_p2_Class2_IntProperty_Class2_null()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p2.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance2.Class2.IntProperty = 1;
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
        public void PropertyObserver_p_Class2_IntProperty_plus_1_Class2_null()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance,
                i => i.Class2.IntProperty + 1,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.IntProperty = 1;
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