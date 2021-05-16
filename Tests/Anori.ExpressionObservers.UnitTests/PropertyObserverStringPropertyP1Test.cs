// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_StringProperty_Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.Common;
    using Anori.ExpressionObservers.UnitTests.TestClasses;
    using NUnit.Framework;
    using System.Threading.Tasks;

    public class PropertyObserverStringPropertyP1Test
    {
        [Test]
        public void PropertyObserver_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, () => callCount++);
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
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, false, () => callCount++);
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
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, true, () => callCount++);
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
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(instance, i => i.StringProperty);

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
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(instance, i => i.StringProperty, false);

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
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(instance, i => i.StringProperty, true);

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
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(instance, i => i.StringProperty, TaskScheduler.Current);

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
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(instance, i => i.StringProperty, TaskScheduler.Current, false);

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
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged(instance, i => i.StringProperty, TaskScheduler.Current, true);

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

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    observes.Activate();
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("3", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_AutoActivateFalse()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, false);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    observes.Activate();
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("3", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_AutoActivateTrue()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("3", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_Cashed()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true, LazyThreadSafetyMode.None);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    observes.Activate();
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_Cashed_AutoActivateFalse()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true, LazyThreadSafetyMode.None, false);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    observes.Activate();
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_Cashed_AutoActivateTrue()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true, LazyThreadSafetyMode.None, true);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    observes.Activate();
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivateFalse()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, false);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    observes.Activate();
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);
        //}

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivateTrue()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(instance, i => i.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, true);

        //    observes.PropertyChanged += (sender, args) => callCount++;
        //    Assert.AreEqual(0, callCount);
        //    Assert.AreEqual(null, observes.Value);

        //    instance.StringProperty = "1";
        //    Assert.AreEqual(1, callCount);
        //    Assert.AreEqual("1", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "2";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    observes.Deactivate();
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);

        //    instance.StringProperty = "3";
        //    Assert.AreEqual(2, callCount);
        //    Assert.AreEqual("2", observes.Value);
        //}

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

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
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, false, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

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
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, true, () => callCount++, "Fallback");
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance.StringProperty = "1";
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
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = instance.ObservesAndGet(i => i.StringProperty, () => callCount++);
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
            using var observes = instance.ObservesAndGet(i => i.StringProperty, false, () => callCount++);
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
        public void PropertyObserver_Getter_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesAndGet(instance, i => i.StringProperty, true, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance.StringProperty = "1";
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
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(instance, i => i.StringProperty, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(instance, i => i.StringProperty, false, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyReferenceObserver.Observes(instance, i => i.StringProperty, true, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual(null, observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, (v) =>
                {
                    value = v;
                    callCount++;
                }, "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, false, (v) =>
                {
                    value = v;
                    callCount++;
                }, "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("1", observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.GetValue());
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { StringProperty = null };
            var callCount = 0;
            var value = "Nil";
            using var observes = PropertyObserver.Observes(instance, i => i.StringProperty, true, (v) =>
                {
                    value = v;
                    callCount++;
                }, "Fallback");

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Nil", value);
            Assert.AreEqual("Fallback", observes.GetValue());

            instance.StringProperty = "1";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.GetValue());

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.GetValue());

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.GetValue());

            instance.StringProperty = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.GetValue());
        }
    }
}