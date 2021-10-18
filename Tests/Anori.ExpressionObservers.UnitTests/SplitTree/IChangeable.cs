// -----------------------------------------------------------------------
// <copyright file="IChangeable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.UnitTests.SplitTree
{
    using System;

    using Anori.Extensions;

    public interface IChangeable<T> : IChangeable
    {
        event EventHandler<EventArgs<T>> Changed;

        T Value { get; set; }
    }

    public interface IChangeable
    {
        event EventHandler<EventArgs<object>> ObjectChanged;

        object Value { get; set; }
    }
}