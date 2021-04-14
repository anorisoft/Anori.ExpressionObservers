// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBuilderFailFastIntegerPropertyI1Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.Exceptions;
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    public class PropertyObserverBuilderFailFastIntegerPropertyP2Test
    {
        [SetUp]
        public void Init()
        {
            SynchronizationContext.SetSynchronizationContext(new TestSynchronizationContext());
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .AutoActivate()
                .Build();

            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());

            Assert.AreEqual(0, callCount);

            Assert.AreEqual(99, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);

            Assert.AreEqual(99, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);

            Assert.AreEqual(99, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Getter_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .Build();

            Assert.AreEqual(0, callCount);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(() => callCount++)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Builder_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions, true)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_Dispatche_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_DoubleActivation()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .Build();
            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_DoubleDeactivation()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .Build();
            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Build();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

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

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1, i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance_IntProperty_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1, i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1, i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance_IntProperty_Dispatcher_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1, i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1, i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetter_Fallback_Getter_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1, i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }


        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            observes.Activate();
            Assert.Throws<AlreadyActivatedException>(() => observes.Activate());
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }

        [Test]
        public void
            PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            var value = (int?)null;

            using var observes = new PropertyObserverBuilder(PropertyObserverFlag.ThrowsAllExceptions)
                .ValueObserverBuilder(instance, instance, (i1,i2) => i1.Class2.IntProperty)
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

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(1, value);
            Assert.AreEqual(1, observes.Value);

            instance.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.AreEqual(2, observes.Value);

            observes.Deactivate();
            Assert.Throws<AlreadyDeactivatedException>(() => observes.Deactivate());
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);

            instance.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(2, value);
            Assert.Throws<NotActivatedException>(() => _ = observes.Value);
        }
    }
}