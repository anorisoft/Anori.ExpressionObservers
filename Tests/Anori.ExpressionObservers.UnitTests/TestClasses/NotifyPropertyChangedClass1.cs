// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedClass1.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.TestClasses
{
    using System.Collections.ObjectModel;

    public class NotifyPropertyChangedClass1 : Bindable
    {
        public const string StringConstant = "Constant";

        public const string NullStringConstant = null;

        private int _intProperty;

        private string _stringProperty;

        private NotifyPropertyChangedClass2 _class2 = new NotifyPropertyChangedClass2();

        private ObservableCollection<NotifyPropertyChangedClass2> collection = new ObservableCollection<NotifyPropertyChangedClass2>();

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
            return Class2;
        }

        public ObservableCollection<NotifyPropertyChangedClass2> Collection
        {
            get => this.collection;
            set
            {
                if (Equals(value, this.collection)) return;
                this.collection = value;
                this.OnPropertyChanged();
            }
        }
    }
}