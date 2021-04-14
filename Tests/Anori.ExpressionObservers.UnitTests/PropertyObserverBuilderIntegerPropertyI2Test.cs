// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBuilderIntegerPropertyP1Test.cs" company="AnoriSoft">
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

    public class PropertyObserverBuilderIntegerPropertyI2Test
    {
        [SetUp]
        public void Init()
        {
            SynchronizationContext.SetSynchronizationContext(new TestSynchronizationContext());
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .Build();

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
        public void PropertyObserver_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(() => callCount++)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Builder_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(autoActivate: true)
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Full()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Full_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Full_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Full_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Full_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_Full_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithValueChanged()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithValueChanged()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_Dispatche_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            observes.PropertyChanged += (_, _) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
           
            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_Dispatcher_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetter_Fallback_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetter()
                .WithFallback(99)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }







        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                    {
                        value = v;
                        callCount++;
                    })
                .WithGetter()
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance1_IntProperty_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    v =>
                    {
                        value = v;
                        callCount++;
                    })
                .WithGetter()
                .WithFallback(99)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                    {
                        value = v;
                        callCount++;
                    })
                .WithGetter()
                .WithFallback(99)
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance1_IntProperty_Dispatcher_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    v =>
                    {
                        value = v;
                        callCount++;
                    })
                .WithGetter()
                .WithFallback(99)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                    {
                        value = v;
                        callCount++;
                    })
                .WithGetter()
                .WithFallback(99)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    v =>
                    {
                        value = v;
                        callCount++;
                    })
                .WithGetter()
                .WithFallback(99)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.Value);
        }


        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
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

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
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

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance1_IntProperty_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
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

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.Value);

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetterNullable_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
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

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.Value);

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.Value);

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.Value);

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.Value);
        }
    }
}