// -----------------------------------------------------------------------
// <copyright file="ComplexType.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests
{
    using Anori.WinUI.Commands.Tests;

    public class ComplexType : TestPurposeBindableBase
    {
        private ComplexType _innerComplexProperty;

        private int _intProperty;

        public ComplexType InnerComplexProperty
        {
            get => this._innerComplexProperty;
            set => this.SetProperty(ref this._innerComplexProperty, value);
        }

        public int IntProperty
        {
            get => this._intProperty;
            set => this.SetProperty(ref this._intProperty, value);
        }
    }

  
}