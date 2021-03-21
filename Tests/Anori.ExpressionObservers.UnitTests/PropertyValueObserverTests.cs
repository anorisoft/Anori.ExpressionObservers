﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverTests.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    public class PropertyValueObserverTests : Bindable
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
            using var observes = PropertyValueObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => instance1.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(0, observes.Value);

            instance1.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_p1_instance1_IntProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.IntProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }
        
        [Test]
        public void PropertyObserver_p1_instance1_IntProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                instance,
                p1 => this.readonlyFieldInstance.IntProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyGenericObserver_instance1_IntProperty()
        {
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyGenericObserver_instance1_IntProperty_AutoActivateTrue()
        {
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_instance1_IntProperty()
        {
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                () => this.readonlyFieldInstance.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_instance1_Classe2_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                instance,
                i => this.readonlyFieldInstance.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.readonlyFieldInstance.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.readonlyFieldInstance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.readonlyFieldInstance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_Instance1_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
                instance,
                i => this.PropertyInstance.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            this.PropertyInstance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            this.PropertyInstance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            this.PropertyInstance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(instance, i => instance.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_p_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(instance, i => i.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_Count1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_Value()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, value);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            observes.Unsubscribe();
            Assert.AreEqual(2, value);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, value);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_Value_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, false, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, value);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            observes.Unsubscribe();
            Assert.AreEqual(2, value);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, value);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_Value_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, true, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            observes.Unsubscribe();
            Assert.AreEqual(2, value);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, value);
        }

        [Test]
        public void PropertyObserver_Instance_Class2_IntProperty_Value()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(() => instance.Class2.IntProperty, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, value);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            observes.Unsubscribe();
            Assert.AreEqual(2, value);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, value);
        }

        [Test]
        public void PropertyObserver_Fallback_Instance_Class2_IntProperty_Value()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var value = 0;
            var count = 0;
            using var observes = PropertyValueObserver.Observes(() => instance.Class2.IntProperty, v =>
                {
                    value = v;
                    count++;
                }, 10);

            Assert.AreEqual(0, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(0, count);

            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, observes.Value);
            Assert.AreEqual(0, count);

            instance.Class2.IntProperty = 1;
            Assert.AreEqual(0, value);
            Assert.AreEqual(1, observes.Value);
            Assert.AreEqual(0, count);

            observes.Subscribe();
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);
            Assert.AreEqual(1, count);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);
            Assert.AreEqual(2, count);

            instance.Class2 = null;
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(3, count);

            observes.Unsubscribe();
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(3, count);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 3 };
            Assert.AreEqual(10, value);
            Assert.AreEqual(3, observes.Value);
            Assert.AreEqual(3, count);
        }

        [Test]
        public void PropertyObserver_Fallback_Instance_Class2_IntProperty_Value_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var value = 0;
            var count = 0;
            using var observes = PropertyObserver.Observes(() => instance.Class2.IntProperty, false, v =>
                {
                    value = v;
                    count++;
                }, 10);

            Assert.AreEqual(0, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(0, count);

            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, observes.Value);
            Assert.AreEqual(0, count);

            instance.Class2.IntProperty = 1;
            Assert.AreEqual(0, value);
            Assert.AreEqual(1, observes.Value);
            Assert.AreEqual(0, count);

            observes.Subscribe();
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);
            Assert.AreEqual(1, count);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);
            Assert.AreEqual(2, count);

            instance.Class2 = null;
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(3, count);

            observes.Unsubscribe();
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(3, count);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 3 };
            Assert.AreEqual(10, value);
            Assert.AreEqual(3, observes.Value);
            Assert.AreEqual(3, count);
        }

        [Test]
        public void PropertyObserver_Fallback_Instance_Class2_IntProperty_Value_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var value = 0;
            var count = 0;
            using var observes = PropertyObserver.Observes(() => instance.Class2.IntProperty, true, v =>
                {
                    value = v;
                    count++;
                }, 10);

            Assert.AreEqual(0, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(0, count);

            instance.Class2 = new NotifyPropertyChangedClass2();
            Assert.AreEqual(0, value);
            Assert.AreEqual(0, observes.Value);
            Assert.AreEqual(1, count);

            instance.Class2.IntProperty = 1;
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);
            Assert.AreEqual(2, count);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);
            Assert.AreEqual(3, count);

            instance.Class2 = null;
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(4, count);

            observes.Unsubscribe();
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, observes.Value);
            Assert.AreEqual(4, count);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 3 };
            Assert.AreEqual(10, value);
            Assert.AreEqual(3, observes.Value);
            Assert.AreEqual(4, count);
        }


        [Test]
        public void PropertyObserver_Instance_Class2_IntProperty_Value_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(() => instance.Class2.IntProperty, false, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);
            observes.Subscribe();
            Assert.AreEqual(1, value);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, value);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_Instance_Class2_IntProperty_Value_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(() => instance.Class2.IntProperty, true, v => value = v);
            Assert.AreEqual(null, value);
            instance.Class2.IntProperty = 1;
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);
            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);
            observes.Unsubscribe();
            Assert.AreEqual(2, value);
            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_p1_Class2_IntProperty_Value()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(
                instance1,
                instance2,
                (p1, p2) => p1.Class2.IntProperty + p2.Class2.IntProperty,
                v => value = v);
            Assert.AreEqual(null, value);
            instance1.Class2.IntProperty = 1;
            Assert.AreEqual(null, value);
            observes.Subscribe();
            Assert.AreEqual(1, value);
            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, value);
            instance2.Class2.IntProperty = 3;
            Assert.AreEqual(5, value);
            observes.Unsubscribe();
            Assert.AreEqual(5, value);
            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(5, value);
        }

        [Test]
        public void PropertyObserver_p_Class2_IntProperty_and_1()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(instance, p => p.Class2.IntProperty, () => callCount++);
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
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(
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
            using var observes = PropertyValueObserver.Observes(
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