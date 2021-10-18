// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedClass1.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree.TestClasses
{
    using System.Collections.ObjectModel;

    public class NotifyPropertyChangedClass1 : Bindable
    {
        public const string StringConstant = "Constant";

        public const string NullStringConstant = null;

        private int intProperty;

        private string? stringProperty;

        private NotifyPropertyChangedClass2 class2 = new NotifyPropertyChangedClass2();

        private ObservableCollection<TestClass2> collection = new ObservableCollection<TestClass2>();

        private ObservableCollection<int> intCollection;

        public int IntProperty
        {
            get => this.intProperty;
            set
            {
                if (value == this.intProperty)
                {
                    return;
                }

                this.intProperty = value;
                this.OnPropertyChanged();
            }
        }

        public string StringProperty
        {
            get => this.stringProperty;
            set
            {
                if (value == this.stringProperty)
                {
                    return;
                }

                this.stringProperty = value;
                this.OnPropertyChanged();
            }
        }

        public NotifyPropertyChangedClass2 Class2
        {
            get => this.class2;
            set
            {
                if (Equals(value, this.class2))
                {
                    return;
                }

                this.class2 = value;
                this.OnPropertyChanged();
            }
        }

        public NotifyPropertyChangedClass2 GetClass2()
        {
            return this.class2;
        }

        public ObservableCollection<TestClass2> Collection
        {
            get => this.collection;
            set
            {
                if (Equals(value, this.collection)) return;
                this.collection = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<int> IntCollection
        {
            get => this.intCollection;
            set
            {
                if (Equals(value, this.intCollection)) return;
                this.intCollection = value;
                this.OnPropertyChanged();
            }
        }
    }
}