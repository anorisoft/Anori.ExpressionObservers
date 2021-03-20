// -----------------------------------------------------------------------
// <copyright file="PropertyObserver_StringProperty_Test.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public void PropertyObserver_OnValueChanged_Observes_instance_StringProperty()
        {
            var instance = new NotifyPropertyChangedClass1();
            var callCount = 0;
            using var observes = PropertyReferenceObserver.ObservesOnValueChanged( () => instance.StringProperty);
            
            observes.PropertyChanged += (sender, args) => callCount++;
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual(null, observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("3", observes.Value);
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);

            observes.Unsubscribe();
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

            observes.Unsubscribe();
            Assert.AreEqual(2, callCount);

            instance.StringProperty = "3";
            Assert.AreEqual(2, callCount);
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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
            Assert.AreEqual(null, observes.Value);

            instance.StringProperty = "1";
            Assert.AreEqual(0, callCount);
            Assert.AreEqual("1", observes.Value);

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Subscribe();
            Assert.AreEqual(1, callCount);
            Assert.AreEqual("1", value);
            Assert.AreEqual("1", observes.Value);

            instance.StringProperty = "2";
            Assert.AreEqual(2, callCount);
            Assert.AreEqual("2", value);
            Assert.AreEqual("2", observes.Value);

            observes.Unsubscribe();
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

            observes.Unsubscribe();
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
}