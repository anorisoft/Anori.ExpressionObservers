// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_IntProperty_Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using System.Threading;

    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    using System.Threading.Tasks;

    using LazyThreadSafetyMode = Anori.Common.LazyThreadSafetyMode;

    public class PropertyObserverBuilderIntegerPropertyP1Test
    {

        [SetUp]
        public void Init()
        {
            SynchronizationContext.SetSynchronizationContext(new TestSynchronizationContext());
        }


        [Test]
        public void PropertyObserver_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .AutoActivate()
                .Create();

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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithValueChanged()
                .Create();

            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.Class2 = new NotifyPropertyChangedClass2 { IntProperty = 1 };
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithValueChanged()
                .AutoActivate()
                .Create();

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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void PropertyObserver_OnValueChanged_Observes_instance_IntProperty_Dispatche_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithValueChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Builder_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = new PropertyObserverBuilder(true)
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Create();

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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .AutoActivate()
                .Create();

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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .Create();

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
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached()
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .Create();

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
        public void
            PropertyObserver_OnNotifyProperyChanged_Observes_instance_IntProperty_Cashed_Full_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithNotifyProperyChanged()
                .Cached(LazyThreadSafetyMode.Full)
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .AutoActivate()
                .Create();
            Assert.AreEqual(0, callCount);

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
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
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

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .WithFallback(99)
                .AutoActivate()
                .Create();
            Assert.AreEqual(0, callCount);

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
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
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

        [Test]
        public void PropertyObserver_Getter_Fallback_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithFallback(99)
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();
            Assert.AreEqual(0, callCount);

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
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .Create();

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
        public void PropertyObserver_Getter_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_Getter_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void PropertyObserver_Getter_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_Getter_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .Create();

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
        public void PropertyObserver_Getter_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(() => callCount++)
                .WithGetter()
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Create();

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
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void
            PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .Create();

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
        public void PropertyObserver_ValueGetterNullable_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .Create();

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
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {

                            value = v;
                            callCount++;
                        })
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .Create();

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
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {

                            value = v;
                            callCount++;
                        })
                .WithGetterTaskScheduler(TaskScheduler.Current)
                .AutoActivate()
                .Create();

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
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;


            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .Create();

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
        public void PropertyObserver_ValueGetter_Observes_instance_IntProperty_Dispatcher_AutoActivate()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)null;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int? v) =>
                        {

                            value = v;
                            callCount++;
                        })
                .WithGetterDispatcher()
                .AutoActivate()
                .Create();

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
                .WithAction(
                    (int v) =>
                        {
                            value = v;
                            callCount++;
                        })
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
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
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


        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_IntProperty_TaskSchedulerCurrent()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterTaskScheduler(TaskScheduler.Current)
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
        public void
            PropertyObserver_ValueGetter_Fallback_Observes_instance_IntProperty_TaskSchedulerCurrent_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterTaskScheduler(TaskScheduler.Current)
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


        [Test]
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_IntProperty_Dispatcher()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = (int?)-1;

            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    (int v) =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterDispatcher()
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
        public void PropertyObserver_ValueGetter_Fallback_Observes_instance_IntProperty_Dispatcher_AutoActivateTrue()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            var callCount = 0;
            var value = -1;
            using var observes = PropertyObserverBuilder.Builder
                .ValueObserverBuilder(instance, i => i.Class2.IntProperty)
                .WithAction(
                    v =>
                        {
                            value = v;
                            callCount++;
                        })
                .WithFallback(99)
                .WithGetterDispatcher()
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