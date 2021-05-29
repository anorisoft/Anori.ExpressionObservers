// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedClass1.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.UnitTests.TestClasses
{
    using System.Collections.ObjectModel;

    public class NotifyPropertyChangedClass1 : Bindable
    {
        public const string StringConstant = "Constant";

        public const string NullStringConstant = null;

        private int _intProperty;

        private string _stringProperty;

        private NotifyPropertyChangedClass2 _class2 = new NotifyPropertyChangedClass2();

        private ObservableCollection<TestClass2> collection = new ObservableCollection<TestClass2>();

        private ObservableCollection<int> intCollection;

        public int IntProperty
        {
            get => this._intProperty;
            set
            {
                if (value == this._intProperty)
                {
                    return;
                }

                this._intProperty = value;
                this.OnPropertyChanged();
            }
        }

        public string StringProperty
        {
            get => this._stringProperty;
            set
            {
                if (value == this._stringProperty)
                {
                    return;
                }

                this._stringProperty = value;
                this.OnPropertyChanged();
            }
        }

        public NotifyPropertyChangedClass2 Class2
        {
            get => this._class2;
            set
            {
                if (Equals(value, this._class2))
                {
                    return;
                }

                this._class2 = value;
                this.OnPropertyChanged();
            }
        }

        public NotifyPropertyChangedClass2 GetClass2()
        {
            return this._class2;
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