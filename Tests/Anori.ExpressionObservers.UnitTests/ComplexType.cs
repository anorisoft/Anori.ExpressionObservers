// -----------------------------------------------------------------------
// <copyright file="ComplexType.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    public class ComplexType : TestPurposeBindableBase
    {
        private ComplexType innerComplexProperty;

        private int intProperty;

        public ComplexType InnerComplexProperty
        {
            get => this.innerComplexProperty;
            set => this.SetProperty(ref this.innerComplexProperty, value);
        }

        public int IntProperty
        {
            get => this.intProperty;
            set => this.SetProperty(ref this.intProperty, value);
        }
    }

  
}