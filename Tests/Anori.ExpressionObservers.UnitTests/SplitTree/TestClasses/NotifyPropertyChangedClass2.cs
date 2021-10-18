// -----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedClass2.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree.TestClasses
{
    using System;

    public class NotifyPropertyChangedClass2 : Bindable
    {
        private int intProperty;

        private string stringProperty = String.Empty;

        private bool booleanProperty;

        public bool BooleanProperty
        {
            get => this.booleanProperty;
            set
            {
                if (value == this.booleanProperty) return;
                this.booleanProperty = value;
                this.OnPropertyChanged();
            }
        }

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
    }
}