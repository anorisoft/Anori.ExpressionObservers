// -----------------------------------------------------------------------
// <copyright file="PropertyObserverBuilderIntegerPropertyP1Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.ExpressionObservers.UnitTests.TestClasses;
    using NUnit.Framework;
    using System.Threading;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Builder;

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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(99, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .AutoActivate()
                .Build();
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(null, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.GetValue());
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
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Builder_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(autoActivate: true)
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithCache()
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache()
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void
            PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Full()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache(LazyThreadSafetyMode.Full)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Full_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithCache(LazyThreadSafetyMode.Full)
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Full_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void
            PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Full_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void
            PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Full_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache(LazyThreadSafetyMode.Full)
                .WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void
            PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_Full_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache(LazyThreadSafetyMode.Full)
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache()
                .WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void
            PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithCache()
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_Dispatcher_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                                .WithAction(() => callCount++)
                .WithGetter()
.WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void
            PropertyObserver_OnPropertyChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnPropertyChanged()
                .WithAction(() => callCount++)
                .WithGetter()
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(5, observes.GetValue());
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnValueChanged()
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnValueChanged()
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_Dispatche_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnValueChanged()
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_Dispatcher()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnValueChanged()
                .WithScheduler(TaskScheduler.Current)
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnValueChanged()
                .WithScheduler(TaskScheduler.Current)
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance1_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance1 = new NotifyPropertyChangedClass1 { Class2 = null };
            var instance2 = new NotifyPropertyChangedClass1 { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(() => instance1.Class2.IntProperty + instance2.Class2.IntProperty)
                .OnValueChanged()
                .WithScheduler(TaskScheduler.Current)
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
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(null, observes.Value);
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
                .WithScheduler(TaskScheduler.Current)
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
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(-1, value);
            Assert.AreEqual(99, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(99, value);
            Assert.AreEqual(99, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(99, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(3, observes.GetValue());

            observes.Activate();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
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
                .WithScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Build();

            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance1.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(null, value);
            Assert.AreEqual(null, observes.GetValue());

            instance2.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 2 };
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(3, value);
            Assert.AreEqual(3, observes.GetValue());

            instance1.Class2.IntProperty = 2;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            observes.Deactivate();
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(4, observes.GetValue());

            instance1.Class2.IntProperty = 3;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(5, observes.GetValue());

            instance1.Class2 = null;
            Assert.AreEqual(3, callCount);
            Assert.AreEqual(4, value);
            Assert.AreEqual(null, observes.GetValue());
        }
    }
}