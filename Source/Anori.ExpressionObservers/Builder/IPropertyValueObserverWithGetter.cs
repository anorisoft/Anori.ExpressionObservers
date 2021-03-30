// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverWithGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    /// <summary>
    /// The I Property Value Observer With Getter interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverWithGetter<TParameter1, TResult>
        where TResult : struct
    {
    }
}