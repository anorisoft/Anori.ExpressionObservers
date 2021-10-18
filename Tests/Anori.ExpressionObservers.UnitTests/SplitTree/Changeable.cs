// -----------------------------------------------------------------------
// <copyright file="Changeable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree
{
    using System;

    using Anori.ExpressionObservers.ExpressionNodeSplitter;
    using Anori.Extensions;

    public class Changeable<T> : IChangeable<T>
    {
        private T value = default;

        public event EventHandler<EventArgs<object>>? ObjectChanged
            ;

        public T Value
        {
            get => this.value;
            set
            {
                if(Equals(this.value, value))return;
                this.value = value;
                this.ObjectChanged.Raise(value);
                this.Changed.Raise(value);
            }
        }

        public event EventHandler<EventArgs<T>>? Changed;

        object IChangeable.Value
        {
            get => this.Value;
            set
            {
                this.Value = (T)value;
            }
        }
    }
}