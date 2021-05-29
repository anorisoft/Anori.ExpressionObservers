using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anori.ExpressionObservers.UnitTests.Collection
{
    using Anori.ExpressionObservers.Builder;
    using Anori.ExpressionObservers.UnitTests.TestClasses;

    using NUnit.Framework;

    public class Class1
    {
        [Test]
        public void PropertyObserver_Observes_instance_IntProperty()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 1 });
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 2 });
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 3 });
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 4 });
            var callCount = 0;
            var value = (int?)null;
            var v = (int?)null;
            using var observer =  PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance.Collection[1].IntProperty).OnPropertyChanged().WithAction((int i) =>
                {
                    callCount++;
                    v = i;
                }).WithFallback(99).WithGetter().Build();
            Assert.AreEqual(0, callCount);
            value = observer.GetValue();
            Assert.AreEqual(2, value);
            
            observer.Activate();
            Assert.AreEqual(1, callCount);

            instance.Collection.Insert(0, new NotifyPropertyChangedClass2() { IntProperty = 0 });
            Assert.AreEqual(2, callCount);
            value = observer.GetValue();
            Assert.AreEqual(1, value);

            instance.Collection.RemoveAt(4);
            Assert.AreEqual(3, callCount);
            value = observer.GetValue();
            Assert.AreEqual(1, value);

            instance.Collection.RemoveAt(1);
            Assert.AreEqual(4, callCount);
            value = observer.GetValue();
            Assert.AreEqual(2, value);

            instance.Collection.Move(2,1);
            Assert.AreEqual(5, callCount);
            value = observer.GetValue();
            Assert.AreEqual(3, value);

            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 5 });
            Assert.AreEqual(6, callCount);
            value = observer.GetValue();
            Assert.AreEqual(3, value);

            instance.Collection[1].IntProperty = 10;
            Assert.AreEqual(7, callCount);
            value = observer.GetValue();
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, v);

            observer.Deactivate();
            Assert.AreEqual(7, callCount);
        }
    

    
        [Test]
        public void PropertyObserver_Observes_instance_IntProperty_Index()
        {
            var instance = new NotifyPropertyChangedClass1() { Class2 = null };
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 1 });
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 2 });
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 3 });
            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 4 });
            var callCount = 0;
            var value = (int?)null;
            var index = 1;
            var v = (int?)null;
            using var observer = PropertyObserverBuilder.Builder.ValueObserverBuilder(() => instance.Collection[index].IntProperty).OnPropertyChanged().WithAction((int i) =>
            {
                callCount++;
                v = i;
            }).WithFallback(99).WithGetter().Build();
            Assert.AreEqual(0, callCount);
            value = observer.GetValue();
            Assert.AreEqual(2, value);

            observer.Activate();
            Assert.AreEqual(1, callCount);

            instance.Collection.Insert(0, new NotifyPropertyChangedClass2() { IntProperty = 0 });
            Assert.AreEqual(2, callCount);
            value = observer.GetValue();
            Assert.AreEqual(1, value);

            instance.Collection.RemoveAt(4);
            Assert.AreEqual(3, callCount);
            value = observer.GetValue();
            Assert.AreEqual(1, value);

            instance.Collection.RemoveAt(1);
            Assert.AreEqual(4, callCount);
            value = observer.GetValue();
            Assert.AreEqual(2, value);

            instance.Collection.Move(2, 1);
            Assert.AreEqual(5, callCount);
            value = observer.GetValue();
            Assert.AreEqual(3, value);

            instance.Collection.Add(new NotifyPropertyChangedClass2() { IntProperty = 5 });
            Assert.AreEqual(6, callCount);
            value = observer.GetValue();
            Assert.AreEqual(3, value);

            instance.Collection[1].IntProperty = 10;
            Assert.AreEqual(7, callCount);
            value = observer.GetValue();
            Assert.AreEqual(10, value);
            Assert.AreEqual(10, v);

            observer.Deactivate();
            Assert.AreEqual(7, callCount);
        }
    }
}
