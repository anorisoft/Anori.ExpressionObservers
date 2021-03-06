﻿// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_StringProperty_Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.UnitTests.TestClasses;
    using NUnit.Framework;
    using System.Threading;
    using System.Threading.Tasks;
    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    public class PropertyObserverBuilderStringPropertyI1Test
    {
        [SetUp]
        public void Init()
        {
            SynchronizationContext.SetSynchronizationContext(new TestSynchronizationContext());
        }

        [Test]
        public void PropertyObserver_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .Build();

            Assert.AreEqual(0, callCount);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.AreEqual(1, callCount);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty_Dispatche_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Defer_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .Deferred()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            using (var deferrer = observes.Defer())
            {
                instance.Class2.StringProperty = "2";
                Assert.AreEqual(1, callCount);
                Assert.AreEqual("1", observes.Value);

                instance.Class2.StringProperty = "3";
                Assert.AreEqual(1, callCount);
                Assert.AreEqual("1", observes.Value);

                instance.Class2.StringProperty = "2";
                Assert.AreEqual(1, callCount);
                Assert.AreEqual("1", observes.Value);
            }
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_MultibleDefer_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .Deferred()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            var deferrer1 = observes.Defer();
            instance.Class2.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "3";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            var deferrer2 = observes.Defer();

            instance.Class2.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);
            deferrer1.Dispose();

            instance.Class2.StringProperty = "4";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            deferrer2.Dispose();

            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_MultibleDefer_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Deferred()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            var deferrer1 = observes.Defer();
            instance.Class2.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "3";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            var deferrer2 = observes.Defer();
            instance.Class2.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            deferrer1.Dispose();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "4";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2";
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            deferrer2.Dispose();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }
        
        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Builder_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(autoActivate: true)
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Full()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Full_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Full_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Full_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Full_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_StringProperty_Cashed_Full_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback("Fallback")
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.Value);
            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback("Fallback")
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);

            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback("Fallback")
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.Value);
            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback("Fallback")
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);

            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .WithFallback("Fallback")
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("Fallback", observes.Value);
            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_StringProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback("Fallback")
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);

            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_StringProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetterNullable_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_StringProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    ( v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    ( v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_StringProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (string?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithNullableAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = "No Set";

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback("Fallback")
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = "No Set";
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback("Fallback")
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = "No Set";

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback("Fallback")
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = "No Set";
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback("Fallback")
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = "No Set";

            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(
                    (v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback("Fallback")
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("1", observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_StringProperty_Dispatcher_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = "No Set";
            using var observes = PropertyObserverBuilder.Builder
                .ReferenceObserverBuilder(() => instance.Class2.StringProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback("Fallback")
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("No Set", value);
            Assert.AreEqual("Fallback", observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { StringProperty = "1" };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.Class2.StringProperty = "2" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            instance.Class2.StringProperty = "3" ;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("3", observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("Fallback", observes.Value);
        }
    }
}