﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserverIntegerPropertyP2Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    public class PropertyObserverIntegerPropertyP2Test
    {
        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1() { Class2 = null };

            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                () => callCount++,
                99);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);
            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1() { Class2 = null };

            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false,
                () => callCount++,
                99);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1() { Class2 = null };

            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                () => callCount++,
                99);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };

            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesAndGet(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1() { Class2 = null };

            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesAndGet(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesAndGet(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }
        [Test]
        public void PropertyObserver_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                LazyThreadSafetyMode.None);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                LazyThreadSafetyMode.None,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                LazyThreadSafetyMode.None,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                LazyThreadSafetyMode.None,
                TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                LazyThreadSafetyMode.None,
                TaskScheduler.Current,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                LazyThreadSafetyMode.None,
                TaskScheduler.Current,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                TaskScheduler.Current,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                TaskScheduler.Current,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                v =>
                    {
                        value = v;
                        callCount++;
                    },
                99);

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false,
                v =>
                    {
                        value = v;
                        callCount++;
                    },
                99);

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                v =>
                    {
                        value = v;
                        callCount++;
                    },
                99);

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                v =>
                    {
                        value = v;
                        callCount++;
                    });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                false,
                v =>
                    {
                        value = v;
                        callCount++;
                    });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.Class2.IntProperty,
                true,
                v =>
                    {
                        value = v;
                        callCount++;
                    });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(null, observes.Value);
        }
    }
}