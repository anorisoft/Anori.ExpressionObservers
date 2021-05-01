// -----------------------------------------------------------------------
// <copyright file="PropertyObserverStringPropertyP1Test - Copy.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    public class PropertyObserverStringPropertyP2Test
    {
        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                () => callCount++,
                "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false,
                () => callCount++,
                "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                () => callCount++,
                "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
        }
        [Test]
        public void PropertyObserver_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                () => callCount++);
            Assert.AreEqual(0, callCount);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false,
                () => callCount++);
            Assert.AreEqual(0, callCount);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                () => callCount++);
            Assert.AreEqual(0, callCount);

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_Cashed()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                LazyThreadSafetyMode.None);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_Cashed_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                LazyThreadSafetyMode.None,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_Cashed_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                LazyThreadSafetyMode.None,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                LazyThreadSafetyMode.None,
                TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                LazyThreadSafetyMode.None,
                TaskScheduler.Current,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnProperyChanged_Observes_instance1_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                LazyThreadSafetyMode.None,
                TaskScheduler.Current,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_StringProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnValueChanged_Observes_instance1_StringProperty_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                TaskScheduler.Current,
                false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnValueChanged_Observes_instance1_StringProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1();
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                TaskScheduler.Current,
                true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                v =>
                    {
                        value = v;
                        callCount++;
                    },
                "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false,
                v =>
                    {
                        value = v;
                        callCount++;
                    },
                "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                v =>
                    {
                        value = v;
                        callCount++;
                    },
                "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_StringProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                v =>
                    {
                        value = v;
                        callCount++;
                    });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_StringProperty_AutoActivateFalse()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                false,
                v =>
                    {
                        value = v;
                        callCount++;
                    });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_StringProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { StringProperty = null };
            var instance2 = new NotifyPropertyChangedClass1();
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(
                instance1,
                instance2,
                (i1, i2) => i1.StringProperty,
                true,
                v =>
                    {
                        value = v;
                        callCount++;
                    });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance1.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance1.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance1.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.GetValue());
        }
    }
}