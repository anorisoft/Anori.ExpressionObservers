// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedClass2.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.UnitTests.TestClasses
{
    public class NotifyPropertyChangedClass2 : Bindable
    {
        private int _intProperty;

        private string _stringProperty;

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
    }
}