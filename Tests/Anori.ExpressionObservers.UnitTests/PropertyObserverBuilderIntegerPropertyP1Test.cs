// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_IntProperty_Test.cs" company="AnoriSoft">
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

    public class PropertyObserverBuilderIntegerPropertyP1Test
    {
        [Test]
        public void PropertyObserver_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder.ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .Create();
            Assert.AreEqual(0, callCount);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
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
        public void PropertyObserver_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder.ValueObserverBuilder(instance, i => i.Class2.IntProperty).WithAction(() => callCount++).AutoActivate().Create();
            Assert.AreEqual(0, callCount);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder.ValueObserverBuilder(instance, i => i.Class2.IntProperty).WithNotifyProperyChanged().Create();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

       

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder.ValueObserverBuilder(instance, i => i.Class2.IntProperty).WithNotifyProperyChanged().AutoActivate().Create();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder.ValueObserverBuilder(instance, i => i.Class2.IntProperty).WithNotifyProperyChanged().WithGetterTaskScheduler(TaskScheduler.Current).Create();
            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

     

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder.ValueObserverBuilder(instance, i => i.Class2.IntProperty).WithNotifyProperyChanged().WithGetterTaskScheduler(TaskScheduler.Current).AutoActivate().Create();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, true, LazyThreadSafetyMode.None);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, true, LazyThreadSafetyMode.None, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, true, LazyThreadSafetyMode.None, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = instance.ObservesOnNotifyProperyChanged(i => i.Class2.IntProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, false);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesOnNotifyProperyChanged(instance, i => i.Class2.IntProperty, true, LazyThreadSafetyMode.None, TaskScheduler.Current, true);

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .Create();
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);
            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

      public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .Create(); Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesAndGet(instance, i => i.Class2.IntProperty, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesAndGet(instance, i => i.Class2.IntProperty, false, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyValueObserver.ObservesAndGet(instance, i => i.Class2.IntProperty, true, () => callCount++);
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_AutoActivateFalse()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, false, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyValueObserver.Observes(instance, i => i.Class2.IntProperty, true, (v) =>
                {
                    value = v;
                    callCount++;
                });

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction((int v) => {
                            value = v;
                            callCount++;
                        }
                    )
                .WithFallback(99)
                .Create();
            
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(1, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(99, observes.Value);
        }

        

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_IntProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(v => {
                        value = v;
                        callCount++;
                    }
                )
                .WithFallback(99)
                .AutoActivate()
                .Create();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(3, observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(99, observes.Value);
        }
    }
}