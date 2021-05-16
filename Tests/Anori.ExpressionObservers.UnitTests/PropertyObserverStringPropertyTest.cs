// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_StringProperty_Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.Common;
    using Anori.ExpressionObservers.Builder.PropertyObserver;
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        //[Test]
        //public void PropertyObserver_OnPropertyChanged_Observes_instance_StringProperty()
        //{
        //    var instance = new NotifyPropertyChangedClass1();
        //    var callCount = 0;
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, false);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, false);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, true);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, false);

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
        //    using var observes = PropertyReferenceObserver.ObservesOnNotifyPropertyChanged(() => instance.StringProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, true);

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
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, () => callCount++, "Fallback");
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
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, false, () => callCount++, "Fallback");
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
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, () => callCount++, "Fallback");
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
            using var observes = PropertyReferenceObserver.ObservesAndGet(() => instance.StringProperty, true, () => callCount++);
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
            using var observes = PropertyReferenceObserver.Observes(() => instance.StringProperty, (v) =>
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
            using var observes = PropertyReferenceObserver.Observes(() => instance.StringProperty, false, (v) =>
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
            using var observes = PropertyReferenceObserver.Observes(() => instance.StringProperty, true, (v) =>
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
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, (v) =>
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
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, false, (v) =>
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
            using var observes = PropertyObserver.Observes(() => instance.StringProperty, true, (v) =>
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

    public class PropertyObserverBuilderCountTests
    {
        [Test]
        public void PropertyObserver_Count_OnNotify()
        {
            var instance = new NotifyPropertyChangedClass1() ;
            var callCount = 0;

            using var observes = PropertyObserverBuilder.Builder
              .ReferenceObserverBuilder(() => (instance.IntProperty > 2).ToString())
              .OnPropertyChanged()
              .WithAction(() => callCount++)
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
            var instance = new NotifyPropertyChangedClass1(){ IntProperty = 0};
            var callCount = 0;

            using var observes = PropertyObserverBuilder.Builder
              .ReferenceObserverBuilder(() => (instance.IntProperty > 3).ToString())
              .OnValueChanged()
              .WithAction(() => callCount++)
              .Build();
              
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate(true);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 1;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 2;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 3;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("False", observes.Value);

            instance.IntProperty = 4;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("True", observes.Value);

            instance.IntProperty = 5;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("True", observes.Value);

            instance.IntProperty = 6;
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("True", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);

        }

        [Test]
        public void PropertyValueObserver_Count_OnValue_ABC_Silent_Fallback()
        {
            var instance1 = new NotifyPropertyChangedClass1() { IntProperty = 0 };
            var instance21 = new NotifyPropertyChangedClass1() { IntProperty = 1 };
            var instance22 = new NotifyPropertyChangedClass1() { IntProperty = 2 };
            var instance31 = new NotifyPropertyChangedClass1() { IntProperty = 3 };
            var instance32 = new NotifyPropertyChangedClass1() { IntProperty = 4 };
            var instance33 = new NotifyPropertyChangedClass1() { IntProperty = 5 };
            var callCountABC = 0;
            var callCountA = 0;
            var callCountB = 0;
            var callCountC = 0;
            var callCountAB = 0;

            using var a = PropertyObserverBuilder.Builder
              .ValueObserverBuilder(() => instance1.IntProperty)
              .OnValueChanged()
              .WithAction(() => callCountA++)
              .WithFallback(0)
              .Build()
              .Activate(true);

            using var b = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance21.IntProperty + instance22.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountB++)
                .WithFallback(0)
                .Build()
              .Activate(true);

            using var c = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance31.IntProperty + instance32.IntProperty + instance33.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountC++)
                .WithFallback(0)
                .Build()
              .Activate(true);

            using var ab = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => a.Value + b.Value)
             .OnValueChanged()
             .WithAction(() => callCountAB++).WithFallback(0)
             .Build()
                 .Activate(true);

            using var observes = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => ab.Value + c.Value)
             .OnValueChanged()
             .WithAction(() => callCountABC++)
             .Build()
              .Activate(true);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(15, observes.Value);

            instance1.IntProperty = 1;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(1, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(16, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            instance21.IntProperty = 2;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(17, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance22.IntProperty = 3;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(18, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance31.IntProperty = 4;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(19, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance32.IntProperty = 5;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(20, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance33.IntProperty = 6;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(21, observes.Value);
        }

        [Test]
        public void PropertyValueObserver_Count_OnValue_ABC_Fallback()
        {
            var instance1 = new NotifyPropertyChangedClass1() { IntProperty = 0 };
            var instance21 = new NotifyPropertyChangedClass1() { IntProperty = 1 };
            var instance22 = new NotifyPropertyChangedClass1() { IntProperty = 2 };
            var instance31 = new NotifyPropertyChangedClass1() { IntProperty = 3 };
            var instance32 = new NotifyPropertyChangedClass1() { IntProperty = 4 };
            var instance33 = new NotifyPropertyChangedClass1() { IntProperty = 5 };
            var callCountABC = 0;
            var callCountA = 0;
            var callCountB = 0;
            var callCountC = 0;
            var callCountAB = 0;

            using var a = PropertyObserverBuilder.Builder
              .ValueObserverBuilder(() => instance1.IntProperty)
              .OnValueChanged()
              .WithAction(() => callCountA++)
              .WithFallback(0)
              .Build()
              .Activate();

            using var b = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance21.IntProperty + instance22.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountB++)
                .WithFallback(0)
                .Build()
              .Activate();

            using var c = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance31.IntProperty + instance32.IntProperty + instance33.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountC++)
                .WithFallback(0)
                .Build()
              .Activate();

            using var ab = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => a.Value + b.Value)
             .OnValueChanged()
             .WithAction(() => callCountAB++).WithFallback(0)
             .Build()
                 .Activate();

            using var observes = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => ab.Value + c.Value)
             .OnValueChanged()
             .WithAction(() => callCountABC++)
             .Build()
              .Activate();

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(15, observes.Value);

            instance1.IntProperty = 1;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(1, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(16, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            instance21.IntProperty = 2;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(17, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance22.IntProperty = 3;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(18, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance31.IntProperty = 4;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(19, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance32.IntProperty = 5;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(20, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance33.IntProperty = 6;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(21, observes.Value);
        }

        [Test]
        public void PropertyValueObserver_Count_OnValue_ABC()
        {
            var instance1 = new NotifyPropertyChangedClass1() { IntProperty = 0 };
            var instance21 = new NotifyPropertyChangedClass1() { IntProperty = 1 };
            var instance22 = new NotifyPropertyChangedClass1() { IntProperty = 2 };
            var instance31 = new NotifyPropertyChangedClass1() { IntProperty = 3 };
            var instance32 = new NotifyPropertyChangedClass1() { IntProperty = 4 };
            var instance33 = new NotifyPropertyChangedClass1() { IntProperty = 5 };
            var callCountABC = 0;
            var callCountA = 0;
            var callCountB = 0;
            var callCountC = 0;
            var callCountAB = 0;

            using var a = PropertyObserverBuilder.Builder
              .ValueObserverBuilder(() => instance1.IntProperty)
              .OnValueChanged()
              .WithAction(() => callCountA++)
              .Build()
              .Activate();

            using var b = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance21.IntProperty + instance22.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountB++)
                .Build()
              .Activate();

            using var c = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance31.IntProperty + instance32.IntProperty + instance33.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountC++)
                .Build()
              .Activate();

            using var ab = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => a.Value.Value + b.Value.Value)
             .OnValueChanged()
             .WithAction(() => callCountAB++)
             .Build()
                 .Activate();

            using var observes = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => ab.Value.Value + c.Value.Value)
             .OnValueChanged()
             .WithAction(() => callCountABC++)
             .Build()
              .Activate();

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(15, observes.Value);

            instance1.IntProperty = 1;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(1, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(16, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            instance21.IntProperty = 2;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(17, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance22.IntProperty = 3;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(18, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance31.IntProperty = 4;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(19, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance32.IntProperty = 5;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(20, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; instance33.IntProperty = 6;
            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(21, observes.Value);
        }

        [Test]
        public void PropertyValueObserver_Count_OnValue_ABC_Null()
        {
            var instance1 = new NotifyPropertyChangedClass1() { Class2 = null };
            var instance21 = new NotifyPropertyChangedClass1() { Class2 = null };
            var instance22 = new NotifyPropertyChangedClass1() { Class2 = null };
            var instance31 = new NotifyPropertyChangedClass1() { Class2 = null };
            var instance32 = new NotifyPropertyChangedClass1() { Class2 = null };
            var instance33 = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCountABC = 0;
            var callCountA = 0;
            var callCountB = 0;
            var callCountC = 0;
            var callCountAB = 0;

            using var a = PropertyObserverBuilder.Builder
              .ValueObserverBuilder(() => instance1.Class2.IntProperty)
              .OnValueChanged()
              .WithAction(() => callCountA++)
              .Build()
              .Activate();

            using var b = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance21.Class2.IntProperty + instance22.Class2.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountB++)
                .Build()
              .Activate();

            using var c = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance31.Class2.IntProperty + instance32.Class2.IntProperty + instance33.Class2.IntProperty)
                .OnValueChanged()
                .WithAction(() => callCountC++)
                .Build()
              .Activate();

            using var ab = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => a.Value.Value + b.Value.Value)
             .OnValueChanged()
             .WithAction(() => callCountAB++)
             .Build()
               .Activate();

            using var observes = PropertyObserverBuilder.Builder
             .ValueObserverBuilder(() => ab.Value.Value + c.Value.Value)
             .OnValueChanged()
             .WithAction(() => callCountABC++)
             .Build()
              .Activate();

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new() { IntProperty = 1 };
            Assert.AreEqual(1, a.Value);
            
            Assert.AreEqual(0, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(1, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(null, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            instance21.Class2 = new() { IntProperty = 2 };
            Assert.AreEqual(null, b.Value);

            Assert.AreEqual(0, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(null, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; 
            instance22.Class2 = new() { IntProperty = 3 };
            Assert.AreEqual(5, b.Value);

            Assert.AreEqual(0, callCountABC);
            Assert.AreEqual(1, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(1, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(null, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; 
            instance31.Class2 = new() { IntProperty = 4 };

            Assert.AreEqual(null, c.Value);

            Assert.AreEqual(0, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(null, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0;
            instance32.Class2 = new() { IntProperty = 5 };

            Assert.AreEqual(null, c.Value);

            Assert.AreEqual(0, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(0, callCountC);
            Assert.AreEqual(null, observes.Value);

            callCountABC = 0;
            callCountA = 0;
            callCountB = 0;
            callCountC = 0;
            callCountAB = 0; 
            instance33.Class2 = new() { IntProperty = 6 };

            Assert.AreEqual(15, c.Value);

            Assert.AreEqual(1, callCountABC);
            Assert.AreEqual(0, callCountAB);
            Assert.AreEqual(0, callCountA);
            Assert.AreEqual(0, callCountB);
            Assert.AreEqual(1, callCountC);
            Assert.AreEqual(21, observes.Value);
        }
    }
}