// -----------------------------------------------------------------------
// <copyright file="IGetterBuilderWithFallback{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using System;

    /// <summary>
    /// The Getter Builder With Fallback interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IGetterBuilderWithFallback<in TParameter1, out TResult>
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The Getter.</returns>
        Func<TParameter1, TResult> Create();
    }
}