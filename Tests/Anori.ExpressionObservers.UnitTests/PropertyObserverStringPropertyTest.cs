// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_StringProperty_Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.Common;
    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.UnitTests.TestClasses;
    using NUnit.Framework;
    using System.Threading.Tasks;

    public class PropertyObserverStringPropertyTest
    {
        [Test]
        public void PropertyObserver_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, () => callCount++);
            Assert.AreEqual(0, callCount);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
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

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
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

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(() => instance.StringProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(() => instance.StringProperty, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(() => instance.StringProperty, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(() => instance.StringProperty, TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(() => instance.StringProperty, TaskScheduler.Current, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(() => instance.StringProperty, TaskScheduler.Current, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnNotifyProperyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, false, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(() => instance.StringProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(() => instance.StringProperty, false, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(() => instance.StringProperty, true, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(() => instance.StringProperty, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(() => instance.StringProperty, false, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(() => instance.StringProperty, true, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, (v) =>
                {
                    value = v;
                    callCount++;
                }, "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, false, (v) =>
                {
                    value = v;
                    callCount++;
                }, "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, (v) =>
                {
                    value = v;
                    callCount++;
                }, "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }
    }

    public class PropertyObserverBuilderCountTests
    {       
        [Test]
        public void PropertyObserver_Count_OnNotify()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            
            using var observes = PropertyObserverBuilder.Builder
              .ReferenceObserverBuilder(() => (instance.IntProperty > 2).ToString())
              .OnNotifyProperyChanged()
              .WithAction(()=> callCount++)
              .WithGetter()
              .AutoActivate()
              .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("False", observes.GetValue());

            instance.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("False", observes.GetValue());

            instance.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("False", observes.GetValue());

            instance.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual("True", observes.GetValue());

            instance.IntProperty = 4;
            Assert.AreEqual(4, callCount);
            Assert.AreEqual("True", observes.GetValue());

        }

        [Test]
        public void PropertyObserver_Count_OnValue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;

            using var observes = PropertyObserverBuilder.Builder
              .ReferenceObserverBuilder(() => (instance.IntProperty > 3).ToString())
              .OnValueChanged()
              .WithAction(() => callCount++)
              .Build()
              .Activate(true);

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 2;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 3;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 4;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("True", observes.Value);

            instance.IntProperty = 5;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("True", observes.Value);

            instance.IntProperty = 6;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("True", observes.Value);
        }



        [Test]
        public void PropertyValueObserver_Count_OnValue()
        {
            var instance1 = new NotifyPropertyChangedClass1() { IntProperty = 1 };
            var instance2 = new NotifyPropertyChangedClass1() { IntProperty = 2 };
            var instance3 = new NotifyPropertyChangedClass1() { IntProperty = 3 };
            var instance4 = new NotifyPropertyChangedClass1() { IntProperty = 4 };
            var callCount = 0;


            var a = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance1.IntProperty + instance2.IntProperty).OnValueChanged().WithAction(() => callCount++).WithFallback(0).Build();
            var b = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance3.IntProperty + instance4.IntProperty).OnValueChanged().WithAction(() => callCount++).WithFallback(0).Build();
             using var observes = PropertyObserverBuilder.Builder
              .ValueObserverBuilder(() => a.Value + b.Value)
              .OnValueChanged()
              .WithAction(() => callCount++)
              .Build()
              .Activate(true);

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.IntProperty = 1;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(false, observes.Value);

            instance1.IntProperty = 2;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(false, observes.Value);

            instance1.IntProperty = 3;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(false, observes.Value);

            instance1.IntProperty = 4;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(true, observes.Value);

            instance1.IntProperty = 5;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(true, observes.Value);

            instance1.IntProperty = 6;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(true, observes.Value);
        }
    }
}